// GUIModel.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.Model {
    [XmlRoot("GUIModel")]
    [XmlInclude(typeof(SettingsModel)), XmlInclude(typeof(ServerModel)), ] 
    public class GUIModel {
        [XmlArray("Addons")]
        [XmlArrayItem("Addon")]
        public List<Addon> AddonList { get; set; }
        public int SelectedAddonIndex { get; set; }

        [XmlIgnore]
        public String CurrentAddonName { get; set; }
        [XmlIgnore]
        public String CurrentDirectoryName { get; set; }
        [XmlIgnore]
        public String CurrentFirstUploaded { get; set; }
        [XmlIgnore]
        public String CurrentLastUpdated { get; set; }
        [XmlIgnore]
        public String CurrentVersion { get; set; }
        [XmlIgnore]
        public List<FAF> CurrentFileList { get; set; }
        [XmlIgnore]
        public Addon.AddonType CurrentAddonType { get; set; }
        [XmlIgnore]
        public Addon.DownloadType CurrentDLType { get; set; }

        public GUIModelDiff DiffModel { get; set; }

        public SettingsModel SettingsModel { get; set; }

        public GUIModel() {
            SettingsModel = new SettingsModel();

            DiffModel = new GUIModelDiff();

            AddonList = new List<Addon>();
            SelectedAddonIndex = -1;

            CurrentAddonName = "";
            CurrentDirectoryName = "";
            CurrentFirstUploaded = "";
            CurrentLastUpdated = "";
            CurrentVersion = "";
            CurrentAddonType = Addon.AddonType.Addons;
            CurrentDLType = Addon.DownloadType.FastDL;

            CurrentFileList = new List<FAF>();
        }

        public Addon CreateAddonFromModel(List<FAF> fafList) {
            try {
                return new Addon(CurrentAddonName, CurrentDirectoryName, CurrentFirstUploaded, CurrentLastUpdated, CurrentVersion, CurrentAddonType, CurrentDLType, fafList);
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
            CurrentFileList = addon.FAFList;
            CurrentVersion = addon.Version;
        }
    }
}