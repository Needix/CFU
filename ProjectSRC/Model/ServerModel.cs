// ServerModel.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Custom_FTP_Uploader.ProjectSRC.Model {
    public class ServerModel {
        [XmlIgnore]
        private readonly SimpleAES _aes = new SimpleAES();

        public String IP_Port { get; set; }
        public String Username { get; set; }

        private String _password;
        public String Password {
            get { return _password; }
            set { _password = value; }
        }
        public void SetEncryptedPassword(String pwPlain) { _password = EncryptPassword(pwPlain); }
        public String GetDecryptedPassword() { return DecryptPassword(_password); }

        public ServerModel() : this("Serialized IP:Port", "Serialized username", "Serialized password") { }
        public ServerModel(String ipPort, String username, String pw) {
            IP_Port = ipPort;
            Username = username;
            Password = pw;
        }

        private String EncryptPassword(String pwPlain) {
            return _aes.EncryptToString(pwPlain);
        }

        private String DecryptPassword(String pwEncrypted) {
            return _aes.DecryptString(pwEncrypted);
        }
    }
}