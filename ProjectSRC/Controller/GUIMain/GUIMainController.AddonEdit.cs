// GUIController.ViewEvents.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Custom_FTP_Uploader.ProjectSRC.Model;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.Controller.GUIMain {
    public partial class GUIMainController {
        public void NewAddon(object sender, EventArgs e) {
            List<FAF> fafList = CreateFAFList();
            if(fafList == null) return;

            Addon addon = Model.CreateAddonFromModel(fafList);
            if(addon == null) return;

            Model.AddonList.Add(addon);
            View.UpdateAddonList(Model);
            View.UpdateAddonInfo(Model);
        }
        public void EditAddon(object sender, EventArgs e) {
            if(Model.SelectedAddonIndex == -1 || Model.SelectedAddonIndex >= Model.AddonList.Count) return;

            List<FAF> fafList = CreateFAFList();
            if(fafList == null) return;

            Model.AddonList[Model.SelectedAddonIndex] = Model.CreateAddonFromModel(fafList);
            View.UpdateAddonList(Model);
            View.UpdateAddonInfo(Model);
        }
        public void DelAddon(object sender, EventArgs e) {
            if(Model.SelectedAddonIndex == -1 || Model.SelectedAddonIndex >= Model.AddonList.Count) return;

            Model.AddonList.RemoveAt(Model.SelectedAddonIndex);
            View.UpdateAddonList(Model);
            View.UpdateAddonInfo(Model);
        }

        public void RefreshFileList(object sender, EventArgs e) {
            List<FAF> fafs = CreateFAFList();
            Model.CurrentFileList = fafs;
            View.UpdateAddonInfo(Model);
        }

        private List<FAF> CreateFAFList() {
            String dirName = Model.CurrentDirectoryName;
            String relPath = GMOD_ROOT + "addons/" + dirName;
            if (!Directory.Exists(relPath)) {
                View.AddErrorInfo("Could not find path: "+relPath);
                return null;
            }
            List<FAF> fafList = new List<FAF>();
            RekFindFAFs(relPath, fafList);
            return fafList;
        }

        private void RekFindFAFs(string curPath, List<FAF> fafList) {
            String[] dirs = Directory.GetDirectories(curPath);
            String[] files = Directory.GetFiles(curPath);
            foreach(string curFile in files) {
                if (curFile.Contains(".git") || curFile.Contains(".svn")) continue;
                fafList.Add(new FAF(true, curFile));
            }
            foreach(string curDir in dirs) {
                if(curDir.Contains(".git") || curDir.Contains(".svn")) continue;
                fafList.Add(new FAF(false, curDir));
                RekFindFAFs(curDir, fafList);
            }
        }
    }
}