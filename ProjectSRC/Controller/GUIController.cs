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
        private const string GMOD_BASE = "R:/Other/TestFTPServer/Local_GMOD/";
        //private const string GMOD_BASE = "/";
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

            WebClient client = CreateServerWebClient();
            foreach (string missingLocalFile in l.MissingLocalFiles) { //Delete all files on ftp, that dont exists locally
                FtpWebRequest ftp = CreateServerWebRequest(missingLocalFile);
                View.AddInfo("Deleting file from ftp: "+ftp.RequestUri);
                Debug.WriteLine("Deleting file from ftp: "+ftp.RequestUri);
                ftp.Method = WebRequestMethods.Ftp.DeleteFile;
                ftp.GetResponse().Close();
            }
            foreach (string missingLocalFolder in l.MissingLocalFolders) { //Delete all folder on ftp, that dont exists locally
                FtpWebRequest ftp = CreateServerWebRequest(missingLocalFolder);
                View.AddInfo("Deleting folder from ftp: "+ftp.RequestUri);
                Debug.WriteLine("Deleting folder from ftp: "+ftp.RequestUri);
                ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
                ftp.GetResponse().Close();
                //try { } catch(WebException ex) { View.AddWarningInfo("Could not delete folder from ftp: "+ex.InnerException.); }
            }

            foreach(string missingRemoteFolder in l.MissingRemoteFolders) { //Create all folder on ftp, that dont exists on ftp
                string newFolder = GMOD_ROOT + missingRemoteFolder;
                FtpWebRequest ftp = CreateServerWebRequest(missingRemoteFolder+"/");
                View.AddInfo("Creating missing directory: "+newFolder+" @"+ftp.RequestUri);
                ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftp.GetResponse().Close();
            }
            foreach(string missingRemoteFile in l.MissingRemoteFiles) { //Upload all files on ftp, that dont exists on ftp
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
            
            WebClient client = CreateServerWebClient();
            foreach(string missingRemoteFile in l.MissingRemoteFiles) { //Delete all files locally, that dont exist on server
                string fileToDelete = GMOD_ROOT + missingRemoteFile;
                View.AddInfo("Deleting file: "+fileToDelete);
                File.Delete(fileToDelete);
            }
            foreach (string missingRemoteFolder in l.MissingRemoteFolders) { //Delete all folder locally, that dont exist on server
                string folderToDelete = GMOD_ROOT + missingRemoteFolder;
                View.AddInfo("Deleting folder: "+folderToDelete);
                Directory.Delete(folderToDelete);
            }

            foreach(string missingLocalFolder in l.MissingLocalFolders) { //Create all folder locally, that dont exist locally
                string newFolder = GMOD_ROOT + missingLocalFolder;
                View.AddInfo("Creating missing directory: "+newFolder);
                Directory.CreateDirectory(newFolder);
            }
            foreach(string missingLocalFile in l.MissingLocalFiles) { //Download all files locally, that dont exist locally
                String newFile = GMOD_ROOT + missingLocalFile;
                View.AddInfo("Downloading file: \""+missingLocalFile+"\" and saving in location \""+newFile+"\"");
                client.DownloadFile(GetServerURI(missingLocalFile), newFile); //TODO: Implement async download
            }
            client.Dispose();
            
            View.AddInfo("Finished syncing!");
        }

        public void Check(object sender, EventArgs e) {
            throw new NotImplementedException("Check is not implemented yet!");
        }

        private void CalculateLists(Lists l) {
            l.RootFolders = new List<string>();
            l.RootFiles = new List<string>();
            l.RemoteFolders = new List<FTP_FAF>();
            l.RemoteFiles = new List<FTP_FAF>();

            View.AddInfo("Starting to search \""+GMOD_ROOT+"\" recursively... Please wait patiently.");
            Client_ListFAFs(GMOD_ROOT, l, true, true);

            View.AddInfo("Downloading file and folder list from \""+GetServerURI("", false)+"\"... Please wait patiently.");
            FTP_ListFAFs("", l, true, true);

            CompareServerLocal(true, true, l);
            CompareLocalServer(true, true, l);
        }
        private bool CompareServerLocal(bool compareFiles, bool compareFolder, Lists l) {
            if(!compareFiles && !compareFolder) return false;

            List<String> rootFiles = l.RootFiles;
            List<String> rootFolders = l.RootFolders;
            List<FTP_FAF> remoteFiles = l.RemoteFiles;
            List<FTP_FAF> remoteFolders = l.RemoteFolders;

            l.MissingLocalFiles = new List<string>();
            l.MissingLocalFolders = new List<string>();

            View.AddInfo("Starting to compare remote folder with root folder...");
            if(compareFiles) {
                foreach(FTP_FAF remoteFile in remoteFiles) {
                    bool found = false;
                    foreach(string rootFile in rootFiles) {
                        if(rootFile.Equals(remoteFile.RelativePath)) {
                            found = remoteFile.Filesize == new FileInfo(GMOD_ROOT+rootFile).Length;
                            break;
                        }
                    }
                    if(!found) {
                        string newFile = GMOD_ROOT + remoteFile;
                        l.MissingLocalFiles.Add(remoteFile.RelativePath); 
                    }
                }
            }

            if(compareFolder) {
                foreach(FTP_FAF remoteFolder in remoteFolders) {
                    bool found = false;
                    foreach(string rootFolder in rootFolders) {
                        if(rootFolder.Equals(remoteFolder.RelativePath)) {
                            found = true;
                            break;
                        }
                    }
                    if(!found) {
                        string newDir = GMOD_ROOT + remoteFolder;
                        l.MissingLocalFolders.Add(remoteFolder.RelativePath);
                    }
                }
            }
            return true;
        }
        private bool CompareLocalServer(bool compareFiles, bool compareFolder, Lists l) {
            if(!compareFiles && !compareFolder) return false;

            List<String> rootFiles = l.RootFiles;
            List<String> rootFolders = l.RootFolders;
            List<FTP_FAF> remoteFiles = l.RemoteFiles;
            List<FTP_FAF> remoteFolders = l.RemoteFolders;

            l.MissingRemoteFiles = new List<string>();
            l.MissingRemoteFolders = new List<string>();

            View.AddInfo("Starting to compare root folder with remote folder...");
            if(compareFiles) {
                foreach(string rootFile in rootFiles) {
                    bool found = false;
                    foreach(FTP_FAF remoteFile in remoteFiles) {
                        if(rootFile.Equals(remoteFile.RelativePath)) {
                            found = remoteFile.Filesize == new FileInfo(GMOD_ROOT+rootFile).Length;
                            break;
                        }
                    }
                    if(!found) {
                        string newFile = GMOD_ROOT + rootFile;
                        l.MissingRemoteFiles.Add(rootFile);
                    }
                }
            }

            if(compareFolder) {
                foreach(string rootFolder in rootFolders) {
                    bool found = false;
                    foreach(FTP_FAF remoteFolder in remoteFolders) {
                        if(rootFolder.Equals(remoteFolder.RelativePath)) {
                            found = true;
                            break;
                        }
                    }
                    if(!found) {
                        string newDir = GMOD_ROOT + rootFolder;
                        l.MissingRemoteFolders.Add(rootFolder);
                    }
                }
            }
            return true;
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
                    if(folder.Contains(".svn") || folder.Contains(".git")) continue; //Exclude git and svn dirs
                    string relative = folder.Substring(folder.IndexOf(GMOD_SUB_FOLDER) + GMOD_SUB_FOLDER.Length);
                    relative = relative.Replace('\\', '/');

                    Client_ListFAFs(folder, l, recFiles, true);

                    if(recFolder) {
                        folderList.Add(relative);
                    }
                }
            }
        }
        private void FTP_ListFAFs(String newDir, Lists l, bool recFiles, bool recFolder) {
            List<FTP_FAF> folder = l.RemoteFolders;
            List<FTP_FAF> files = l.RemoteFiles;

            WebRequest wr = CreateServerWebRequest(newDir);
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
                string fullPath = newDir + "/" + name;
                if("".Equals(newDir)) fullPath = name;

                if(!file && (name.Contains(".svn") || name.Contains(".git"))) continue; //Exclude git and svn dirs

                FTP_FAF newFaf = new FTP_FAF(file, permissions, Convert.ToInt32(filesize), lastModifiedDate, lastModifiedTime, name, fullPath);
                
                if(!file) FTP_ListFAFs(fullPath, l, recFiles, recFolder);
                if (recFiles && file) files.Add(newFaf);
                if (recFolder && !file) folder.Add(newFaf);
            }
            response1.Close();
        }
    }
}