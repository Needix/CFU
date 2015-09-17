namespace Custom_FTP_Uploader.ProjectSRC.GUI {
    partial class GUIView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainer_main_addons_buttons = new System.Windows.Forms.SplitContainer();
            this.splitContainer_addons_list_info = new System.Windows.Forms.SplitContainer();
            this.listView_addonList = new System.Windows.Forms.ListView();
            this.columnHeader_main = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.cbox_addonInfo_fastdl_workshop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbox_addonInfo_addons_root = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_addonInfo_lastUpdate = new System.Windows.Forms.TextBox();
            this.tb_addonInfo_firstUploaded = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_addonInfo_dirName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_addonInfo_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_checkStatus = new System.Windows.Forms.Button();
            this.b_sync_serverLocal = new System.Windows.Forms.Button();
            this.b_sync_localServer = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_edit = new System.Windows.Forms.Button();
            this.b_new = new System.Windows.Forms.Button();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.page_main_addonInfo = new System.Windows.Forms.TabPage();
            this.page_main_settings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_settings_enableLog = new System.Windows.Forms.CheckBox();
            this.groupBox_settings_saveLoad = new System.Windows.Forms.GroupBox();
            this.b_settings_resetToDefault = new System.Windows.Forms.Button();
            this.b_settings_load = new System.Windows.Forms.Button();
            this.b_settings_save = new System.Windows.Forms.Button();
            this.groupBox_settings_server = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_settings_server_password = new System.Windows.Forms.TextBox();
            this.tb_settings_server_username = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_settings_server_ipPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox_settings_fastDL = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_settings_fastDL_password = new System.Windows.Forms.TextBox();
            this.tb_settings_fastDL_username = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_settings_fastDL_ipPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer_main_log = new System.Windows.Forms.SplitContainer();
            this.listView_main_log = new System.Windows.Forms.ListView();
            this.columnHeader_main_log = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main_addons_buttons)).BeginInit();
            this.splitContainer_main_addons_buttons.Panel1.SuspendLayout();
            this.splitContainer_main_addons_buttons.Panel2.SuspendLayout();
            this.splitContainer_main_addons_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_addons_list_info)).BeginInit();
            this.splitContainer_addons_list_info.Panel1.SuspendLayout();
            this.splitContainer_addons_list_info.Panel2.SuspendLayout();
            this.splitContainer_addons_list_info.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.page_main_addonInfo.SuspendLayout();
            this.page_main_settings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_settings_saveLoad.SuspendLayout();
            this.groupBox_settings_server.SuspendLayout();
            this.groupBox_settings_fastDL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main_log)).BeginInit();
            this.splitContainer_main_log.Panel1.SuspendLayout();
            this.splitContainer_main_log.Panel2.SuspendLayout();
            this.splitContainer_main_log.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_main_addons_buttons
            // 
            this.splitContainer_main_addons_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main_addons_buttons.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer_main_addons_buttons.IsSplitterFixed = true;
            this.splitContainer_main_addons_buttons.Location = new System.Drawing.Point(3, 3);
            this.splitContainer_main_addons_buttons.Name = "splitContainer_main_addons_buttons";
            this.splitContainer_main_addons_buttons.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_main_addons_buttons.Panel1
            // 
            this.splitContainer_main_addons_buttons.Panel1.Controls.Add(this.splitContainer_addons_list_info);
            // 
            // splitContainer_main_addons_buttons.Panel2
            // 
            this.splitContainer_main_addons_buttons.Panel2.Controls.Add(this.b_checkStatus);
            this.splitContainer_main_addons_buttons.Panel2.Controls.Add(this.b_sync_serverLocal);
            this.splitContainer_main_addons_buttons.Panel2.Controls.Add(this.b_sync_localServer);
            this.splitContainer_main_addons_buttons.Panel2.Controls.Add(this.b_delete);
            this.splitContainer_main_addons_buttons.Panel2.Controls.Add(this.b_edit);
            this.splitContainer_main_addons_buttons.Panel2.Controls.Add(this.b_new);
            this.splitContainer_main_addons_buttons.Size = new System.Drawing.Size(1140, 300);
            this.splitContainer_main_addons_buttons.SplitterDistance = 236;
            this.splitContainer_main_addons_buttons.TabIndex = 0;
            // 
            // splitContainer_addons_list_info
            // 
            this.splitContainer_addons_list_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_addons_list_info.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_addons_list_info.Name = "splitContainer_addons_list_info";
            // 
            // splitContainer_addons_list_info.Panel1
            // 
            this.splitContainer_addons_list_info.Panel1.Controls.Add(this.listView_addonList);
            // 
            // splitContainer_addons_list_info.Panel2
            // 
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.label6);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.cbox_addonInfo_fastdl_workshop);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.label5);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.cbox_addonInfo_addons_root);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.label4);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.tb_addonInfo_lastUpdate);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.tb_addonInfo_firstUploaded);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.label3);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.tb_addonInfo_dirName);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.label2);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.tb_addonInfo_name);
            this.splitContainer_addons_list_info.Panel2.Controls.Add(this.label1);
            this.splitContainer_addons_list_info.Size = new System.Drawing.Size(1140, 236);
            this.splitContainer_addons_list_info.SplitterDistance = 378;
            this.splitContainer_addons_list_info.TabIndex = 0;
            // 
            // listView_addonList
            // 
            this.listView_addonList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_main});
            this.listView_addonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_addonList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_addonList.Location = new System.Drawing.Point(0, 0);
            this.listView_addonList.MultiSelect = false;
            this.listView_addonList.Name = "listView_addonList";
            this.listView_addonList.Size = new System.Drawing.Size(378, 236);
            this.listView_addonList.TabIndex = 0;
            this.listView_addonList.UseCompatibleStateImageBehavior = false;
            this.listView_addonList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_main
            // 
            this.columnHeader_main.Text = "";
            this.columnHeader_main.Width = 180;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "FastDL/Workshop?";
            // 
            // cbox_addonInfo_fastdl_workshop
            // 
            this.cbox_addonInfo_fastdl_workshop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbox_addonInfo_fastdl_workshop.FormattingEnabled = true;
            this.cbox_addonInfo_fastdl_workshop.Items.AddRange(new object[] {
            "Not selected",
            "FastDL",
            "Workshop"});
            this.cbox_addonInfo_fastdl_workshop.Location = new System.Drawing.Point(121, 137);
            this.cbox_addonInfo_fastdl_workshop.Name = "cbox_addonInfo_fastdl_workshop";
            this.cbox_addonInfo_fastdl_workshop.Size = new System.Drawing.Size(626, 21);
            this.cbox_addonInfo_fastdl_workshop.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Addons/Root?";
            // 
            // cbox_addonInfo_addons_root
            // 
            this.cbox_addonInfo_addons_root.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbox_addonInfo_addons_root.FormattingEnabled = true;
            this.cbox_addonInfo_addons_root.Items.AddRange(new object[] {
            "Not selected",
            "Addons",
            "Root"});
            this.cbox_addonInfo_addons_root.Location = new System.Drawing.Point(121, 110);
            this.cbox_addonInfo_addons_root.Name = "cbox_addonInfo_addons_root";
            this.cbox_addonInfo_addons_root.Size = new System.Drawing.Size(626, 21);
            this.cbox_addonInfo_addons_root.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Last updated (version)";
            // 
            // tb_addonInfo_lastUpdate
            // 
            this.tb_addonInfo_lastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_addonInfo_lastUpdate.Location = new System.Drawing.Point(121, 84);
            this.tb_addonInfo_lastUpdate.Name = "tb_addonInfo_lastUpdate";
            this.tb_addonInfo_lastUpdate.Size = new System.Drawing.Size(626, 20);
            this.tb_addonInfo_lastUpdate.TabIndex = 6;
            // 
            // tb_addonInfo_firstUploaded
            // 
            this.tb_addonInfo_firstUploaded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_addonInfo_firstUploaded.Location = new System.Drawing.Point(121, 58);
            this.tb_addonInfo_firstUploaded.Name = "tb_addonInfo_firstUploaded";
            this.tb_addonInfo_firstUploaded.Size = new System.Drawing.Size(626, 20);
            this.tb_addonInfo_firstUploaded.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "First uploaded: ";
            // 
            // tb_addonInfo_dirName
            // 
            this.tb_addonInfo_dirName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_addonInfo_dirName.Location = new System.Drawing.Point(121, 32);
            this.tb_addonInfo_dirName.Name = "tb_addonInfo_dirName";
            this.tb_addonInfo_dirName.Size = new System.Drawing.Size(626, 20);
            this.tb_addonInfo_dirName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Directory Name: ";
            // 
            // tb_addonInfo_name
            // 
            this.tb_addonInfo_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_addonInfo_name.Location = new System.Drawing.Point(121, 6);
            this.tb_addonInfo_name.Name = "tb_addonInfo_name";
            this.tb_addonInfo_name.Size = new System.Drawing.Size(626, 20);
            this.tb_addonInfo_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Addon Name: ";
            // 
            // b_checkStatus
            // 
            this.b_checkStatus.Location = new System.Drawing.Point(273, 32);
            this.b_checkStatus.Name = "b_checkStatus";
            this.b_checkStatus.Size = new System.Drawing.Size(95, 23);
            this.b_checkStatus.TabIndex = 5;
            this.b_checkStatus.Text = "Check status";
            this.b_checkStatus.UseVisualStyleBackColor = true;
            // 
            // b_sync_serverLocal
            // 
            this.b_sync_serverLocal.Location = new System.Drawing.Point(144, 32);
            this.b_sync_serverLocal.Name = "b_sync_serverLocal";
            this.b_sync_serverLocal.Size = new System.Drawing.Size(123, 23);
            this.b_sync_serverLocal.TabIndex = 4;
            this.b_sync_serverLocal.Text = "Sync (Server -> Local)";
            this.b_sync_serverLocal.UseVisualStyleBackColor = true;
            // 
            // b_sync_localServer
            // 
            this.b_sync_localServer.Location = new System.Drawing.Point(12, 32);
            this.b_sync_localServer.Name = "b_sync_localServer";
            this.b_sync_localServer.Size = new System.Drawing.Size(126, 23);
            this.b_sync_localServer.TabIndex = 3;
            this.b_sync_localServer.Text = "Sync (Local -> Server)";
            this.b_sync_localServer.UseVisualStyleBackColor = true;
            // 
            // b_delete
            // 
            this.b_delete.Location = new System.Drawing.Point(174, 3);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(75, 23);
            this.b_delete.TabIndex = 2;
            this.b_delete.Text = "Delete";
            this.b_delete.UseVisualStyleBackColor = true;
            // 
            // b_edit
            // 
            this.b_edit.Location = new System.Drawing.Point(93, 3);
            this.b_edit.Name = "b_edit";
            this.b_edit.Size = new System.Drawing.Size(75, 23);
            this.b_edit.TabIndex = 1;
            this.b_edit.Text = "Edit";
            this.b_edit.UseVisualStyleBackColor = true;
            // 
            // b_new
            // 
            this.b_new.Location = new System.Drawing.Point(12, 3);
            this.b_new.Name = "b_new";
            this.b_new.Size = new System.Drawing.Size(75, 23);
            this.b_new.TabIndex = 0;
            this.b_new.Text = "New";
            this.b_new.UseVisualStyleBackColor = true;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.page_main_addonInfo);
            this.tabControl_main.Controls.Add(this.page_main_settings);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(1154, 332);
            this.tabControl_main.TabIndex = 1;
            // 
            // page_main_addonInfo
            // 
            this.page_main_addonInfo.Controls.Add(this.splitContainer_main_addons_buttons);
            this.page_main_addonInfo.Location = new System.Drawing.Point(4, 22);
            this.page_main_addonInfo.Name = "page_main_addonInfo";
            this.page_main_addonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.page_main_addonInfo.Size = new System.Drawing.Size(1146, 306);
            this.page_main_addonInfo.TabIndex = 0;
            this.page_main_addonInfo.Text = "Addons Info";
            this.page_main_addonInfo.UseVisualStyleBackColor = true;
            // 
            // page_main_settings
            // 
            this.page_main_settings.Controls.Add(this.groupBox1);
            this.page_main_settings.Controls.Add(this.groupBox_settings_saveLoad);
            this.page_main_settings.Controls.Add(this.groupBox_settings_server);
            this.page_main_settings.Controls.Add(this.groupBox_settings_fastDL);
            this.page_main_settings.Location = new System.Drawing.Point(4, 22);
            this.page_main_settings.Name = "page_main_settings";
            this.page_main_settings.Padding = new System.Windows.Forms.Padding(3);
            this.page_main_settings.Size = new System.Drawing.Size(611, 306);
            this.page_main_settings.TabIndex = 1;
            this.page_main_settings.Text = "Settings";
            this.page_main_settings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_settings_enableLog);
            this.groupBox1.Location = new System.Drawing.Point(284, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 55);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other";
            // 
            // checkBox_settings_enableLog
            // 
            this.checkBox_settings_enableLog.AutoSize = true;
            this.checkBox_settings_enableLog.Checked = true;
            this.checkBox_settings_enableLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_settings_enableLog.Location = new System.Drawing.Point(12, 19);
            this.checkBox_settings_enableLog.Name = "checkBox_settings_enableLog";
            this.checkBox_settings_enableLog.Size = new System.Drawing.Size(113, 17);
            this.checkBox_settings_enableLog.TabIndex = 0;
            this.checkBox_settings_enableLog.Text = "Enable log printing";
            this.checkBox_settings_enableLog.UseVisualStyleBackColor = true;
            // 
            // groupBox_settings_saveLoad
            // 
            this.groupBox_settings_saveLoad.Controls.Add(this.b_settings_resetToDefault);
            this.groupBox_settings_saveLoad.Controls.Add(this.b_settings_load);
            this.groupBox_settings_saveLoad.Controls.Add(this.b_settings_save);
            this.groupBox_settings_saveLoad.Location = new System.Drawing.Point(8, 113);
            this.groupBox_settings_saveLoad.MinimumSize = new System.Drawing.Size(270, 55);
            this.groupBox_settings_saveLoad.Name = "groupBox_settings_saveLoad";
            this.groupBox_settings_saveLoad.Size = new System.Drawing.Size(270, 55);
            this.groupBox_settings_saveLoad.TabIndex = 2;
            this.groupBox_settings_saveLoad.TabStop = false;
            this.groupBox_settings_saveLoad.Text = "Save/Load";
            // 
            // b_settings_resetToDefault
            // 
            this.b_settings_resetToDefault.Location = new System.Drawing.Point(168, 19);
            this.b_settings_resetToDefault.Name = "b_settings_resetToDefault";
            this.b_settings_resetToDefault.Size = new System.Drawing.Size(93, 23);
            this.b_settings_resetToDefault.TabIndex = 11;
            this.b_settings_resetToDefault.Text = "Reset to default";
            this.b_settings_resetToDefault.UseVisualStyleBackColor = true;
            // 
            // b_settings_load
            // 
            this.b_settings_load.Location = new System.Drawing.Point(87, 19);
            this.b_settings_load.Name = "b_settings_load";
            this.b_settings_load.Size = new System.Drawing.Size(75, 23);
            this.b_settings_load.TabIndex = 10;
            this.b_settings_load.Text = "Load";
            this.b_settings_load.UseVisualStyleBackColor = true;
            // 
            // b_settings_save
            // 
            this.b_settings_save.Location = new System.Drawing.Point(6, 19);
            this.b_settings_save.Name = "b_settings_save";
            this.b_settings_save.Size = new System.Drawing.Size(75, 23);
            this.b_settings_save.TabIndex = 9;
            this.b_settings_save.Text = "Save";
            this.b_settings_save.UseVisualStyleBackColor = true;
            // 
            // groupBox_settings_server
            // 
            this.groupBox_settings_server.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_settings_server.Controls.Add(this.label11);
            this.groupBox_settings_server.Controls.Add(this.tb_settings_server_password);
            this.groupBox_settings_server.Controls.Add(this.tb_settings_server_username);
            this.groupBox_settings_server.Controls.Add(this.label12);
            this.groupBox_settings_server.Controls.Add(this.tb_settings_server_ipPort);
            this.groupBox_settings_server.Controls.Add(this.label8);
            this.groupBox_settings_server.Location = new System.Drawing.Point(314, 6);
            this.groupBox_settings_server.Name = "groupBox_settings_server";
            this.groupBox_settings_server.Size = new System.Drawing.Size(289, 101);
            this.groupBox_settings_server.TabIndex = 1;
            this.groupBox_settings_server.TabStop = false;
            this.groupBox_settings_server.Text = "Server";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Password:";
            // 
            // tb_settings_server_password
            // 
            this.tb_settings_server_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_settings_server_password.Location = new System.Drawing.Point(73, 65);
            this.tb_settings_server_password.Name = "tb_settings_server_password";
            this.tb_settings_server_password.PasswordChar = '*';
            this.tb_settings_server_password.Size = new System.Drawing.Size(205, 20);
            this.tb_settings_server_password.TabIndex = 8;
            // 
            // tb_settings_server_username
            // 
            this.tb_settings_server_username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_settings_server_username.Location = new System.Drawing.Point(73, 39);
            this.tb_settings_server_username.Name = "tb_settings_server_username";
            this.tb_settings_server_username.Size = new System.Drawing.Size(205, 20);
            this.tb_settings_server_username.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Username: ";
            // 
            // tb_settings_server_ipPort
            // 
            this.tb_settings_server_ipPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_settings_server_ipPort.Location = new System.Drawing.Point(73, 13);
            this.tb_settings_server_ipPort.Name = "tb_settings_server_ipPort";
            this.tb_settings_server_ipPort.Size = new System.Drawing.Size(205, 20);
            this.tb_settings_server_ipPort.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "IP:Port";
            // 
            // groupBox_settings_fastDL
            // 
            this.groupBox_settings_fastDL.Controls.Add(this.label10);
            this.groupBox_settings_fastDL.Controls.Add(this.tb_settings_fastDL_password);
            this.groupBox_settings_fastDL.Controls.Add(this.tb_settings_fastDL_username);
            this.groupBox_settings_fastDL.Controls.Add(this.label9);
            this.groupBox_settings_fastDL.Controls.Add(this.tb_settings_fastDL_ipPort);
            this.groupBox_settings_fastDL.Controls.Add(this.label7);
            this.groupBox_settings_fastDL.Location = new System.Drawing.Point(8, 6);
            this.groupBox_settings_fastDL.Name = "groupBox_settings_fastDL";
            this.groupBox_settings_fastDL.Size = new System.Drawing.Size(300, 101);
            this.groupBox_settings_fastDL.TabIndex = 0;
            this.groupBox_settings_fastDL.TabStop = false;
            this.groupBox_settings_fastDL.Text = "FastDL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Password:";
            // 
            // tb_settings_fastDL_password
            // 
            this.tb_settings_fastDL_password.Location = new System.Drawing.Point(70, 65);
            this.tb_settings_fastDL_password.Name = "tb_settings_fastDL_password";
            this.tb_settings_fastDL_password.PasswordChar = '*';
            this.tb_settings_fastDL_password.Size = new System.Drawing.Size(224, 20);
            this.tb_settings_fastDL_password.TabIndex = 4;
            // 
            // tb_settings_fastDL_username
            // 
            this.tb_settings_fastDL_username.Location = new System.Drawing.Point(70, 39);
            this.tb_settings_fastDL_username.Name = "tb_settings_fastDL_username";
            this.tb_settings_fastDL_username.Size = new System.Drawing.Size(224, 20);
            this.tb_settings_fastDL_username.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Username: ";
            // 
            // tb_settings_fastDL_ipPort
            // 
            this.tb_settings_fastDL_ipPort.Location = new System.Drawing.Point(70, 13);
            this.tb_settings_fastDL_ipPort.Name = "tb_settings_fastDL_ipPort";
            this.tb_settings_fastDL_ipPort.Size = new System.Drawing.Size(224, 20);
            this.tb_settings_fastDL_ipPort.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "IP:Port";
            // 
            // splitContainer_main_log
            // 
            this.splitContainer_main_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main_log.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_main_log.Name = "splitContainer_main_log";
            this.splitContainer_main_log.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_main_log.Panel1
            // 
            this.splitContainer_main_log.Panel1.Controls.Add(this.tabControl_main);
            // 
            // splitContainer_main_log.Panel2
            // 
            this.splitContainer_main_log.Panel2.Controls.Add(this.listView_main_log);
            this.splitContainer_main_log.Size = new System.Drawing.Size(1154, 446);
            this.splitContainer_main_log.SplitterDistance = 332;
            this.splitContainer_main_log.TabIndex = 2;
            // 
            // listView_main_log
            // 
            this.listView_main_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_main_log});
            this.listView_main_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_main_log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_main_log.Location = new System.Drawing.Point(0, 0);
            this.listView_main_log.MultiSelect = false;
            this.listView_main_log.Name = "listView_main_log";
            this.listView_main_log.Size = new System.Drawing.Size(1154, 110);
            this.listView_main_log.TabIndex = 0;
            this.listView_main_log.UseCompatibleStateImageBehavior = false;
            this.listView_main_log.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_main_log
            // 
            this.columnHeader_main_log.Width = 615;
            // 
            // GUIView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 446);
            this.Controls.Add(this.splitContainer_main_log);
            this.MinimumSize = new System.Drawing.Size(635, 485);
            this.Name = "GUIView";
            this.Text = "GUIView";
            this.splitContainer_main_addons_buttons.Panel1.ResumeLayout(false);
            this.splitContainer_main_addons_buttons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main_addons_buttons)).EndInit();
            this.splitContainer_main_addons_buttons.ResumeLayout(false);
            this.splitContainer_addons_list_info.Panel1.ResumeLayout(false);
            this.splitContainer_addons_list_info.Panel2.ResumeLayout(false);
            this.splitContainer_addons_list_info.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_addons_list_info)).EndInit();
            this.splitContainer_addons_list_info.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.page_main_addonInfo.ResumeLayout(false);
            this.page_main_settings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_settings_saveLoad.ResumeLayout(false);
            this.groupBox_settings_server.ResumeLayout(false);
            this.groupBox_settings_server.PerformLayout();
            this.groupBox_settings_fastDL.ResumeLayout(false);
            this.groupBox_settings_fastDL.PerformLayout();
            this.splitContainer_main_log.Panel1.ResumeLayout(false);
            this.splitContainer_main_log.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main_log)).EndInit();
            this.splitContainer_main_log.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_main_addons_buttons;
        private System.Windows.Forms.SplitContainer splitContainer_addons_list_info;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_addonInfo_lastUpdate;
        private System.Windows.Forms.TextBox tb_addonInfo_firstUploaded;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_addonInfo_dirName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_addonInfo_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_addonInfo_fastdl_workshop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbox_addonInfo_addons_root;
        private System.Windows.Forms.Button b_checkStatus;
        private System.Windows.Forms.Button b_sync_serverLocal;
        private System.Windows.Forms.Button b_sync_localServer;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_edit;
        private System.Windows.Forms.Button b_new;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView_addonList;
        private System.Windows.Forms.ColumnHeader columnHeader_main;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage page_main_addonInfo;
        private System.Windows.Forms.TabPage page_main_settings;
        private System.Windows.Forms.GroupBox groupBox_settings_saveLoad;
        private System.Windows.Forms.GroupBox groupBox_settings_server;
        private System.Windows.Forms.GroupBox groupBox_settings_fastDL;
        private System.Windows.Forms.Button b_settings_resetToDefault;
        private System.Windows.Forms.Button b_settings_load;
        private System.Windows.Forms.Button b_settings_save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_settings_server_ipPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_settings_fastDL_ipPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_settings_fastDL_password;
        private System.Windows.Forms.TextBox tb_settings_fastDL_username;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_settings_server_password;
        private System.Windows.Forms.TextBox tb_settings_server_username;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.SplitContainer splitContainer_main_log;
        private System.Windows.Forms.ListView listView_main_log;
        private System.Windows.Forms.ColumnHeader columnHeader_main_log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_settings_enableLog;
    }
}