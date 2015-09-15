// GUIController.ModelUpdate.cs
// Copyright 2015
// 
// Author: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Windows.Forms;
using Custom_FTP_Uploader.ProjectSRC.Model;

namespace Custom_FTP_Uploader.ProjectSRC.Controller {
    public partial class GUIController {

        public void TB_TextChanged(object sender, EventArgs e) {
            TextBox tb = (TextBox)sender;
            String tbText = tb.Text;
            switch(tb.Name) {
                case "tb_addonInfo_name":
                    Model.CurrentAddonName = tbText;
                    break;
                case "tb_addonInfo_dirName":
                    Model.CurrentDirectoryName = tbText;
                    break;
                case "tb_addonInfo_firstUploaded":
                    Model.CurrentFirstUploaded = tbText;
                    break;
                case "tb_addonInfo_lastUpdate":
                    Model.CurrentLastUpdated = tbText;
                    break;

                case "tb_settings_fastDL_ipPort":
                    Model.SettingsModel.FastDL.IP_Port = tbText;
                    break;
                case "tb_settings_fastDL_username":
                    Model.SettingsModel.FastDL.Username = tbText;
                    break;
                case "tb_settings_fastDL_password":
                    Model.SettingsModel.FastDL.SetEncryptedPassword(tbText);
                    break;

                case "tb_settings_server_ipPort":
                    Model.SettingsModel.Server.IP_Port = tbText;
                    break;
                case "tb_settings_server_username":
                    Model.SettingsModel.Server.Username = tbText;
                    break;
                case "tb_settings_server_password":
                    Model.SettingsModel.Server.SetEncryptedPassword(tbText);
                    break;

                default:
                    Debug.WriteLine("WARNING: Could not find model variable for textbox: "+tb.Name);
                    break;
            }
        }
        public void ComboBox_TextChanged(object sender, EventArgs e) {
            ComboBox cbox = (ComboBox)sender;
            switch(cbox.Name) {
                case "cbox_addonInfo_addons_root":
                    Model.CurrentAddonType = (Addon.AddonType)cbox.SelectedIndex;
                    break;
                case "cbox_addonInfo_fastdl_workshop":
                    Model.CurrentDLType = (Addon.DownloadType)cbox.SelectedIndex;
                    break;
                default:
                    Debug.WriteLine("WARNING: Could not find model variable for combobox: "+cbox.Name);
                    break;
            }
        }
        public void ListView_SelectedIndexChanged(object sender, EventArgs e) {
            ListView lw = (ListView)sender;
            if(lw.SelectedIndices.Count == 0) Model.SelectedAddonIndex = -1;
            else Model.SelectedAddonIndex = lw.SelectedIndices[0];

            Model.UpdateVarsFromSelectedAddon();
            View.UpdateAddonInfo(Model);
        }
        public void CheckBox_CheckChanged(object sender, EventArgs e) {
            CheckBox cbox = (CheckBox)sender;
            switch(cbox.Name) {
                case "checkBox_settings_enableLog":
                    Model.SettingsModel.EnableLogging = cbox.Checked;
                    break;

                default:
                    Debug.WriteLine("WARNING: Could not find model variable for checkbox: "+cbox.Name);
                    break;
            }
        }
    }
}