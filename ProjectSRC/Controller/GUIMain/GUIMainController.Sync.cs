// GUIController.Sync.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.Controller.GUIMain {
    public partial class GUIMainController {
        //INFO: dreistetraitor/programm.exe
        //INFO: dreistetraitor/serverdata/garrysmod/addons
        public void SyncLocalServer(object sender, EventArgs e) {
            Lists l = new Lists();
            CalculateLists(l);

            WebClient client = CreateServerWebClient();
            foreach(FTP_FAF missingLocalFaF in l.MissingLocalFAFs) {
                if(missingLocalFaF.File) {
                    FtpWebRequest ftp = CreateServerWebRequest(missingLocalFaF.RelativePath);
                    View.AddInfo("Deleting file from ftp: " + ftp.RequestUri);
                    Debug.WriteLine("Deleting file from ftp: " + ftp.RequestUri);
                    ftp.Method = WebRequestMethods.Ftp.DeleteFile;
                    ftp.GetResponse().Close();
                }
            }
            foreach(FTP_FAF missingLocalFaF in l.MissingLocalFAFs) {
                if(!missingLocalFaF.File) {
                    FtpWebRequest ftp = CreateServerWebRequest(missingLocalFaF.RelativePath);
                    View.AddInfo("Deleting folder from ftp: "+ftp.RequestUri);
                    Debug.WriteLine("Deleting folder from ftp: "+ftp.RequestUri);
                    ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
                    ftp.GetResponse().Close();
                    //try { } catch(WebException ex) { View.AddWarningInfo("Could not delete folder from ftp: "+ex.InnerException.); }
                }
            }

            foreach(FAF missingRemoteFaF in l.MissingRemoteFAFs) {
                if(!missingRemoteFaF.File) {
                    string newFolder = GMOD_ROOT + missingRemoteFaF.Name;
                    FtpWebRequest ftp = CreateServerWebRequest(missingRemoteFaF.Name+"/");
                    View.AddInfo("Creating missing directory: "+newFolder+" @"+ftp.RequestUri);
                    ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                    ftp.GetResponse().Close();
                }
            }
            foreach(FAF missingRemoteFaF in l.MissingRemoteFAFs) {
                if(missingRemoteFaF.File) {
                    String newFile = GMOD_ROOT + missingRemoteFaF.Name;
                    View.AddInfo("Uploading file: \"" + newFile + "\" and saving in location \"" + GetServerURI(missingRemoteFaF.Name) + "\"");
                    client.UploadFile(GetServerURI(missingRemoteFaF.Name), newFile); //TODO: Implement async upload // Progress bar
                }
            }
            client.Dispose();

            View.AddInfo("Finished syncing!");
        }
        public void SyncServerLocal(object sender, EventArgs e) {
            Lists l = new Lists();
            CalculateLists(l);

            WebClient client = CreateServerWebClient();
            foreach(FAF faf in l.MissingRemoteFAFs) {
                if(faf.File) {
                    string fileToDelete = GMOD_ROOT + faf.Name;
                    View.AddInfo("Deleting file: " + fileToDelete);
                    File.Delete(fileToDelete);
                }
            }

            foreach(FAF faf in l.MissingRemoteFAFs) {
                if(!faf.File) {
                    string folderToDelete = GMOD_ROOT + faf.Name;
                    View.AddInfo("Deleting folder: "+folderToDelete);
                    Directory.Delete(folderToDelete);
                }
            }

            foreach(FTP_FAF faf in l.MissingLocalFAFs) {
                if(!faf.File) {
                    string newFolder = GMOD_ROOT + faf.RelativePath;
                    View.AddInfo("Creating missing directory: "+newFolder);
                    Directory.CreateDirectory(newFolder);
                }
            }
            foreach(FTP_FAF faf in l.MissingLocalFAFs) {
                if(faf.File) {
                    String newFile = GMOD_ROOT + faf.RelativePath;
                    View.AddInfo("Downloading file: \""+faf.RelativePath+"\" and saving in location \""+newFile+"\"");
                    client.DownloadFile(GetServerURI(faf.RelativePath), newFile); //TODO: Implement async download // Progress bar
                }
            }

            client.Dispose();

            View.AddInfo("Finished syncing!");
        }
        public void Check(object sender, EventArgs e) {
            Lists l = new Lists();

            CalculateLists(l);

            View.ShowDiff(true, l, Model.DiffModel);
        }

        private void CalculateLists(Lists l) {
            l.RootFAFs = new List<FAF>();
            l.RemoteFAFs = new List<FTP_FAF>();

            View.AddInfo("Starting to search \""+GMOD_ROOT+"\" recursively... Please wait patiently.");
            Client_ListFAFs(GMOD_ROOT, l, true, true);

            View.AddInfo("Downloading file and folder list from \""+GetServerURI("", false)+"\"... Please wait patiently.");
            FTP_ListFAFs("", l, true, true);

            CompareServerLocal(true, true, l);
            CompareLocalServer(true, true, l);
        }
        private bool CompareServerLocal(bool compareFiles, bool compareFolder, Lists l) {
            if(!compareFiles && !compareFolder) return false;

            List<FAF> rootFAFs = l.RootFAFs;
            List<FTP_FAF> remoteFAFs = l.RemoteFAFs;

            l.MissingLocalFAFs = new List<FTP_FAF>();

            View.AddInfo("Starting to compare remote folder with root folder...");
            foreach(FTP_FAF remoteFaF in remoteFAFs) {
                if(remoteFaF.File && compareFiles) {
                    bool found = false;
                    foreach(FAF rootFile in rootFAFs) {
                        if(rootFile.Name.Equals(remoteFaF.RelativePath)) {
                            found = remoteFaF.Filesize == new FileInfo(GMOD_ROOT+rootFile).Length;
                            break;
                        }
                    }
                    if(!found) {
                        l.MissingLocalFAFs.Add(remoteFaF);
                    }
                } else if(!remoteFaF.File && compareFolder) {
                    bool found = false;
                    foreach(FAF rootFolder in rootFAFs) {
                        if(rootFolder.Name.Equals(remoteFaF.RelativePath)) {
                            found = true;
                            break;
                        }
                    }
                    if(!found) {
                        l.MissingLocalFAFs.Add(remoteFaF);
                    }
                }
            }
            return true;
        }
        private bool CompareLocalServer(bool compareFiles, bool compareFolder, Lists l) {
            if(!compareFiles && !compareFolder) return false;

            List<FAF> rootFAFs = l.RootFAFs;
            List<FTP_FAF> remoteFAFs = l.RemoteFAFs;

            l.MissingRemoteFAFs = new List<FAF>();

            View.AddInfo("Starting to compare root folder with remote folder...");

            foreach(FAF rootFAF in rootFAFs) {
                if(rootFAF.File && compareFiles) {
                    bool found = false;
                    foreach(FTP_FAF remoteFAF in remoteFAFs) {
                        if(rootFAF.Name.Equals(remoteFAF.RelativePath)) {
                            found = remoteFAF.Filesize == new FileInfo(GMOD_ROOT+remoteFAF.RelativePath).Length;
                            break;
                        }
                    }
                    if(!found) {
                        l.MissingRemoteFAFs.Add(rootFAF);
                    }
                } else if(!rootFAF.File && compareFolder) {
                    bool found = false;
                    foreach(FTP_FAF remoteFAF in remoteFAFs) {
                        if(rootFAF.Name.Equals(remoteFAF.RelativePath)) {
                            found = true;
                            break;
                        }
                    }
                    if(!found) {
                        l.MissingRemoteFAFs.Add(rootFAF);
                    }
                }
            }
            return true;
        }

        private void Client_ListFAFs(String baseFolder, Lists l, bool recFiles, bool recFolder) {
            List<FAF> FAFs = l.RootFAFs;

            if(!recFolder && !recFiles) return;
            String[] folders = Directory.GetDirectories(baseFolder);
            String[] files = Directory.GetFiles(baseFolder);
            if(recFiles) {
                foreach(string file in files) {
                    string relative = file.Substring(file.IndexOf(GMOD_SUB_FOLDER) + GMOD_SUB_FOLDER.Length);
                    relative = relative.Replace('\\', '/');
                    if(File.Exists(file)) FAFs.Add(new FAF(true, relative));
                }
            }

            foreach(string folder in folders) {
                if(Directory.Exists(folder)) {
                    if(folder.Contains(".svn") || folder.Contains(".git")) continue; //Exclude git and svn dirs
                    string relative = folder.Substring(folder.IndexOf(GMOD_SUB_FOLDER) + GMOD_SUB_FOLDER.Length);
                    relative = relative.Replace('\\', '/');

                    Client_ListFAFs(folder, l, recFiles, true);

                    if(recFolder) {
                        FAFs.Add(new FAF(false, relative));
                    }
                }
            }
        }
        private void FTP_ListFAFs(String newDir, Lists l, bool recFiles, bool recFolder) { //TODO: Server is creating multiple connection, instead of resuing one
            List<FTP_FAF> FAFs = l.RemoteFAFs;

            WebRequest wr = CreateServerWebRequest(newDir);
            if(wr == null) {
                Debug.WriteLine("ERROR: Could not create server web request!");
                return;
            }
            wr.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            FtpWebResponse response1 = (FtpWebResponse)wr.GetResponse();
            Stream stream = response1.GetResponseStream();
            if(stream == null) {
                Debug.WriteLine("ERROR: Response stream was empty!");
                return;
            }

            StreamReader reader = new StreamReader(stream);
            String line;
            while((line = reader.ReadLine()) != null) {
                Regex regex = new Regex(@"^([d-])([rwxt-]{3}){3}\s+\d{1,}\s+.*?(\d{1,})\s+(\w+\s+\d{1,2}\s+(?:\d{4})?)(\d{1,2}:\d{2})?\s+(.+?)\s?$", // http://stackoverflow.com/questions/1013486/parsing-ftpwebrequests-listdirectorydetails-line
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
                if(recFiles && file) FAFs.Add(newFaf);
                if(recFolder && !file) FAFs.Add(newFaf);
            }
            reader.Close();
            stream.Close();
            wr.GetResponse().Close();
            response1.Close();
        }
    }
}