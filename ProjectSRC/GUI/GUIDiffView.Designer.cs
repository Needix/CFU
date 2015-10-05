namespace Custom_FTP_Uploader.ProjectSRC.GUI {
    partial class GUIDiffView {
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
            this.groupBox_showDiff_local = new System.Windows.Forms.GroupBox();
            this.listBox_showDiff_local_filesToDownload = new System.Windows.Forms.ListBox();
            this.b_showDiff_local_download = new System.Windows.Forms.Button();
            this.b_showDiff_local_remove = new System.Windows.Forms.Button();
            this.b_showDiff_local_add = new System.Windows.Forms.Button();
            this.listBox_showDiff_local_missingFiles = new System.Windows.Forms.ListBox();
            this.groupBox_showDiff_remote = new System.Windows.Forms.GroupBox();
            this.listBox_showDiff_remote_filesToUpload = new System.Windows.Forms.ListBox();
            this.b_showDiff_remote_upload = new System.Windows.Forms.Button();
            this.b_showDiff_remote_remove = new System.Windows.Forms.Button();
            this.b_showDiff_remote_add = new System.Windows.Forms.Button();
            this.listBox_showDiff_remote_missingFiles = new System.Windows.Forms.ListBox();
            this.splitContainer_showDiff = new System.Windows.Forms.SplitContainer();
            this.groupBox_showDiff_local.SuspendLayout();
            this.groupBox_showDiff_remote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_showDiff)).BeginInit();
            this.splitContainer_showDiff.Panel1.SuspendLayout();
            this.splitContainer_showDiff.Panel2.SuspendLayout();
            this.splitContainer_showDiff.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_showDiff_local
            // 
            this.groupBox_showDiff_local.Controls.Add(this.listBox_showDiff_local_filesToDownload);
            this.groupBox_showDiff_local.Controls.Add(this.b_showDiff_local_download);
            this.groupBox_showDiff_local.Controls.Add(this.b_showDiff_local_remove);
            this.groupBox_showDiff_local.Controls.Add(this.b_showDiff_local_add);
            this.groupBox_showDiff_local.Controls.Add(this.listBox_showDiff_local_missingFiles);
            this.groupBox_showDiff_local.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_showDiff_local.Location = new System.Drawing.Point(0, 0);
            this.groupBox_showDiff_local.Name = "groupBox_showDiff_local";
            this.groupBox_showDiff_local.Size = new System.Drawing.Size(292, 403);
            this.groupBox_showDiff_local.TabIndex = 0;
            this.groupBox_showDiff_local.TabStop = false;
            this.groupBox_showDiff_local.Text = "Local Missing Files/Folder";
            // 
            // listBox_showDiff_local_filesToDownload
            // 
            this.listBox_showDiff_local_filesToDownload.FormattingEnabled = true;
            this.listBox_showDiff_local_filesToDownload.Location = new System.Drawing.Point(6, 237);
            this.listBox_showDiff_local_filesToDownload.Name = "listBox_showDiff_local_filesToDownload";
            this.listBox_showDiff_local_filesToDownload.Size = new System.Drawing.Size(280, 134);
            this.listBox_showDiff_local_filesToDownload.TabIndex = 4;
            // 
            // b_showDiff_local_download
            // 
            this.b_showDiff_local_download.Location = new System.Drawing.Point(6, 374);
            this.b_showDiff_local_download.Name = "b_showDiff_local_download";
            this.b_showDiff_local_download.Size = new System.Drawing.Size(280, 23);
            this.b_showDiff_local_download.TabIndex = 3;
            this.b_showDiff_local_download.Text = "Download";
            this.b_showDiff_local_download.UseVisualStyleBackColor = true;
            // 
            // b_showDiff_local_remove
            // 
            this.b_showDiff_local_remove.Location = new System.Drawing.Point(154, 208);
            this.b_showDiff_local_remove.Name = "b_showDiff_local_remove";
            this.b_showDiff_local_remove.Size = new System.Drawing.Size(135, 23);
            this.b_showDiff_local_remove.TabIndex = 2;
            this.b_showDiff_local_remove.Text = "Remove";
            this.b_showDiff_local_remove.UseVisualStyleBackColor = true;
            // 
            // b_showDiff_local_add
            // 
            this.b_showDiff_local_add.Location = new System.Drawing.Point(3, 208);
            this.b_showDiff_local_add.Name = "b_showDiff_local_add";
            this.b_showDiff_local_add.Size = new System.Drawing.Size(145, 23);
            this.b_showDiff_local_add.TabIndex = 1;
            this.b_showDiff_local_add.Text = "Add";
            this.b_showDiff_local_add.UseVisualStyleBackColor = true;
            // 
            // listBox_showDiff_local_missingFiles
            // 
            this.listBox_showDiff_local_missingFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox_showDiff_local_missingFiles.FormattingEnabled = true;
            this.listBox_showDiff_local_missingFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_showDiff_local_missingFiles.Name = "listBox_showDiff_local_missingFiles";
            this.listBox_showDiff_local_missingFiles.Size = new System.Drawing.Size(286, 186);
            this.listBox_showDiff_local_missingFiles.TabIndex = 0;
            // 
            // groupBox_showDiff_remote
            // 
            this.groupBox_showDiff_remote.Controls.Add(this.listBox_showDiff_remote_filesToUpload);
            this.groupBox_showDiff_remote.Controls.Add(this.b_showDiff_remote_upload);
            this.groupBox_showDiff_remote.Controls.Add(this.b_showDiff_remote_remove);
            this.groupBox_showDiff_remote.Controls.Add(this.b_showDiff_remote_add);
            this.groupBox_showDiff_remote.Controls.Add(this.listBox_showDiff_remote_missingFiles);
            this.groupBox_showDiff_remote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_showDiff_remote.Location = new System.Drawing.Point(0, 0);
            this.groupBox_showDiff_remote.Name = "groupBox_showDiff_remote";
            this.groupBox_showDiff_remote.Size = new System.Drawing.Size(288, 403);
            this.groupBox_showDiff_remote.TabIndex = 1;
            this.groupBox_showDiff_remote.TabStop = false;
            this.groupBox_showDiff_remote.Text = "Remote Missing Files/Folder";
            // 
            // listBox_showDiff_remote_filesToUpload
            // 
            this.listBox_showDiff_remote_filesToUpload.FormattingEnabled = true;
            this.listBox_showDiff_remote_filesToUpload.Location = new System.Drawing.Point(0, 234);
            this.listBox_showDiff_remote_filesToUpload.Name = "listBox_showDiff_remote_filesToUpload";
            this.listBox_showDiff_remote_filesToUpload.Size = new System.Drawing.Size(280, 134);
            this.listBox_showDiff_remote_filesToUpload.TabIndex = 9;
            // 
            // b_showDiff_remote_upload
            // 
            this.b_showDiff_remote_upload.Location = new System.Drawing.Point(0, 374);
            this.b_showDiff_remote_upload.Name = "b_showDiff_remote_upload";
            this.b_showDiff_remote_upload.Size = new System.Drawing.Size(282, 23);
            this.b_showDiff_remote_upload.TabIndex = 8;
            this.b_showDiff_remote_upload.Text = "Upload";
            this.b_showDiff_remote_upload.UseVisualStyleBackColor = true;
            // 
            // b_showDiff_remote_remove
            // 
            this.b_showDiff_remote_remove.Location = new System.Drawing.Point(151, 208);
            this.b_showDiff_remote_remove.Name = "b_showDiff_remote_remove";
            this.b_showDiff_remote_remove.Size = new System.Drawing.Size(131, 23);
            this.b_showDiff_remote_remove.TabIndex = 7;
            this.b_showDiff_remote_remove.Text = "Remove";
            this.b_showDiff_remote_remove.UseVisualStyleBackColor = true;
            // 
            // b_showDiff_remote_add
            // 
            this.b_showDiff_remote_add.Location = new System.Drawing.Point(0, 208);
            this.b_showDiff_remote_add.Name = "b_showDiff_remote_add";
            this.b_showDiff_remote_add.Size = new System.Drawing.Size(145, 23);
            this.b_showDiff_remote_add.TabIndex = 6;
            this.b_showDiff_remote_add.Text = "Add";
            this.b_showDiff_remote_add.UseVisualStyleBackColor = true;
            // 
            // listBox_showDiff_remote_missingFiles
            // 
            this.listBox_showDiff_remote_missingFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox_showDiff_remote_missingFiles.FormattingEnabled = true;
            this.listBox_showDiff_remote_missingFiles.Location = new System.Drawing.Point(3, 16);
            this.listBox_showDiff_remote_missingFiles.Name = "listBox_showDiff_remote_missingFiles";
            this.listBox_showDiff_remote_missingFiles.Size = new System.Drawing.Size(282, 186);
            this.listBox_showDiff_remote_missingFiles.TabIndex = 5;
            // 
            // splitContainer_showDiff
            // 
            this.splitContainer_showDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_showDiff.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_showDiff.Name = "splitContainer_showDiff";
            // 
            // splitContainer_showDiff.Panel1
            // 
            this.splitContainer_showDiff.Panel1.Controls.Add(this.groupBox_showDiff_local);
            // 
            // splitContainer_showDiff.Panel2
            // 
            this.splitContainer_showDiff.Panel2.Controls.Add(this.groupBox_showDiff_remote);
            this.splitContainer_showDiff.Size = new System.Drawing.Size(584, 403);
            this.splitContainer_showDiff.SplitterDistance = 292;
            this.splitContainer_showDiff.TabIndex = 2;
            // 
            // GUIShowDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 403);
            this.Controls.Add(this.splitContainer_showDiff);
            this.Name = "GUIShowDiff";
            this.Text = "GUIShowDiff";
            this.groupBox_showDiff_local.ResumeLayout(false);
            this.groupBox_showDiff_remote.ResumeLayout(false);
            this.splitContainer_showDiff.Panel1.ResumeLayout(false);
            this.splitContainer_showDiff.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_showDiff)).EndInit();
            this.splitContainer_showDiff.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_showDiff_local;
        private System.Windows.Forms.GroupBox groupBox_showDiff_remote;
        private System.Windows.Forms.SplitContainer splitContainer_showDiff;
        private System.Windows.Forms.ListBox listBox_showDiff_local_filesToDownload;
        private System.Windows.Forms.Button b_showDiff_local_download;
        private System.Windows.Forms.Button b_showDiff_local_remove;
        private System.Windows.Forms.Button b_showDiff_local_add;
        private System.Windows.Forms.ListBox listBox_showDiff_local_missingFiles;
        private System.Windows.Forms.ListBox listBox_showDiff_remote_filesToUpload;
        private System.Windows.Forms.Button b_showDiff_remote_upload;
        private System.Windows.Forms.Button b_showDiff_remote_remove;
        private System.Windows.Forms.Button b_showDiff_remote_add;
        private System.Windows.Forms.ListBox listBox_showDiff_remote_missingFiles;
    }
}