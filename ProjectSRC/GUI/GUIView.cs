// GUIView.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.Controller;
using Custom_FTP_Uploader.ProjectSRC.Model;

namespace Custom_FTP_Uploader.ProjectSRC.GUI {
    public partial class GUIView :Form {
        private GUIController _controller;

        public GUIView() {
            InitializeComponent();
            RegisterCustomEvents();
        }

        private void RegisterCustomEvents() {
            b_add.Click += _controller.AddAddon;
            b_new.Click += _controller.NewAddon;
            b_delete.Click += _controller.DelAddon;
            b_sync_localServer.Click += _controller.SyncLocalServer;
            b_sync_serverLocal.Click += _controller.SyncServerLocal;
            b_checkStatus.Click += _controller.Check;
        }

        public void RegisterController(GUIController controller) { _controller = controller; }

        public void UpdateView(GUIModel model) {
            tb_addonInfo_dirName.Text = model.DirectoryName;
            tb_addonInfo_name.Text = model.AddonName;
            tb_addonInfo_firstUploaded.Text = model.FirstUploaded;
            tb_addonInfo_lastUpdate.Text = model.LastUpdated;

            cbox_addonInfo_addons_root.SelectedIndex = (int)model.AType;
            cbox_addonInfo_fastdl_workshop.SelectedIndex = (int) model.DLType;
        }
    }
}
