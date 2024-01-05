namespace Server.Forms.UtilsForm
{
    partial class ProcessManager_InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessManager_InfoForm));
            this.processIcon = new System.Windows.Forms.PictureBox();
            this.processInfoTxtBx = new System.Windows.Forms.TextBox();
            this.saveIconBtn = new System.Windows.Forms.Button();
            this.saveInfoBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.processIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // processIcon
            // 
            this.processIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.processIcon.Location = new System.Drawing.Point(357, 7);
            this.processIcon.Margin = new System.Windows.Forms.Padding(4);
            this.processIcon.Name = "processIcon";
            this.processIcon.Size = new System.Drawing.Size(71, 68);
            this.processIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.processIcon.TabIndex = 0;
            this.processIcon.TabStop = false;
            // 
            // processInfoTxtBx
            // 
            this.processInfoTxtBx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processInfoTxtBx.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.processInfoTxtBx.Location = new System.Drawing.Point(6, 7);
            this.processInfoTxtBx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.processInfoTxtBx.Multiline = true;
            this.processInfoTxtBx.Name = "processInfoTxtBx";
            this.processInfoTxtBx.ReadOnly = true;
            this.processInfoTxtBx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.processInfoTxtBx.Size = new System.Drawing.Size(345, 272);
            this.processInfoTxtBx.TabIndex = 3;
            // 
            // saveIconBtn
            // 
            this.saveIconBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveIconBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.saveIconBtn.Location = new System.Drawing.Point(357, 247);
            this.saveIconBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveIconBtn.Name = "saveIconBtn";
            this.saveIconBtn.Size = new System.Drawing.Size(71, 31);
            this.saveIconBtn.TabIndex = 2;
            this.saveIconBtn.Text = "Save Icon";
            this.saveIconBtn.UseVisualStyleBackColor = true;
            this.saveIconBtn.Click += new System.EventHandler(this.saveIconBtn_Click);
            // 
            // saveInfoBtn
            // 
            this.saveInfoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveInfoBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.saveInfoBtn.Location = new System.Drawing.Point(357, 209);
            this.saveInfoBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveInfoBtn.Name = "saveInfoBtn";
            this.saveInfoBtn.Size = new System.Drawing.Size(71, 31);
            this.saveInfoBtn.TabIndex = 1;
            this.saveInfoBtn.Text = "Save Info";
            this.saveInfoBtn.UseVisualStyleBackColor = true;
            this.saveInfoBtn.Click += new System.EventHandler(this.saveInfoBtn_Click);
            // 
            // ProcessManager_InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 282);
            this.Controls.Add(this.saveInfoBtn);
            this.Controls.Add(this.saveIconBtn);
            this.Controls.Add(this.processInfoTxtBx);
            this.Controls.Add(this.processIcon);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProcessManager_InfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProcessManager_InfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.processIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox processInfoTxtBx;
        private System.Windows.Forms.Button saveIconBtn;
        private System.Windows.Forms.Button saveInfoBtn;
        public System.Windows.Forms.PictureBox processIcon;
    }
}