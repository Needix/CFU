// Lists.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;

namespace Custom_FTP_Uploader.ProjectSRC.Model {
    public class Lists { //TODO: Think of a better name for this
        public List<String> RootFiles { get; set; }
        public List<String> RootFolders { get; set; }
        public List<String> RemoteFiles  { get; set; }
        public List<String> RemoteFolders { get; set; }
        public List<String> MissingLocalFiles  { get; set; }
        public List<String> MissingLocalFolders { get; set; }
        public List<String> MissingRemoteFiles  { get; set; }
        public List<String> MissingRemoteFolders { get; set; }
    }
}