// GUIModel.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Custom_FTP_Uploader.ProjectSRC.Model {
    [XmlRoot("GUIModel")]
    //TODO: Add all classes that need to be included here
    //[XmlInclude(typeof(SomeModel)), XmlInclude(typeof(SomeClass))] // include classes, that are serialized here
    public class GUIModel {
        //TODO: Add fields that needs to be serialized
        //Add fields normally like so:
        //  public int SomeInt { get; set; }

        [XmlArray("Addons")]
        [XmlArrayItem("Addon")]
        public List<Addon> AddonList { get; set; }

        public int SelectedAddonIndex { get; set; }

        public String CurrentAddonName { get; set; }
        public String CurrentDirectoryName { get; set; }
        public String CurrentFirstUploaded { get; set; }
        public String CurrentLastUpdated { get; set; }
        public Addon.AddonType CurrentAddonType { get; set; }
        public Addon.DownloadType CurrentDLType { get; set; }

        public GUIModel() {
            AddonList = new List<Addon>();
            SelectedAddonIndex = -1;

            CurrentAddonName = "";
            CurrentDirectoryName = "";
            CurrentFirstUploaded = "";
            CurrentLastUpdated = "";
            CurrentAddonType = Addon.AddonType.NotSelected;
            CurrentDLType = Addon.DownloadType.NotSelected;
        }

        public Addon CreateAddonFromModel() {
            try {
                return new Addon(CurrentAddonName, CurrentDirectoryName, CurrentFirstUploaded, CurrentLastUpdated, CurrentAddonType, CurrentDLType);
            } catch (ArgumentException ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void UpdateVarsFromSelectedAddon() {
            if (SelectedAddonIndex == -1 || SelectedAddonIndex >= AddonList.Count) return;
            Addon addon = AddonList[SelectedAddonIndex];
            CurrentAddonName = addon.Name;
            CurrentDirectoryName = addon.DirectoryName;
            CurrentFirstUploaded = addon.FirstUploaded;
            CurrentLastUpdated = addon.LastUpdated;
            CurrentAddonType = addon.AType;
            CurrentDLType = addon.DLType;
        }
    }
}