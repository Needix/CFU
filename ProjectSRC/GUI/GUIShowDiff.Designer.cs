namespace Custom_FTP_Uploader.ProjectSRC.GUI {
    partial class GUIShowDiff {
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
            this.groupBox_showDiff_remote = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBox_showDiff_local
            // 
            this.groupBox_showDiff_local.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox_showDiff_local.Location = new System.Drawing.Point(0, 0);
            this.groupBox_showDiff_local.Name = "groupBox_showDiff_local";
            this.groupBox_showDiff_local.Size = new System.Drawing.Size(200, 403);
            this.groupBox_showDiff_local.TabIndex = 0;
            this.groupBox_showDiff_local.TabStop = false;
            this.groupBox_showDiff_local.Text = "Local Missing Files/Folder";
            // 
            // groupBox_showDiff_remote
            // 
            this.groupBox_showDiff_remote.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox_showDiff_remote.Location = new System.Drawing.Point(384, 0);
            this.groupBox_showDiff_remote.Name = "groupBox_showDiff_remote";
            this.groupBox_showDiff_remote.Size = new System.Drawing.Size(200, 403);
            this.groupBox_showDiff_remote.TabIndex = 1;
            this.groupBox_showDiff_remote.TabStop = false;
            this.groupBox_showDiff_remote.Text = "Remote Missing Files/Folder";
            // 
            // GUIShowDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 403);
            this.Controls.Add(this.groupBox_showDiff_remote);
            this.Controls.Add(this.groupBox_showDiff_local);
            this.Name = "GUIShowDiff";
            this.Text = "GUIShowDiff";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_showDiff_local;
        private System.Windows.Forms.GroupBox groupBox_showDiff_remote;
    }
}