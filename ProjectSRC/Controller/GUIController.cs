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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.GUI;
using Custom_FTP_Uploader.ProjectSRC.Model;

namespace Custom_FTP_Uploader.ProjectSRC.Controller {
    public class GUIController { //INFO: 
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

        public void NewAddon(object sender, EventArgs e) {
            Addon addon = Model.CreateAddonFromModel();
            if (addon == null) return;
            Model.AddonList.Add(addon);
            View.UpdateAddonList(Model);
        }
        public void EditAddon(object sender, EventArgs e) {
            if (Model.SelectedAddonIndex == -1 || Model.SelectedAddonIndex >= Model.AddonList.Count) return;
            Model.AddonList[Model.SelectedAddonIndex] = Model.CreateAddonFromModel();
            View.UpdateAddonList(Model);
        }
        public void DelAddon(object sender, EventArgs e) {
            if(Model.SelectedAddonIndex == -1 || Model.SelectedAddonIndex >= Model.AddonList.Count) return;
            Model.AddonList.RemoveAt(Model.SelectedAddonIndex);
            View.UpdateAddonList(Model);
        }

        //INFO: dreistetraitor/programm.exe
        //INFO: dreistetraitor/serverdata/garrysmod/addons
        public void SyncLocalServer(object sender, EventArgs e) {
            List<String> list = new List<string>();
            string garrysModBase = "R:\\Other\\TestFTPServer\\serverdata\\garrysmod"; //TODO: Transform into const/relative path on release
            IterateFolderRekursive(garrysModBase, list, true, true);

            List<String> relPaths = new List<String>();
            List<String> filesAndFolder = new List<string>();
            relPaths.Add("");
            FTP_ListFAFs(relPaths, filesAndFolder, true, true);
        }
        public void SyncServerLocal(object sender, EventArgs e) {
            List<String> list = new List<string>();
            string garrysModBase = "R:\\Other\\TestFTPServer\\serverdata\\garrysmod"; //TODO: Transform into const/relative path on release
            IterateFolderRekursive(garrysModBase, list, true, true);

            List<String> relPaths = new List<String>();
            List<String> filesAndFolder = new List<string>();
            relPaths.Add("");
            FTP_ListFAFs(relPaths, filesAndFolder, true, true);
        }

        private void IterateFolderRekursive(String baseFolder, List<String> list, bool recFiles, bool recFolder) {
            if (!recFolder && !recFiles) return;
            String[] folders = Directory.GetDirectories(baseFolder);
            String[] files = Directory.GetFiles(baseFolder);
            if (recFiles) {
                foreach (string file in files) {
                    if (File.Exists(file)) list.Add(file);
                }
            }

            if (recFolder) {
                foreach (string folder in folders) {
                    if (Directory.Exists(folder)) {
                        list.Add(folder);
                        IterateFolderRekursive(folder, list, recFiles, true);
                    }
                }
            }
        }

        public void Check(object sender, EventArgs e) {
            List<String> relPaths = new List<String>();
            List<String> filesAndFolder = new List<string>();
            relPaths.Add("");
            FTP_ListFAFs(relPaths, filesAndFolder, true, true);

            Debug.WriteLine("Finished reading...");
        }

        private void FTP_ListFAFs(List<String> relPaths, List<String> filesAndFolder, bool recFiles, bool recFolder) {
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
                    string fullPath = relPath + "/" + name + "/";

                    if(recFiles && file) filesAndFolder.Add(fullPath);
                    if(recFolder && !file) filesAndFolder.Add(fullPath);
                    if(!file) dirList.Add(fullPath);
                }
                response1.Close();

                FTP_ListFAFs(dirList, filesAndFolder, recFiles, recFolder);
            }
        }

        private FtpWebRequest CreateServerWebRequest(String relPath) {
            String ip_port = Model.SettingsModel.FastDL.IP_Port;
            String username = Model.SettingsModel.FastDL.Username;
            String pw = Model.SettingsModel.FastDL.GetDecryptedPassword();
            return CreateWebRequest(ip_port, username, pw, "serverdata/garrysmod/"+relPath);
        }
        private FtpWebRequest CreateFastDLWebRequest(String relPath) {
            String ip_port = Model.SettingsModel.Server.IP_Port;
            String username = Model.SettingsModel.Server.Username;
            String pw = Model.SettingsModel.Server.GetDecryptedPassword();
            return CreateWebRequest(ip_port, username, pw, relPath);
        }
        private FtpWebRequest CreateWebRequest(String ip_port, String username, String pw, String relativePath = "") {
            String[] split = ip_port.Split(':');
            if(split.Length>2) return null;
            try {
                String ip = split[0];
                int port = 21;
                if(split.Length==2) port = Convert.ToInt32(split[1]);

                string webRequestHost = "ftp://" + ip + ":" + port + "/" + relativePath;
                Debug.WriteLine("Creating web request: "+webRequestHost);
                FtpWebRequest ftp = (FtpWebRequest) WebRequest.Create(webRequestHost);

                if (!"".Equals(username))   ftp.Credentials = new NetworkCredential(username, pw);

                return ftp;
            } catch (FormatException) {
                Debug.WriteLine("ERROR: Format exception creating web request for: "+ip_port+"/"+relativePath+" with username/pw "+username+"/"+pw);
                return null;
            }
        }

        public void TB_TextChanged(object sender, EventArgs e) {
            TextBox tb = (TextBox)sender;
            String tbText = tb.Text;
            switch(tb.Name) {
                case "tb_addonInfo_name":
                    Model.CurrentAddonName = tbText;
                    break;
                case "tb_addonInfo_dirName":
                    Model.CurrentDirectoryName = tbText;
                    break;
                case "tb_addonInfo_firstUploaded":
                    Model.CurrentFirstUploaded = tbText;
                    break;
                case "tb_addonInfo_lastUpdate":
                    Model.CurrentLastUpdated = tbText;
                    break;

                case "tb_settings_fastDL_ipPort":
                    Model.SettingsModel.FastDL.IP_Port = tbText;
                    break;
                case "tb_settings_fastDL_username":
                    Model.SettingsModel.FastDL.Username = tbText;
                    break;
                case "tb_settings_fastDL_password":
                    Model.SettingsModel.FastDL.SetEncryptedPassword(tbText);
                    break;

                case "tb_settings_server_ipPort":
                    Model.SettingsModel.Server.IP_Port = tbText;
                    break;
                case "tb_settings_server_username":
                    Model.SettingsModel.Server.Username = tbText;
                    break;
                case "tb_settings_server_password":
                    Model.SettingsModel.Server.SetEncryptedPassword(tbText);
                    break;

                default:
                    Debug.WriteLine("WARNING: Could not find model variable for textbox: "+tb.Name);
                    break;
            }
        }
        public void ComboBox_TextChanged(object sender, EventArgs e) {
            ComboBox cbox = (ComboBox)sender;
            switch(cbox.Name) {
                case "cbox_addonInfo_addons_root":
                    Model.CurrentAddonType = (Addon.AddonType)cbox.SelectedIndex;
                    break;
                case "cbox_addonInfo_fastdl_workshop":
                    Model.CurrentDLType = (Addon.DownloadType)cbox.SelectedIndex;
                    break;
                default:
                    Debug.WriteLine("WARNING: Could not find model variable for combobox: "+cbox.Name);
                    break;
            }
        }
        public void ListView_SelectedIndexChanged(object sender, EventArgs e) {
            ListView lw = (ListView)sender;
            if(lw.SelectedIndices.Count == 0) Model.SelectedAddonIndex = -1;
            else Model.SelectedAddonIndex = lw.SelectedIndices[0];

            Model.UpdateVarsFromSelectedAddon();
            View.UpdateAddonInfo(Model);
        }
    }
}