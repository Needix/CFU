// GUIController.ShowDiff.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.GUI;
using Custom_FTP_Uploader.ProjectSRC.Model;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.Controller.GUIDiff {
    public class GUIDiffController {
        private readonly GUIDiffView _view;
        public GUIModelDiff Model { get; private set; }

        public GUIDiffController(GUIDiffView view, GUIModelDiff model) {
            _view = view;
            Model = model;
        }

        public void ShowDiff_ButtonClick(object sender, EventArgs e) {
            Button b = (Button) sender;
            switch (b.Name) {
                case "b_showDiff_local_add":
                    AddLocalFile();
                    break;
                case "b_showDiff_local_remove":
                    RemoveLocalFile();
                    break;
                case "b_showDiff_local_download":
                    DownloadLocalFiles();
                    break;
                case "b_showDiff_remote_add":
                    AddRemoteFile();
                    break;
                case "b_showDiff_remote_remove":
                    RemoveRemoteFile();
                    break;
                case "b_showDiff_remote_upload":
                    UploadRemoteFiles();
                    break;
            }
            _view.UpdateLists(Model);
        }

        public void ShowDiff_ListSelectedIndexChanged(object sender, EventArgs e) {
            ListBox lb = (ListBox) sender;
            switch (lb.Name) {
                case "listBox_showDiff_local_missingFiles":
                    Model.LocalMissingFAFsSelectedIndex = lb.SelectedIndex;
                    break;
                case "listBox_showDiff_local_filesToDownload":
                    Model.FilesToDownloadSelectedIndex = lb.SelectedIndex;
                    break;

                case "listBox_showDiff_remote_filesToUpload":
                    Model.FilesToUploadSelectedIndex = lb.SelectedIndex;
                    break;
                case "listBox_showDiff_remote_missingFiles":
                    Model.RemoteMissingFAFsSelectedIndex = lb.SelectedIndex;
                    break;
            }
        }

        private void AddLocalFile() {
            FTP_FAF selectedFile = Model.CurrentLists.MissingLocalFAFs[Model.LocalMissingFAFsSelectedIndex];
            Model.FilesToDownload.Add(selectedFile);
            Model.CurrentLists.MissingLocalFAFs.Remove(selectedFile);
        }
        private void RemoveLocalFile() {
            FTP_FAF selectedFile = Model.FilesToDownload[Model.FilesToDownloadSelectedIndex];
            Model.CurrentLists.MissingLocalFAFs.Add(selectedFile);
            Model.FilesToDownload.Remove(selectedFile);
        }
        private void DownloadLocalFiles() {
            throw new NotImplementedException();
        }
        private void AddRemoteFile() {
            FAF selectedFile = Model.CurrentLists.MissingRemoteFAFs[Model.RemoteMissingFAFsSelectedIndex];
            Model.FilesToUpload.Add(selectedFile);
            Model.CurrentLists.MissingRemoteFAFs.Remove(selectedFile);
        }
        private void RemoveRemoteFile() {
            FAF selectedFile = Model.FilesToUpload[Model.FilesToUploadSelectedIndex];
            Model.CurrentLists.MissingRemoteFAFs.Add(selectedFile);
            Model.FilesToUpload.Remove(selectedFile);
        }
        private void UploadRemoteFiles() {
            throw new NotImplementedException();
        }
    }
}