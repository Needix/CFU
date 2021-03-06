﻿// GUIController.ShowDiff.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.Controller.GUIMain;
using Custom_FTP_Uploader.ProjectSRC.GUI;
using Custom_FTP_Uploader.ProjectSRC.Model;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.Controller.GUIDiff {
    public class GUIDiffController {
        private readonly GUIDiffView _view;
        public GUIModelDiff Model { get; private set; }
        private readonly GUIMainController _controller;

        public GUIDiffController(GUIDiffView view, GUIModelDiff model, GUIMainController mainController) {
            _view = view;
            Model = model;
            _controller = mainController;
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
            WebClient client = _controller.CreateServerWebClient();
            foreach(FTP_FAF faf in Model.FilesToDownload) {
                String newFile = GUIMainController.GMOD_ROOT + faf.RelativePath;
                client.DownloadFile(_controller.GetServerURI(faf.RelativePath), newFile); //TODO: Implement async download // Progress bar
            }
            Model.FilesToDownload.Clear();
            _view.UpdateLists(Model);
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
            WebClient client = _controller.CreateServerWebClient();
            foreach(FAF faf in Model.FilesToUpload) {
                String newFile = GUIMainController.GMOD_ROOT + faf.Name;
                client.UploadFile(_controller.GetServerURI(faf.Name), newFile); //TODO: Implement async upload // Progress bar
            }
            Model.FilesToUpload.Clear();
            _view.UpdateLists(Model);
        }
    }
}