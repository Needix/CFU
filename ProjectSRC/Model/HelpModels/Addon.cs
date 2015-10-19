// Addon.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Custom_FTP_Uploader.ProjectSRC.Model.HelpModels {
    public class Addon {
        public enum DownloadType {
            FastDL = 0,
            Workshop = 1,
        }

        public enum AddonType {
            Addons = 0,
            Root = 1,
        }

        public String Name { get; set; }
        public String DirectoryName { get; set; }
        public String FirstUploaded { get; set; }
        public String LastUpdated { get; set; }
        public String Version { get; set; }
        public AddonType AType { get; set; }
        public DownloadType DLType { get; set; }
        [XmlArray("FAFList")]
        [XmlArrayItem("FAF")]
        public List<FAF> FAFList { get; set; }

        public Addon() : this("Serialized Addon Name", "Serialized Directory Name", "Serialized First Uploaded", "Serialized Last Updated", "Serialized Version", AddonType.Addons, DownloadType.FastDL, new List<FAF>()) { }

        public Addon(String name, String dirName, String firstUploaded, String lastUpdated, String version, AddonType aType, DownloadType dlType, List<FAF> fafList) {
            Name = name;
            DirectoryName = dirName;
            FirstUploaded = firstUploaded;
            LastUpdated = lastUpdated;
            Version = version;
            AType = aType;
            DLType = dlType;
            FAFList = fafList;

            if("".Equals(name)) 
                throw new ArgumentException("Addon name is not allowed to be empty!");

            if(!DirectoryName.Equals("Serialized Directory Name") && !Regex.IsMatch(DirectoryName, @"^[a-z0-9_]*$")) 
                throw new ArgumentException("Directory name has some invalid characters!");
        }

        public override string ToString() {
            return string.Format("{0}", Name);
        }
    }
}