// Lists.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;

namespace Custom_FTP_Uploader.ProjectSRC.Model.HelpModels {
    public class Lists { //TODO: Think of a better name for this
        public List<FAF> RootFAFs { get; set; }
        public List<FTP_FAF> RemoteFAFs { get; set; }

        public List<FTP_FAF> MissingLocalFAFs { get; set; }
        public List<FAF> MissingRemoteFAFs { get; set; } 
    }
}