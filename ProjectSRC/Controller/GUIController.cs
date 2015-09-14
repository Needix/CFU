// GUIController.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.GUI;
using Custom_FTP_Uploader.ProjectSRC.Model;

namespace Custom_FTP_Uploader.ProjectSRC.Controller {
    public class GUIController {
        private GUIModel _model;
        public GUIModel Model {
            get { return _model; }
            set {
                if(value == null) return;
                _model = value;

            }
        }

        public GUIView View { get; set; }

        public Serializer Serializer { get; private set; }

        public GUIController(GUIView view) {
            Serializer = new Serializer(this);
            Model = Serializer.Deserialize();
            if(Model == null) Model = new GUIModel();

            View = view;
            View.UpdateView(Model);
        }

        public void NewAddon(object sender, EventArgs e) {
            Addon addon = Model.CreateAddonFromModel();
            if (addon == null) return;
            Model.AddonList.Add(addon);
            View.UpdateAddonList(Model);
        }
        public void EditAddon(object sender, EventArgs e) {
            if (Model.SelectedAddonIndex == -1 || Model.SelectedAddonIndex >= Model.AddonList.Count) return;
            Model.AddonList[Model.SelectedAddonIndex] = Model.CreateAddonFromModel();
            View.UpdateAddonList(Model);
        }
        public void DelAddon(object sender, EventArgs e) {
            if(Model.SelectedAddonIndex == -1 || Model.SelectedAddonIndex >= Model.AddonList.Count) return;
            Model.AddonList.RemoveAt(Model.SelectedAddonIndex);
            View.UpdateAddonList(Model);
        }
        public void SyncLocalServer(object sender, EventArgs e) {

        }
        public void SyncServerLocal(object sender, EventArgs e) {

        }
        public void Check(object sender, EventArgs e) {

        }

        public void TB_TextChanged(object sender, EventArgs e) {
            TextBox tb = (TextBox) sender;
            String tbText = tb.Text;
            switch (tb.Name) {
                case "tb_addonInfo_name":
                    Model.CurrentAddonName = tbText;
                    break;
                case "tb_addonInfo_dirName":
                    Model.CurrentDirectoryName = tbText;
                    break;
                case "tb_addonInfo_firstUploaded":
                    Model.CurrentFirstUploaded = tbText;
                    break;
                case "tb_addonInfo_lastUpdate":
                    Model.CurrentLastUpdated = tbText;
                    break;
                default:
                    Debug.WriteLine("WARNING: Could not find model variable for textbox: "+tb.Name);
                    break;
            }
        }
        public void ComboBox_TextChanged(object sender, EventArgs e) {
            ComboBox cbox = (ComboBox) sender;
            switch (cbox.Name) {
                case "cbox_addonInfo_addons_root":
                    Model.CurrentAddonType = (Addon.AddonType)cbox.SelectedIndex;
                    break;
                case "cbox_addonInfo_fastdl_workshop":
                    Model.CurrentDLType = (Addon.DownloadType)cbox.SelectedIndex;
                    break;
                default:
                    Debug.WriteLine("WARNING: Could not find model variable for combobox: "+cbox.Name);
                    break;
            }
        }

        public void ListView_SelectedIndexChanged(object sender, EventArgs e) {
            ListView lw = (ListView) sender;
            if (lw.SelectedIndices.Count == 0) Model.SelectedAddonIndex = -1;
            else Model.SelectedAddonIndex = lw.SelectedIndices[0];

            Model.UpdateVarsFromSelectedAddon();
            View.UpdateAddonInfo(Model);
        }
    }
}