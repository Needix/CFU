// SettingsModel.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;

namespace Custom_FTP_Uploader.ProjectSRC.Model {
    public class SettingsModel {
        public ServerModel Server { get; set; }
        public ServerModel FastDL { get; set; }

        public Boolean EnableLogging { get; set; }

        public SettingsModel() {
            Server = new ServerModel();
            FastDL = new ServerModel();

            EnableLogging = true;
        }

    }
}