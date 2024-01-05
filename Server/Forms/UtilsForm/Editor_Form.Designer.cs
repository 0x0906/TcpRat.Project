namespace Server.Forms.UtilsForm
{
    partial class Editor_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor_Form));
            this.editorTxtbox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.fileSizeLbl = new System.Windows.Forms.Label();
            this.ConnectionCheckup = new System.Windows.Forms.Timer(this.components);
            this.uidLbl = new System.Windows.Forms.Label();
            this.languageLbl = new System.Windows.Forms.Label();
            this.refreshBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editorTxtbox)).BeginInit();
            this.SuspendLayout();
            // 
            // editorTxtbox
            // 
            this.editorTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorTxtbox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.editorTxtbox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.editorTxtbox.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.editorTxtbox.BackBrush = null;
            this.editorTxtbox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.editorTxtbox.CharHeight = 14;
            this.editorTxtbox.CharWidth = 8;
            this.editorTxtbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.editorTxtbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.editorTxtbox.IsReplaceMode = false;
            this.editorTxtbox.LeftBracket = '(';
            this.editorTxtbox.LeftBracket2 = '{';
            this.editorTxtbox.Location = new System.Drawing.Point(2, 2);
            this.editorTxtbox.Margin = new System.Windows.Forms.Padding(4);
            this.editorTxtbox.Name = "editorTxtbox";
            this.editorTxtbox.Paddings = new System.Windows.Forms.Padding(0);
            this.editorTxtbox.RightBracket = ')';
            this.editorTxtbox.RightBracket2 = '}';
            this.editorTxtbox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.editorTxtbox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("editorTxtbox.ServiceColors")));
            this.editorTxtbox.Size = new System.Drawing.Size(503, 268);
            this.editorTxtbox.TabIndex = 0;
            this.editorTxtbox.WordWrap = true;
            this.editorTxtbox.Zoom = 100;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(396, 335);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(108, 29);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Location = new System.Drawing.Point(3, 299);
            this.fileNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(73, 17);
            this.fileNameLbl.TabIndex = 3;
            this.fileNameLbl.Text = "File Name: ";
            // 
            // fileSizeLbl
            // 
            this.fileSizeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileSizeLbl.AutoSize = true;
            this.fileSizeLbl.Location = new System.Drawing.Point(3, 323);
            this.fileSizeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileSizeLbl.Name = "fileSizeLbl";
            this.fileSizeLbl.Size = new System.Drawing.Size(61, 17);
            this.fileSizeLbl.TabIndex = 4;
            this.fileSizeLbl.Text = "File Size: ";
            // 
            // ConnectionCheckup
            // 
            this.ConnectionCheckup.Enabled = true;
            this.ConnectionCheckup.Interval = 500;
            this.ConnectionCheckup.Tick += new System.EventHandler(this.ConnectionCheckup_Tick);
            // 
            // uidLbl
            // 
            this.uidLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uidLbl.AutoSize = true;
            this.uidLbl.Location = new System.Drawing.Point(3, 345);
            this.uidLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uidLbl.Name = "uidLbl";
            this.uidLbl.Size = new System.Drawing.Size(31, 17);
            this.uidLbl.TabIndex = 5;
            this.uidLbl.Text = "Uid:";
            // 
            // languageLbl
            // 
            this.languageLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.languageLbl.AutoSize = true;
            this.languageLbl.Location = new System.Drawing.Point(3, 275);
            this.languageLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.languageLbl.Name = "languageLbl";
            this.languageLbl.Size = new System.Drawing.Size(72, 17);
            this.languageLbl.TabIndex = 6;
            this.languageLbl.Text = "Language: ";
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Location = new System.Drawing.Point(396, 300);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(108, 29);
            this.refreshBtn.TabIndex = 7;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // Editor_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 367);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.languageLbl);
            this.Controls.Add(this.uidLbl);
            this.Controls.Add(this.fileSizeLbl);
            this.Controls.Add(this.fileNameLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.editorTxtbox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Editor_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor_Form";
            ((System.ComponentModel.ISupportInitialize)(this.editorTxtbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label fileNameLbl;
        public System.Windows.Forms.Label fileSizeLbl;
        public FastColoredTextBoxNS.FastColoredTextBox editorTxtbox;
        public System.Windows.Forms.Button saveBtn;
        public System.Windows.Forms.Timer ConnectionCheckup;
        public System.Windows.Forms.Label uidLbl;
        public System.Windows.Forms.Label languageLbl;
        public System.Windows.Forms.Button refreshBtn;
    }
}