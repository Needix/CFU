// GUIView.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.Controller;
using Custom_FTP_Uploader.ProjectSRC.Model;

namespace Custom_FTP_Uploader.ProjectSRC.GUI {
    public partial class GUIView :Form {
        private GUIController _controller;

        public GUIView() {
            InitializeComponent();
        }

        private void RegisterCustomEvents() {
            b_edit.Click += _controller.EditAddon;
            b_new.Click += _controller.NewAddon;
            b_delete.Click += _controller.DelAddon;

            b_sync_localServer.Click += _controller.SyncLocalServer;
            b_sync_serverLocal.Click += _controller.SyncServerLocal;
            b_checkStatus.Click += _controller.Check;

            b_save.Click += _controller.Serializer.Save;
            b_load.Click += _controller.Serializer.Load;
            b_resetToDefault.Click += _controller.Serializer.Reset;

            tb_addonInfo_name.TextChanged += _controller.TB_TextChanged;
            tb_addonInfo_dirName.TextChanged += _controller.TB_TextChanged;
            tb_addonInfo_firstUploaded.TextChanged += _controller.TB_TextChanged;
            tb_addonInfo_lastUpdate.TextChanged += _controller.TB_TextChanged;
            cbox_addonInfo_addons_root.SelectedIndexChanged += _controller.ComboBox_TextChanged;
            cbox_addonInfo_fastdl_workshop.SelectedIndexChanged += _controller.ComboBox_TextChanged;

            listView_addonList.SelectedIndexChanged += _controller.ListView_SelectedIndexChanged;
        }

        public void RegisterController(GUIController controller) {
            _controller = controller;
            RegisterCustomEvents();
        }

        public void UpdateView(GUIModel model) {
            UpdateAddonInfo(model);
            UpdateAddonList(model);
        }

        public void UpdateAddonInfo(GUIModel model) {
            tb_addonInfo_dirName.Text = model.CurrentDirectoryName;
            tb_addonInfo_name.Text = model.CurrentAddonName;
            tb_addonInfo_firstUploaded.Text = model.CurrentFirstUploaded;
            tb_addonInfo_lastUpdate.Text = model.CurrentLastUpdated;

            cbox_addonInfo_addons_root.SelectedIndex = (int)model.CurrentAddonType;
            cbox_addonInfo_fastdl_workshop.SelectedIndex = (int)model.CurrentDLType;
        }

        public void UpdateAddonList(GUIModel model) {
            ListView.SelectedIndexCollection selectedItems = listView_addonList.SelectedIndices;
            listView_addonList.Items.Clear();

            foreach(Addon addon in model.AddonList) {
                listView_addonList.Items.Add(addon.ToString());
            }
            if(selectedItems.Count>0) listView_addonList.SelectedIndices.Add(selectedItems[0]);
        }
    }
}
