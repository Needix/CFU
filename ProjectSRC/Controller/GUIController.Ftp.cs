// GUIController.Ftp.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Net;

namespace Custom_FTP_Uploader.ProjectSRC.Controller {
    public partial class GUIController {
        private WebClient CreateServerWebClient() {
            WebClient result = new WebClient();
            result.Credentials = new NetworkCredential(Model.SettingsModel.Server.Username, Model.SettingsModel.FastDL.GetDecryptedPassword());
            return result;
        }

        private FtpWebRequest CreateServerWebRequest(String relPath) {
            String ip_port = Model.SettingsModel.Server.IP_Port;
            String username = Model.SettingsModel.Server.Username;
            String pw = Model.SettingsModel.FastDL.GetDecryptedPassword();
            return CreateWebRequest(ip_port, username, pw, GMOD_SUB_FOLDER+relPath);
        }
        private FtpWebRequest CreateFastDLWebRequest(String relPath) {
            String ip_port = Model.SettingsModel.FastDL.IP_Port;
            String username = Model.SettingsModel.FastDL.Username;
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
                //Debug.WriteLine("Creating web request: "+webRequestHost);
                FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(webRequestHost);

                if(!"".Equals(username)) ftp.Credentials = new NetworkCredential(username, pw);

                return ftp;
            } catch(FormatException) {
                Debug.WriteLine("ERROR: Format exception creating web request for: \""+ip_port+"/"+relativePath+"\" with username/pw \""+username+"\"/\""+pw+"\"");
                return null;
            }
        }
        private String GetServerURI(String relative, bool inclusiveGmodSubFolder = true) {
            if(inclusiveGmodSubFolder)
                return "ftp://"+Model.SettingsModel.Server.IP_Port+"/"+GMOD_SUB_FOLDER+relative;

            return "ftp://"+Model.SettingsModel.Server.IP_Port+"/"+relative;
        }
    }
}