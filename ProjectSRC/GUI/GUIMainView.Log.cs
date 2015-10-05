// GUIView.Log.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Custom_FTP_Uploader.ProjectSRC.GUI {
    public partial class GUIMainView {
        public void AddErrorInfo(String text) {
            AddLog(text, Color.Red);
        }

        public void AddInfo(String text) {
            AddLog(text, Color.White);
        }

        public void AddWarningInfo(String text) {
            AddLog(text, Color.Orange);
        }

        private void AddLog(String text, Color color) {
            if (!_controller.Model.SettingsModel.EnableLogging) return;
            if(!this.IsHandleCreated) {
                Debug.WriteLine("ERROR: GUI| Trying to add \""+text+"\" to ListViewInfo while handle is invalid!");
                return;
            }
            try {
                this.listView_main_log.Invoke((MethodInvoker)delegate {
                    listView_main_log.Items.Add(DateTime.Now + ": " + text);
                    ListViewItem item = listView_main_log.Items[listView_main_log.Items.Count - 1];
                    item.BackColor = color;
                    listView_main_log.EnsureVisible(listView_main_log.Items.Count - 1);
                    listView_main_log.Columns[0].Width = -1;
                });
            } catch(ThreadInterruptedException) { }
        }
    }
}