// Addon.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Text.RegularExpressions;

namespace Custom_FTP_Uploader.ProjectSRC.Model.HelpModels {
    public class Addon {
        public enum DownloadType {
            FastDL = 1,
            Workshop = 2,
        }

        public enum AddonType {
            Addons = 1,
            Root = 2,
        }

        public String Name { get; set; }
        public String DirectoryName { get; set; }
        public String FirstUploaded { get; set; }
        public String LastUpdated { get; set; }
        public AddonType AType { get; set; }
        public DownloadType DLType { get; set; }

        public Addon() : this("Serialized Addon Name", "Serialized Directory Name", "Serialized First Uploaded", "Serialized Last Updated", AddonType.Addons, DownloadType.FastDL) { }

        public Addon(String name, String dirName, String firstUploaded, String lastUpdated, AddonType aType, DownloadType dlType) {
            Name = name;
            DirectoryName = dirName;
            FirstUploaded = firstUploaded;
            LastUpdated = lastUpdated;
            AType = aType;
            DLType = dlType;

            if("".Equals(name)) throw new ArgumentException("Addon name is not allowed to be empty!");
            if(new Regex("^[a-z0-9_]*$").IsMatch(DirectoryName)) throw new ArgumentException("Directory name has some invalid characters!");
        }

        public override string ToString() {
            return string.Format("{0}", Name);
        }
    }
}