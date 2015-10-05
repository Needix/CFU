// GUIController.ViewEvents.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using Custom_FTP_Uploader.ProjectSRC.Model;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.Controller.GUIMain {
    public partial class GUIMainController {
        public void NewAddon(object sender, EventArgs e) {
            Addon addon = Model.CreateAddonFromModel();
            if(addon == null) return;
            Model.AddonList.Add(addon);
            View.UpdateAddonList(Model);
        }
        public void EditAddon(object sender, EventArgs e) {
            if(Model.SelectedAddonIndex == -1 || Model.SelectedAddonIndex >= Model.AddonList.Count) return;
            Model.AddonList[Model.SelectedAddonIndex] = Model.CreateAddonFromModel();
            View.UpdateAddonList(Model);
        }
        public void DelAddon(object sender, EventArgs e) {
            if(Model.SelectedAddonIndex == -1 || Model.SelectedAddonIndex >= Model.AddonList.Count) return;
            Model.AddonList.RemoveAt(Model.SelectedAddonIndex);
            View.UpdateAddonList(Model);
        }
         
    }
}