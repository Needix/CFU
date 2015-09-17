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
            Lists l = new Lists();
            CalculateLists(l);

            CompareLocalServer(true, true, l);
            CompareServerLocal(true, true, l);

            WebClient client = CreateServerWebClient();
            foreach(string missingRemoteFolder in l.MissingRemoteFolders) {
                string newFolder = GMOD_ROOT + missingRemoteFolder;
                FtpWebRequest ftp = CreateServerWebRequest(missingRemoteFolder+"/");
                ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse resp = (FtpWebResponse)ftp.GetResponse();
                View.AddInfo("Created missing directory: "+newFolder+" @"+ftp.RequestUri);
                resp.Close();
            }
            foreach(string missingRemoteFile in l.MissingRemoteFiles) {
                String newFile = GMOD_ROOT + missingRemoteFile;
                View.AddInfo("Uploading file: \""+newFile+"\" and saving in location \""+GetServerURI(missingRemoteFile)+"\"");
                client.UploadFile(GetServerURI(missingRemoteFile), newFile);
            }
            client.Dispose();

            View.AddInfo("Finished syncing!");
        }
        public void SyncServerLocal(object sender, EventArgs e) {
            Lists l = new Lists();
            CalculateLists(l);

            CompareServerLocal(true, true, l);
            CompareLocalServer(true, true, l);
            
            WebClient client = CreateServerWebClient();
            foreach(string missingLocalFolder in l.MissingLocalFolders) {
                string newFolder = GMOD_ROOT + missingLocalFolder;
                View.AddInfo("Creating missing directory: "+newFolder);
                Directory.CreateDirectory(newFolder);
            }
            foreach(string missingLocalFile in l.MissingLocalFiles) {
                String newFile = GMOD_ROOT + missingLocalFile;
                View.AddInfo("Downloading file: \""+missingLocalFile+"\" and saving in location \""+newFile+"\"");
                client.DownloadFile(GetServerURI(missingLocalFile), newFile);
            }
            client.Dispose();
            
            View.AddInfo("Finished syncing!");
        }

        public void Check(object sender, EventArgs e) {
            Debug.WriteLine("Finished reading...");
        }

        private bool CompareServerLocal(bool compareFiles, bool compareFolder, Lists l) {
            if(!compareFiles && !compareFolder) return false;

            List<String> rootFiles = l.RootFiles;
            List<String> rootFolders = l.RootFolders;
            List<String> remoteFiles = l.RemoteFiles;
            List<String> remoteFolders = l.RemoteFolders;

            l.MissingLocalFiles = new List<string>();
            l.MissingLocalFolders = new List<string>();

            View.AddInfo("Starting to compare remote folder with root folder...");
            if(compareFiles) {
                foreach(string remoteFile in remoteFiles) {
                    bool found = false;
                    foreach(string rootFile in rootFiles) {
                        if(rootFile.Equals(remoteFile)) {
                            found = true; //TODO: Not only check if file exists, but also if same/equals
                            break;
                        }
                    }
                    if(!found) { //TODO: Also check if file/folder has to be deleted (exitsts locally but not on server)
                        string newFile = GMOD_ROOT + remoteFile;
                        l.MissingLocalFiles.Add(remoteFile); 
                    }
                }
            }

            if(compareFolder) {
                foreach(string remoteFolder in remoteFolders) {
                    bool found = false;
                    foreach(string rootFolder in rootFolders) {
                        if(rootFolder.Equals(remoteFolder)) {
                            found = true;
                            break;
                        }
                    }
                    if(!found) {
                        string newDir = GMOD_ROOT + remoteFolder;
                        l.MissingLocalFolders.Add(remoteFolder);
                    }
                }
            }
            return true;
        }


        private bool CompareLocalServer(bool compareFiles, bool compareFolder, Lists l) {
            if(!compareFiles && !compareFolder) return false;

            List<String> rootFiles = l.RootFiles;
            List<String> rootFolders = l.RootFolders;
            List<String> remoteFiles = l.RemoteFiles;
            List<String> remoteFolders = l.RemoteFolders;

            l.MissingRemoteFiles = new List<string>();
            l.MissingRemoteFolders = new List<string>();

            View.AddInfo("Starting to compare root folder with remote folder...");
            if(compareFiles) {
                foreach(string rootFile in rootFiles) {
                    bool found = false;
                    foreach(string remoteFile in remoteFiles) {
                        if(rootFile.Equals(remoteFile)) {
                            found = true; //TODO: Not only check if file exists, but also if same/equals
                            break;
                        }
                    }
                    if(!found) { //TODO: Also check if file/folder has to be deleted (exitsts locally but not on server)
                        string newFile = GMOD_ROOT + rootFile;
                        l.MissingRemoteFiles.Add(rootFile);
                    }
                }
            }

            if(compareFolder) {
                foreach(string rootFolder in rootFolders) {
                    bool found = false;
                    foreach(string remoteFolder in remoteFolders) {
                        if(rootFolder.Equals(remoteFolder)) {
                            found = true;
                            break;
                        }
                    }
                    if(!found) {
                        string newDir = GMOD_ROOT + rootFolder;
                        l.MissingRemoteFolders.Add(rootFolder);
                        //View.AddInfo("Creating directory: " + newDir);
                        //Directory.CreateDirectory(newDir);
                    }
                }
            }
            return true;
        }

        private void CalculateLists(Lists l) {
            l.RootFolders = new List<string>();
            l.RootFiles = new List<string>();
            l.RemoteFolders = new List<string>();
            l.RemoteFiles = new List<string>();

            View.AddInfo("Starting to search \""+GMOD_ROOT+"\" recursively... Please wait patiently.");
            Client_ListFAFs(GMOD_ROOT, l, true, true);

            View.AddInfo("Downloading file and folder list from \""+GetServerURI("", false)+"\"... Please wait patiently.");
            FTP_ListFAFs(null, l, true, true);
        }
        
        private void Client_ListFAFs(String baseFolder, Lists l, bool recFiles, bool recFolder) {
            List<String> folderList = l.RootFolders;
            List<String> fileList = l.RootFiles;

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
                    Client_ListFAFs(folder, l, recFiles, true);
                }
            }
        }
        private void FTP_ListFAFs(List<String> relPaths, Lists l, bool recFiles, bool recFolder) {
            List<String> folder = l.RemoteFolders;
            List<String> files = l.RemoteFiles;

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

                FTP_ListFAFs(dirList, l, recFiles, recFolder);
            }
        }
    }
}