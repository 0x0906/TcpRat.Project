namespace Server.Forms
{
    partial class DesktopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesktopForm));
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.desktopPicBox = new System.Windows.Forms.PictureBox();
            this.ConnectionCheckup = new System.Windows.Forms.Timer(this.components);
            this.screensCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FPSCounter = new System.Windows.Forms.Timer(this.components);
            this.fpsLbl = new System.Windows.Forms.Label();
            this.mouseCkBx = new System.Windows.Forms.CheckBox();
            this.keyboardCkBx = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.qualityComboBx = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.desktopPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startBtn.Location = new System.Drawing.Point(5, 372);
            this.startBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(88, 37);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(99, 372);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(88, 37);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // desktopPicBox
            // 
            this.desktopPicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.desktopPicBox.Location = new System.Drawing.Point(5, 5);
            this.desktopPicBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.desktopPicBox.Name = "desktopPicBox";
            this.desktopPicBox.Size = new System.Drawing.Size(685, 358);
            this.desktopPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.desktopPicBox.TabIndex = 0;
            this.desktopPicBox.TabStop = false;
            this.desktopPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.desktopPicBox_MouseDown);
            this.desktopPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.desktopPicBox_MouseMove);
            this.desktopPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.desktopPicBox_MouseUp);
            // 
            // ConnectionCheckup
            // 
            this.ConnectionCheckup.Enabled = true;
            this.ConnectionCheckup.Interval = 500;
            this.ConnectionCheckup.Tick += new System.EventHandler(this.ConnectionCheckup_Tick);
            // 
            // screensCombo
            // 
            this.screensCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.screensCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screensCombo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screensCombo.FormattingEnabled = true;
            this.screensCombo.Location = new System.Drawing.Point(583, 377);
            this.screensCombo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.screensCombo.Name = "screensCombo";
            this.screensCombo.Size = new System.Drawing.Size(108, 25);
            this.screensCombo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(527, 380);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Screens:";
            // 
            // FPSCounter
            // 
            this.FPSCounter.Interval = 1000;
            this.FPSCounter.Tick += new System.EventHandler(this.FPSCounter_Tick);
            // 
            // fpsLbl
            // 
            this.fpsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fpsLbl.AutoSize = true;
            this.fpsLbl.Location = new System.Drawing.Point(194, 383);
            this.fpsLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fpsLbl.Name = "fpsLbl";
            this.fpsLbl.Size = new System.Drawing.Size(29, 15);
            this.fpsLbl.TabIndex = 5;
            this.fpsLbl.Text = "FPS:";
            // 
            // mouseCkBx
            // 
            this.mouseCkBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mouseCkBx.AutoSize = true;
            this.mouseCkBx.Location = new System.Drawing.Point(259, 381);
            this.mouseCkBx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mouseCkBx.Name = "mouseCkBx";
            this.mouseCkBx.Size = new System.Drawing.Size(62, 19);
            this.mouseCkBx.TabIndex = 6;
            this.mouseCkBx.Text = "Mouse";
            this.mouseCkBx.UseVisualStyleBackColor = true;
            // 
            // keyboardCkBx
            // 
            this.keyboardCkBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.keyboardCkBx.AutoSize = true;
            this.keyboardCkBx.Location = new System.Drawing.Point(327, 381);
            this.keyboardCkBx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.keyboardCkBx.Name = "keyboardCkBx";
            this.keyboardCkBx.Size = new System.Drawing.Size(76, 19);
            this.keyboardCkBx.TabIndex = 7;
            this.keyboardCkBx.Text = "Keyboard";
            this.keyboardCkBx.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(404, 380);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Quality:";
            // 
            // qualityComboBx
            // 
            this.qualityComboBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.qualityComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityComboBx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qualityComboBx.FormattingEnabled = true;
            this.qualityComboBx.Location = new System.Drawing.Point(455, 377);
            this.qualityComboBx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.qualityComboBx.Name = "qualityComboBx";
            this.qualityComboBx.Size = new System.Drawing.Size(63, 25);
            this.qualityComboBx.TabIndex = 8;
            // 
            // DesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 417);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.qualityComboBx);
            this.Controls.Add(this.keyboardCkBx);
            this.Controls.Add(this.mouseCkBx);
            this.Controls.Add(this.fpsLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.screensCombo);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.desktopPicBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DesktopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DesktopForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DesktopForm_FormClosing);
            this.Load += new System.EventHandler(this.DesktopForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DesktopForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DesktopForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.desktopPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
        public System.Windows.Forms.Timer ConnectionCheckup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer FPSCounter;
        private System.Windows.Forms.Label fpsLbl;
        public System.Windows.Forms.PictureBox desktopPicBox;
        public System.Windows.Forms.ComboBox screensCombo;
        private System.Windows.Forms.CheckBox mouseCkBx;
        private System.Windows.Forms.CheckBox keyboardCkBx;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox qualityComboBx;
    }
}