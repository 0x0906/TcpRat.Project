namespace Server.Forms.UtilsForm
{
    partial class DownUp_loadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownUp_loadForm));
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.fileSizeLbl = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ConnectionCheckup = new System.Windows.Forms.Timer(this.components);
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.UidLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Location = new System.Drawing.Point(13, 11);
            this.fileNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(81, 17);
            this.fileNameLbl.TabIndex = 0;
            this.fileNameLbl.Text = "File name ->";
            // 
            // fileSizeLbl
            // 
            this.fileSizeLbl.AutoSize = true;
            this.fileSizeLbl.Location = new System.Drawing.Point(13, 41);
            this.fileSizeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileSizeLbl.Name = "fileSizeLbl";
            this.fileSizeLbl.Size = new System.Drawing.Size(71, 17);
            this.fileSizeLbl.TabIndex = 1;
            this.fileSizeLbl.Text = "File size ->";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(13, 104);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(61, 17);
            this.statusLbl.TabIndex = 2;
            this.statusLbl.Text = "Status ->";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(16, 133);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(377, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // ConnectionCheckup
            // 
            this.ConnectionCheckup.Enabled = true;
            this.ConnectionCheckup.Interval = 500;
            this.ConnectionCheckup.Tick += new System.EventHandler(this.ConnectionCheckup_Tick);
            // 
            // Update
            // 
            this.Update.Enabled = true;
            this.Update.Interval = 10;
            this.Update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // UidLbl
            // 
            this.UidLbl.AutoSize = true;
            this.UidLbl.Location = new System.Drawing.Point(13, 73);
            this.UidLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UidLbl.Name = "UidLbl";
            this.UidLbl.Size = new System.Drawing.Size(46, 17);
            this.UidLbl.TabIndex = 4;
            this.UidLbl.Text = "Uid ->";
            // 
            // DownUp_loadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 169);
            this.Controls.Add(this.UidLbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.fileSizeLbl);
            this.Controls.Add(this.fileNameLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownUp_loadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DownUp_loadForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.Label fileSizeLbl;
        private System.Windows.Forms.Label statusLbl;
        public System.Windows.Forms.Timer ConnectionCheckup;
        public System.Windows.Forms.Timer Update;
        public System.Windows.Forms.Label UidLbl;
        public System.Windows.Forms.ProgressBar progressBar1;
    }
}