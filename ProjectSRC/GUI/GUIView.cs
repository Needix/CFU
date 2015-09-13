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
            //TODO: Add custom events here
        }

        public void RegisterController(GUIController controller) { _controller = controller; }

        public void UpdateView(GUIModel model) {
            //TODO: Add update code here (update gui components from model data)
        }
    }
}
