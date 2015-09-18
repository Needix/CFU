// FTP_FAF.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;

namespace Custom_FTP_Uploader.ProjectSRC.Model {
    public class FTP_FAF {
        public bool File { get; private set; }
        public string Permissions { get; private set; }
        public int Filesize { get; private set; }
        public string LastModifiedDate { get; private set; }
        public string LastModifiedTime { get; private set; }
        public string Name { get; private set; }
        public string RelativePath { get; private set; }

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