using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.Controller;
using Custom_FTP_Uploader.ProjectSRC.Controller.GUIMain;
using Custom_FTP_Uploader.ProjectSRC.GUI;

namespace Custom_FTP_Uploader {
    static class Program {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GUIMainView view = new GUIMainView();
            GUIMainController controller = new GUIMainController(view); //Controller is saved in view as reference
            view.RegisterController(controller);

            Application.Run(view);
        }
    }
}
