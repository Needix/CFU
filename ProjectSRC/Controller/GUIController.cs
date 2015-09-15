// GUIController.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.GUI;
using Custom_FTP_Uploader.ProjectSRC.Model;

namespace Custom_FTP_Uploader.ProjectSRC.Controller {
    public partial class GUIController {
        private const string GMOD_BASE = "R:\\Other\\TestFTPServer\\Local_GMOD\\";
        private const string GMOD_SUB_FOLDER = "serverdata/garrysmod/";
        private const string GMOD_ROOT = GMOD_BASE + GMOD_SUB_FOLDER;

        private GUIModel _model;
        public GUIModel Model {
            get { return _model; }
            set {
                if(value == null) return;
                _model = value;
            }
        }

        public GUIView View { get; set; }

        public Serializer Serializer { get; private set; }

        public GUIController(GUIView view) {
            Serializer = new Serializer(this);
            Model = Serializer.Deserialize();
            if(Model == null) Model = new GUIModel();

            View = view;
            View.UpdateView(Model);
        }

        //INFO: dreistetraitor/programm.exe
        //INFO: dreistetraitor/serverdata/garrysmod/addons
        public void SyncLocalServer(object sender, EventArgs e) {
            
        }
        public void SyncServerLocal(object sender, EventArgs e) {
            List<String> rootFolders = new List<string>();
            List<String> rootFiles = new List<string>();
            View.AddInfo("Starting to search \""+GMOD_ROOT+"\" recursively... Please wait patiently.");
            Client_ListFAFs(GMOD_ROOT, rootFolders, rootFiles, true, true);

            List<String> remoteFolders = new List<string>();
            List<String> remoteFiles = new List<string>();
            View.AddInfo("Downloading file and folder list from \""+GetServerURI("", false)+"\"... Please wait patiently.");
            FTP_ListFAFs(null, remoteFolders, remoteFiles, true, true);

            View.AddInfo("Starting to compare root folder with remote folder...");
            WebClient client = CreateServerWebClient();
            foreach(string remoteFolder in remoteFolders) {
                bool found = false;
                foreach (string rootFolder in rootFolders) {
                    if (rootFolder.Equals(remoteFolder)) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    string newDir = GMOD_ROOT + remoteFolder;
                    View.AddInfo("Creating directory: "+newDir);
                    Directory.CreateDirectory(newDir);
                }
            }

            View.AddInfo("Starting to compare root files with remote files...");
            foreach(string remoteFile in remoteFiles) {
                bool found = false;
                foreach(string rootFile in rootFiles) {
                    if(rootFile.Equals(remoteFile)) {
                        found = true; //TODO: Not only check if file exists, but only if same/equals
                        break;
                    }
                }
                if(!found) {
                    string newFile = GMOD_ROOT + remoteFile;
                    View.AddInfo("Downloading file: \""+remoteFile+"\" and saving in location \""+newFile+"\"");
                    client.DownloadFile(GetServerURI(remoteFile), newFile);
                }
            }
            client.Dispose();
        }

        public void Check(object sender, EventArgs e) {
            Debug.WriteLine("Finished reading...");
        }

        private List<String> CompareVersions(bool compareFiles, bool compareFolder) {
            if (!compareFiles && !compareFolder) return null;
            List<String> rootFolders = new List<string>();
            List<String> rootFiles = new List<string>();
            View.AddInfo("Starting to search \""+GMOD_ROOT+"\" recursively... Please wait patiently.");
            Client_ListFAFs(GMOD_ROOT, rootFolders, rootFiles, true, true);

            List<String> remoteFolders = new List<string>();
            List<String> remoteFiles = new List<string>();
            View.AddInfo("Downloading file and folder list from \""+GetServerURI("", false)+"\"... Please wait patiently.");
            FTP_ListFAFs(null, remoteFolders, remoteFiles, true, true);

            return null;
        }

        private void Client_ListFAFs(String baseFolder, List<String> folderList, List<String> fileList, bool recFiles, bool recFolder) {
            if(!recFolder && !recFiles) return;
            String[] folders = Directory.GetDirectories(baseFolder);
            String[] files = Directory.GetFiles(baseFolder);
            if(recFiles) {
                foreach(string file in files) {
                    string relative = file.Substring(file.IndexOf(GMOD_SUB_FOLDER) + GMOD_SUB_FOLDER.Length);
                    relative = relative.Replace('\\', '/');
                    if(File.Exists(file)) fileList.Add(relative);
                }
            }

            foreach(string folder in folders) {
                if(Directory.Exists(folder)) {
                    if(recFolder) {
                        if(folder.Contains(".svn") || folder.Contains(".git")) continue; //Exclude git and svn dirs
                        string relative = folder.Substring(folder.IndexOf(GMOD_SUB_FOLDER) + GMOD_SUB_FOLDER.Length);
                        relative = relative.Replace('\\', '/');
                        folderList.Add(relative);
                    }
                    Client_ListFAFs(folder, folderList, fileList, recFiles, true);
                }
            }
        }

        private void FTP_ListFAFs(List<String> relPaths, List<String> folder, List<String> files, bool recFiles, bool recFolder) {
            if (relPaths == null) {
                relPaths = new List<string>();
                relPaths.Add("");
            }
            foreach (string relPath in relPaths) {
                WebRequest wr = CreateServerWebRequest(relPath);
                if (wr == null) {
                    Debug.WriteLine("ERROR: Could not create server web request!");
                    return;
                }
                wr.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response1 = (FtpWebResponse) wr.GetResponse();
                Stream stream = response1.GetResponseStream();
                if (stream == null) {
                    Debug.WriteLine("ERROR: Response stream was empty!");
                    return;
                }

                StreamReader reader = new StreamReader(stream);
                List<String> dirList = new List<string>();
                String line;
                while ((line = reader.ReadLine()) != null) {
                    Regex regex = new Regex(@"^([d-])([rwxt-]{3}){3}\s+\d{1,}\s+.*?(\d{1,})\s+(\w+\s+\d{1,2}\s+(?:\d{4})?)(\d{1,2}:\d{2})?\s+(.+?)\s?$", //http://stackoverflow.com/questions/1013486/parsing-ftpwebrequests-listdirectorydetails-line
                                            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                    Match m = regex.Match(line);
                    GroupCollection groups = m.Groups;
                    bool file = "-".Equals(groups[1].ToString());
                    string permissions = groups[2].ToString();
                    string filesize = groups[3].ToString();
                    string lastModifiedDate = groups[4].ToString();
                    string lastModifiedTime = groups[5].ToString();
                    string name = groups[6].ToString();
                    string fullPath = relPath + "/" + name;
                    if("".Equals(relPath)) fullPath = name;

                    if(!file && (name.Contains(".svn") || name.Contains(".git"))) continue; //Exclude git and svn dirs

                    if(recFiles && file) files.Add(fullPath);
                    if(recFolder && !file) folder.Add(fullPath);
                    if(!file) dirList.Add(fullPath);
                }
                response1.Close();

                FTP_ListFAFs(dirList, folder, files, recFiles, recFolder);
            }
        }

    }
}