// Addon.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;

namespace Custom_FTP_Uploader.ProjectSRC.Model {
    public class Addon {
        public enum DownloadType {
            NotSelected,
            FastDL,
            Workshop,
        }

        public enum AddonType {
            NotSelected,
            Addons,
            Root,
        }

        public String Name { get; set; }
        public String DirectoryName { get; set; }
        public String FirstUploaded { get; set; }
        public String LastUpdated { get; set; }
        public AddonType AType { get; set; }
        public DownloadType DLType { get; set; }

        public Addon() : this("", "", "", "", AddonType.NotSelected, DownloadType.NotSelected) { }

        public Addon(String name, String dirName, String firstUploaded, String lastUpdated, AddonType aType, DownloadType dlType) {
            Name = name;
            DirectoryName = dirName;
            FirstUploaded = firstUploaded;
            LastUpdated = lastUpdated;
            AType = aType;
            DLType = dlType;
        }
    }
}