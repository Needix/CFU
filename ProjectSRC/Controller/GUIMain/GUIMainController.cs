// GUIController.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Custom_FTP_Uploader.ProjectSRC.GUI;
using Custom_FTP_Uploader.ProjectSRC.Model;
using Custom_FTP_Uploader.ProjectSRC.Model.HelpModels;

namespace Custom_FTP_Uploader.ProjectSRC.Controller.GUIMain {
    public partial class GUIMainController {
        public const string GMOD_PATH = "R:/Other/TestFTPServer/Local_GMOD/";
        //private const string GMOD_PATH = "/";
        public const string GMOD_SUB_FOLDER = "serverdata/garrysmod/";
        public const string GMOD_ROOT = GMOD_PATH + GMOD_SUB_FOLDER;

        private GUIModel _model;
        public GUIModel Model {
            get { return this._model; }
            set {
                if(value == null) return;
                this._model = value;
            }
        }

        public GUIMainView View { get; set; }

        public Serializer Serializer { get; private set; }

        public GUIMainController(GUIMainView view) {
            Serializer = new Serializer(this);
            Model = Serializer.Deserialize();
            if(Model == null) Model = new GUIModel();

            View = view;
            View.UpdateView(Model);
        }
    }
}