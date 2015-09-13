// GUIModel.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Custom_FTP_Uploader.ProjectSRC.Model {
    [XmlRoot("GUIModel")]
    //TODO: Add all classes that need to be included here
    //[XmlInclude(typeof(SomeModel)), XmlInclude(typeof(SomeClass))] // include classes, that are serialized here
    public class GUIModel {
        //TODO: Add fields that needs to be serialized
        //Add fields normally like so:
        //  public int SomeInt { get; set; }

        //Add Lists like so:
        //  [XmlArray("SomeUberName")]
        //  [XmlArrayItem("SomeSubName")]
        //  public List<SomeClass> AllSomething { get; set; } 


        public List<Addon> AddonList { get; set; } 

        public String AddonName { get; set; }
        public String DirectoryName { get; set; }
        public String FirstUploaded { get; set; }
        public String LastUpdated { get; set; }
        public Addon.AddonType AType { get; set; }
        public Addon.DownloadType DLType { get; set; }

        public GUIModel() {
            AddonList = new List<Addon>();
            AddonName = "";
            DirectoryName = "";
            FirstUploaded = "";
            LastUpdated = "";
            AType = Addon.AddonType.NotSelected;
            DLType = Addon.DownloadType.NotSelected;
        }
    }
}