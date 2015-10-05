// FTP_FAF.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;

namespace Custom_FTP_Uploader.ProjectSRC.Model.HelpModels {
    public class FTP_FAF {
        public bool File { get; set; }
        public string Permissions { get; set; }
        public int Filesize { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedTime { get; set; }
        public string Name { get; set; }
        public string RelativePath { get; set; }

        public FTP_FAF() { }

        public FTP_FAF(bool file, string permissions, int filesize, String lastModDate, String lastModTime, String name, String relPath) {
            File = file;
            Permissions = permissions;
            Filesize = filesize;
            LastModifiedDate = lastModDate;
            LastModifiedTime = LastModifiedTime;
            Name = name;
            RelativePath = relPath;
        }
    }
}