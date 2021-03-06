﻿// GUIView.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.Controller;
using Custom_FTP_Uploader.ProjectSRC.Controller.GUIMain;
using Custom_FTP_Uploader.ProjectSRC.Model;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.GUI {
    public partial class GUIMainView :Form {
        private GUIMainController _controller;

        private GUIDiffView _diffView;

        public GUIMainView() {
            InitializeComponent();

        }

        private void RegisterCustomEvents() {
            b_addonInfo_edit.Click += _controller.EditAddon;
            b_addonInfo_new.Click += _controller.NewAddon;
            b_addonInfo_delete.Click += _controller.DelAddon;
            b_addonInfo_refreshFileList.Click += _controller.RefreshFileList;

            b_sync_localServer.Click += _controller.SyncLocalServer;
            b_sync_serverLocal.Click += _controller.SyncServerLocal;
            b_sync_checkStatus.Click += _controller.Check;

            b_settings_save.Click += _controller.Serializer.Save;
            b_settings_load.Click += _controller.Serializer.Load;
            b_settings_resetToDefault.Click += _controller.Serializer.Reset;

            tb_addonInfo_name.TextChanged += _controller.TB_TextChanged;
            tb_addonInfo_dirName.TextChanged += _controller.TB_TextChanged;
            tb_addonInfo_firstUploaded.TextChanged += _controller.TB_TextChanged;
            tb_addonInfo_lastUpdate.TextChanged += _controller.TB_TextChanged;
            tb_addonInfo_version.TextChanged += _controller.TB_TextChanged;
            tb_settings_fastDL_ipPort.TextChanged += _controller.TB_TextChanged;
            tb_settings_fastDL_password.TextChanged += _controller.TB_TextChanged;
            tb_settings_fastDL_username.TextChanged += _controller.TB_TextChanged;
            tb_settings_server_ipPort.TextChanged += _controller.TB_TextChanged;
            tb_settings_server_password.TextChanged += _controller.TB_TextChanged;
            tb_settings_server_username.TextChanged += _controller.TB_TextChanged;

            cbox_addonInfo_addons_root.SelectedIndexChanged += _controller.ComboBox_TextChanged;
            cbox_addonInfo_fastdl_workshop.SelectedIndexChanged += _controller.ComboBox_TextChanged;

            checkBox_settings_enableLog.CheckedChanged += _controller.CheckBox_CheckChanged; //TODO: Make log invisible when disabled?

            listView_addonList.SelectedIndexChanged += _controller.ListView_SelectedIndexChanged;
        }
        
        public void RegisterController(GUIMainController controller) {
            _controller = controller;
            _diffView = new GUIDiffView(_controller.Model.DiffModel, controller);
            RegisterCustomEvents();
        }

        public void UpdateView(GUIModel model) {
            UpdateAddonInfo(model);
            UpdateAddonList(model);
            UpdateSettings(model.SettingsModel);
        }

        public void UpdateSettings(SettingsModel model) {
            tb_settings_fastDL_username.Text = model.FastDL.Username;
            tb_settings_fastDL_ipPort.Text = model.FastDL.IP_Port;
            tb_settings_fastDL_password.Text = model.FastDL.GetDecryptedPassword();
            tb_settings_server_ipPort.Text = model.Server.IP_Port;
            tb_settings_server_username.Text = model.Server.Username;
            tb_settings_server_password.Text = model.Server.GetDecryptedPassword();
        }

        public void UpdateAddonInfo(GUIModel model) {
            tb_addonInfo_dirName.Text = model.CurrentDirectoryName;
            tb_addonInfo_name.Text = model.CurrentAddonName;
            tb_addonInfo_firstUploaded.Text = model.CurrentFirstUploaded;
            tb_addonInfo_lastUpdate.Text = model.CurrentLastUpdated;
            tb_addonInfo_version.Text = model.CurrentVersion;

            listBox_addonInfo_files.Items.Clear();
            foreach (FAF faf in model.CurrentFileList) {
                listBox_addonInfo_files.Items.Add(faf.Name.Substring(faf.Name.IndexOf(GUIMainController.GMOD_SUB_FOLDER))); 
            }

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

        public void ShowDiff(Boolean show, Lists l, GUIModelDiff model) {
            model.CurrentLists = l;
            _diffView.UpdateLists(model);
            _diffView.Visible = show;
        }
    }
}
