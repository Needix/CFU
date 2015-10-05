using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.Controller;
using Custom_FTP_Uploader.ProjectSRC.Controller.GUIDiff;
using Custom_FTP_Uploader.ProjectSRC.Model;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.GUI {
    public partial class GUIDiffView : Form {
        public GUIDiffController Controller { get; private set; }

        public GUIDiffView(GUIModelDiff model) {
            InitializeComponent();

            Controller = new GUIDiffController(this, model);

            RegisterCustomEvents();
        }

        private void RegisterCustomEvents() {
            b_showDiff_local_add.Click += Controller.ShowDiff_ButtonClick;
            b_showDiff_local_remove.Click += Controller.ShowDiff_ButtonClick;
            b_showDiff_local_download.Click += Controller.ShowDiff_ButtonClick;
            b_showDiff_remote_add.Click += Controller.ShowDiff_ButtonClick;
            b_showDiff_remote_remove.Click += Controller.ShowDiff_ButtonClick;
            b_showDiff_remote_upload.Click += Controller.ShowDiff_ButtonClick;

            listBox_showDiff_local_missingFiles.SelectedIndexChanged += Controller.ShowDiff_ListSelectedIndexChanged;
            listBox_showDiff_local_filesToDownload.SelectedIndexChanged += Controller.ShowDiff_ListSelectedIndexChanged;
            listBox_showDiff_remote_filesToUpload.SelectedIndexChanged += Controller.ShowDiff_ListSelectedIndexChanged;
            listBox_showDiff_remote_missingFiles.SelectedIndexChanged += Controller.ShowDiff_ListSelectedIndexChanged;
        }

        public void UpdateLists(GUIModelDiff model) {
            //Local Missing
            listBox_showDiff_local_missingFiles.Items.Clear();
            foreach(FTP_FAF missingFAF in model.CurrentLists.MissingLocalFAFs) {
                listBox_showDiff_local_missingFiles.Items.Add(missingFAF.RelativePath);
            }

            //Remote Missing
            listBox_showDiff_remote_missingFiles.Items.Clear();
            foreach(FAF missingFAF in model.CurrentLists.MissingRemoteFAFs) {
                listBox_showDiff_remote_missingFiles.Items.Add(missingFAF.Name);
            }

            //Local to download
            listBox_showDiff_local_filesToDownload.Items.Clear();
            foreach (FTP_FAF s in model.FilesToDownload) {
                listBox_showDiff_local_filesToDownload.Items.Add(s.RelativePath);
            }

            //Remote to upload
            listBox_showDiff_remote_filesToUpload.Items.Clear();
            foreach (FAF s in model.FilesToUpload) {
                listBox_showDiff_remote_filesToUpload.Items.Add(s.Name);
            }
        }
    }
}
