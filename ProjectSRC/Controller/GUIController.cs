// GUIController.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

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
    }
}