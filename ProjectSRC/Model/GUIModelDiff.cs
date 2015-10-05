// GUIModel.Diff.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.Model {
    public class GUIModelDiff {
        public int LocalMissingFAFsSelectedIndex { get; set; }
        public int RemoteMissingFAFsSelectedIndex { get; set; }

        [XmlArray("FilesToDownload")]
        [XmlArrayItem("FileToDownload")]
        public List<FTP_FAF> FilesToDownload { get; set; }
        public int FilesToDownloadSelectedIndex { get; set; }

        [XmlArray("FilesToUpload")]
        [XmlArrayItem("FileToUpload")]
        public List<FAF> FilesToUpload { get; set; }
        public int FilesToUploadSelectedIndex { get; set; }

        [XmlIgnore]
        public Lists CurrentLists { get; set; }

        public GUIModelDiff() {
            FilesToDownload = new List<FTP_FAF>();
            FilesToUpload = new List<FAF>();
        }
    }
}