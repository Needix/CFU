// MissingFAF.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;

namespace Custom_FTP_Uploader.ProjectSRC.Model.HelpModels {
    public class FAF {
        public bool File { get; set; }
        public String Name { get; set; }

        public FAF() { }

        public FAF(bool file, String name) {
            File = file;
            Name = name;
        }

        public override string ToString() {
            return Name;
        }
    }
}