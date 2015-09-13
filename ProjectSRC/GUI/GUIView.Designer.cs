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
            this.dataGridView_addonList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_addonInfo_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_addonInfo_dirName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_addonInfo_firstUploaded = new System.Windows.Forms.TextBox();
            this.tb_addonInfo_lastUpdate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbox_addonInfo_addons_root = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbox_addonInfo_fastdl_workshop = new System.Windows.Forms.ComboBox();
            this.b_new = new System.Windows.Forms.Button();
            this.b_add = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_sync_localServer = new System.Windows.Forms.Button();
            this.b_sync_serverLocal = new System.Windows.Forms.Button();
            this.b_checkStatus = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main_addons_buttons)).BeginInit();
            this.splitContainer_main_addons_buttons.Panel1.SuspendLayout();
            this.splitContainer_main_addons_buttons.Panel2.SuspendLayout();
            this.splitContainer_main_addons_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_addons_list_info)).BeginInit();
            this.splitContainer_addons_list_info.Panel1.SuspendLayout();
            this.splitContainer_addons_list_info.Panel2.SuspendLayout();
            this.splitContainer_addons_list_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_addonList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer_main_addons_buttons
            // 
            this.splitContainer_main_addons_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main_addons_buttons.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer_main_addons_buttons.Panel2.Controls.Add(this.b_add);
            this.splitContainer_main_addons_buttons.Panel2.Controls.Add(this.b_new);
            this.splitContainer_main_addons_buttons.Size = new System.Drawing.Size(665, 453);
            this.splitContainer_main_addons_buttons.SplitterDistance = 384;
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
            this.splitContainer_addons_list_info.Panel1.Controls.Add(this.dataGridView_addonList);
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
            this.splitContainer_addons_list_info.Size = new System.Drawing.Size(665, 384);
            this.splitContainer_addons_list_info.SplitterDistance = 221;
            this.splitContainer_addons_list_info.TabIndex = 0;
            // 
            // dataGridView_addonList
            // 
            this.dataGridView_addonList.AllowUserToAddRows = false;
            this.dataGridView_addonList.AllowUserToDeleteRows = false;
            this.dataGridView_addonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_addonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_addonList.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_addonList.Name = "dataGridView_addonList";
            this.dataGridView_addonList.ReadOnly = true;
            this.dataGridView_addonList.Size = new System.Drawing.Size(221, 384);
            this.dataGridView_addonList.TabIndex = 0;
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
            // tb_addonInfo_name
            // 
            this.tb_addonInfo_name.Location = new System.Drawing.Point(121, 6);
            this.tb_addonInfo_name.Name = "tb_addonInfo_name";
            this.tb_addonInfo_name.Size = new System.Drawing.Size(307, 20);
            this.tb_addonInfo_name.TabIndex = 1;
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
            // tb_addonInfo_dirName
            // 
            this.tb_addonInfo_dirName.Location = new System.Drawing.Point(121, 32);
            this.tb_addonInfo_dirName.Name = "tb_addonInfo_dirName";
            this.tb_addonInfo_dirName.Size = new System.Drawing.Size(307, 20);
            this.tb_addonInfo_dirName.TabIndex = 3;
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
            // tb_addonInfo_firstUploaded
            // 
            this.tb_addonInfo_firstUploaded.Location = new System.Drawing.Point(121, 58);
            this.tb_addonInfo_firstUploaded.Name = "tb_addonInfo_firstUploaded";
            this.tb_addonInfo_firstUploaded.Size = new System.Drawing.Size(307, 20);
            this.tb_addonInfo_firstUploaded.TabIndex = 5;
            // 
            // tb_addonInfo_lastUpdate
            // 
            this.tb_addonInfo_lastUpdate.Location = new System.Drawing.Point(121, 84);
            this.tb_addonInfo_lastUpdate.Name = "tb_addonInfo_lastUpdate";
            this.tb_addonInfo_lastUpdate.Size = new System.Drawing.Size(307, 20);
            this.tb_addonInfo_lastUpdate.TabIndex = 6;
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
            // cbox_addonInfo_addons_root
            // 
            this.cbox_addonInfo_addons_root.FormattingEnabled = true;
            this.cbox_addonInfo_addons_root.Items.AddRange(new object[] {
            "Not selected",
            "Addons",
            "Root"});
            this.cbox_addonInfo_addons_root.Location = new System.Drawing.Point(121, 110);
            this.cbox_addonInfo_addons_root.Name = "cbox_addonInfo_addons_root";
            this.cbox_addonInfo_addons_root.Size = new System.Drawing.Size(307, 21);
            this.cbox_addonInfo_addons_root.TabIndex = 8;
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
            // cbox_addonInfo_fastdl_workshop
            // 
            this.cbox_addonInfo_fastdl_workshop.FormattingEnabled = true;
            this.cbox_addonInfo_fastdl_workshop.Items.AddRange(new object[] {
            "Not selected",
            "FastDL",
            "Workshop"});
            this.cbox_addonInfo_fastdl_workshop.Location = new System.Drawing.Point(121, 137);
            this.cbox_addonInfo_fastdl_workshop.Name = "cbox_addonInfo_fastdl_workshop";
            this.cbox_addonInfo_fastdl_workshop.Size = new System.Drawing.Size(307, 21);
            this.cbox_addonInfo_fastdl_workshop.TabIndex = 10;
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
            // b_add
            // 
            this.b_add.Location = new System.Drawing.Point(93, 3);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(75, 23);
            this.b_add.TabIndex = 1;
            this.b_add.Text = "Add";
            this.b_add.UseVisualStyleBackColor = true;
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
            // b_sync_localServer
            // 
            this.b_sync_localServer.Location = new System.Drawing.Point(12, 32);
            this.b_sync_localServer.Name = "b_sync_localServer";
            this.b_sync_localServer.Size = new System.Drawing.Size(126, 23);
            this.b_sync_localServer.TabIndex = 3;
            this.b_sync_localServer.Text = "Sync (Local -> Server)";
            this.b_sync_localServer.UseVisualStyleBackColor = true;
            // 
            // b_sync_serverLocal
            // 
            this.b_sync_serverLocal.Location = new System.Drawing.Point(146, 32);
            this.b_sync_serverLocal.Name = "b_sync_serverLocal";
            this.b_sync_serverLocal.Size = new System.Drawing.Size(123, 23);
            this.b_sync_serverLocal.TabIndex = 4;
            this.b_sync_serverLocal.Text = "Sync (Server -> Local)";
            this.b_sync_serverLocal.UseVisualStyleBackColor = true;
            // 
            // b_checkStatus
            // 
            this.b_checkStatus.Location = new System.Drawing.Point(275, 32);
            this.b_checkStatus.Name = "b_checkStatus";
            this.b_checkStatus.Size = new System.Drawing.Size(95, 23);
            this.b_checkStatus.TabIndex = 5;
            this.b_checkStatus.Text = "Check status";
            this.b_checkStatus.UseVisualStyleBackColor = true;
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
            // GUIView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 453);
            this.Controls.Add(this.splitContainer_main_addons_buttons);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_addonList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_main_addons_buttons;
        private System.Windows.Forms.SplitContainer splitContainer_addons_list_info;
        private System.Windows.Forms.DataGridView dataGridView_addonList;
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
        private System.Windows.Forms.Button b_add;
        private System.Windows.Forms.Button b_new;
        private System.Windows.Forms.Label label6;
    }
}