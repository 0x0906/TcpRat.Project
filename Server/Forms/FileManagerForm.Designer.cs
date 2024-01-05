namespace Server.Forms
{
    partial class FileManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManagerForm));
            this.ConnectionCheckup = new System.Windows.Forms.Timer(this.components);
            this.fileManagerView = new System.Windows.Forms.ListView();
            this.name_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePath_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileManagerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appdataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localAppdataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.copyAsPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.searchFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.visibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.drivesCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pathTxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.waitLbl = new System.Windows.Forms.Label();
            this.countLbl = new System.Windows.Forms.Label();
            this.searchFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileManagerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectionCheckup
            // 
            this.ConnectionCheckup.Enabled = true;
            this.ConnectionCheckup.Interval = 500;
            this.ConnectionCheckup.Tick += new System.EventHandler(this.ConnectionCheckup_Tick);
            // 
            // fileManagerView
            // 
            this.fileManagerView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileManagerView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileManagerView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name_ch,
            this.date_ch,
            this.type_ch,
            this.size_ch,
            this.filePath_ch});
            this.fileManagerView.ContextMenuStrip = this.fileManagerMenu;
            this.fileManagerView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileManagerView.FullRowSelect = true;
            this.fileManagerView.HideSelection = false;
            this.fileManagerView.Location = new System.Drawing.Point(10, 41);
            this.fileManagerView.Name = "fileManagerView";
            this.fileManagerView.Size = new System.Drawing.Size(611, 295);
            this.fileManagerView.SmallImageList = this.Icons;
            this.fileManagerView.TabIndex = 2;
            this.fileManagerView.UseCompatibleStateImageBehavior = false;
            this.fileManagerView.View = System.Windows.Forms.View.Details;
            this.fileManagerView.DoubleClick += new System.EventHandler(this.fileManagerView_DoubleClick);
            // 
            // name_ch
            // 
            this.name_ch.Text = "Name";
            this.name_ch.Width = 140;
            // 
            // date_ch
            // 
            this.date_ch.Text = "Date";
            this.date_ch.Width = 110;
            // 
            // type_ch
            // 
            this.type_ch.Text = "Type";
            this.type_ch.Width = 110;
            // 
            // size_ch
            // 
            this.size_ch.Text = "Size";
            this.size_ch.Width = 110;
            // 
            // filePath_ch
            // 
            this.filePath_ch.Text = "File Path";
            this.filePath_ch.Width = 69;
            // 
            // fileManagerMenu
            // 
            this.fileManagerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.editToolStripMenuItem,
            this.goToToolStripMenuItem,
            this.toolStripSeparator7,
            this.copyAsPathToolStripMenuItem,
            this.toolStripSeparator3,
            this.refreshToolStripMenuItem,
            this.backToolStripMenuItem,
            this.toolStripSeparator5,
            this.uploadToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator6,
            this.searchFileToolStripMenuItem1,
            this.toolStripSeparator2,
            this.newToolStripMenuItem,
            this.toolStripSeparator8,
            this.visibilityToolStripMenuItem});
            this.fileManagerMenu.Name = "fileManagerMenu";
            this.fileManagerMenu.Size = new System.Drawing.Size(131, 382);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userProfileToolStripMenuItem,
            this.desktopToolStripMenuItem,
            this.documentsToolStripMenuItem,
            this.downloadsToolStripMenuItem,
            this.musicToolStripMenuItem,
            this.pictureToolStripMenuItem,
            this.videosToolStripMenuItem,
            this.startupToolStripMenuItem,
            this.appdataToolStripMenuItem,
            this.localAppdataToolStripMenuItem,
            this.tempToolStripMenuItem,
            this.oneDriveToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.goToToolStripMenuItem.Text = "GoTo";
            // 
            // userProfileToolStripMenuItem
            // 
            this.userProfileToolStripMenuItem.Name = "userProfileToolStripMenuItem";
            this.userProfileToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.userProfileToolStripMenuItem.Text = "UserProfile";
            this.userProfileToolStripMenuItem.Click += new System.EventHandler(this.userProfileToolStripMenuItem_Click);
            // 
            // desktopToolStripMenuItem
            // 
            this.desktopToolStripMenuItem.Name = "desktopToolStripMenuItem";
            this.desktopToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.desktopToolStripMenuItem.Text = "Desktop";
            this.desktopToolStripMenuItem.Click += new System.EventHandler(this.desktopToolStripMenuItem_Click);
            // 
            // documentsToolStripMenuItem
            // 
            this.documentsToolStripMenuItem.Name = "documentsToolStripMenuItem";
            this.documentsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.documentsToolStripMenuItem.Text = "Documents";
            this.documentsToolStripMenuItem.Click += new System.EventHandler(this.documentsToolStripMenuItem_Click);
            // 
            // downloadsToolStripMenuItem
            // 
            this.downloadsToolStripMenuItem.Name = "downloadsToolStripMenuItem";
            this.downloadsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.downloadsToolStripMenuItem.Text = "Downloads";
            this.downloadsToolStripMenuItem.Click += new System.EventHandler(this.downloadsToolStripMenuItem_Click);
            // 
            // musicToolStripMenuItem
            // 
            this.musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            this.musicToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.musicToolStripMenuItem.Text = "Music";
            this.musicToolStripMenuItem.Click += new System.EventHandler(this.musicToolStripMenuItem_Click);
            // 
            // pictureToolStripMenuItem
            // 
            this.pictureToolStripMenuItem.Name = "pictureToolStripMenuItem";
            this.pictureToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.pictureToolStripMenuItem.Text = "Pictures";
            this.pictureToolStripMenuItem.Click += new System.EventHandler(this.pictureToolStripMenuItem_Click);
            // 
            // videosToolStripMenuItem
            // 
            this.videosToolStripMenuItem.Name = "videosToolStripMenuItem";
            this.videosToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.videosToolStripMenuItem.Text = "Videos";
            this.videosToolStripMenuItem.Click += new System.EventHandler(this.videosToolStripMenuItem_Click);
            // 
            // startupToolStripMenuItem
            // 
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            this.startupToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.startupToolStripMenuItem.Text = "Startup";
            this.startupToolStripMenuItem.Click += new System.EventHandler(this.startupToolStripMenuItem_Click);
            // 
            // appdataToolStripMenuItem
            // 
            this.appdataToolStripMenuItem.Name = "appdataToolStripMenuItem";
            this.appdataToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.appdataToolStripMenuItem.Text = "Appdata";
            this.appdataToolStripMenuItem.Click += new System.EventHandler(this.appdataToolStripMenuItem_Click);
            // 
            // localAppdataToolStripMenuItem
            // 
            this.localAppdataToolStripMenuItem.Name = "localAppdataToolStripMenuItem";
            this.localAppdataToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.localAppdataToolStripMenuItem.Text = "LocalAppdata";
            this.localAppdataToolStripMenuItem.Click += new System.EventHandler(this.localAppdataToolStripMenuItem_Click);
            // 
            // tempToolStripMenuItem
            // 
            this.tempToolStripMenuItem.Name = "tempToolStripMenuItem";
            this.tempToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.tempToolStripMenuItem.Text = "Temp";
            this.tempToolStripMenuItem.Click += new System.EventHandler(this.tempToolStripMenuItem_Click);
            // 
            // oneDriveToolStripMenuItem
            // 
            this.oneDriveToolStripMenuItem.Name = "oneDriveToolStripMenuItem";
            this.oneDriveToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.oneDriveToolStripMenuItem.Text = "OneDrive";
            this.oneDriveToolStripMenuItem.Click += new System.EventHandler(this.oneDriveToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.windowsToolStripMenuItem.Text = "Windows";
            this.windowsToolStripMenuItem.Click += new System.EventHandler(this.windowsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(127, 6);
            // 
            // copyAsPathToolStripMenuItem
            // 
            this.copyAsPathToolStripMenuItem.Name = "copyAsPathToolStripMenuItem";
            this.copyAsPathToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.copyAsPathToolStripMenuItem.Text = "Copy Path";
            this.copyAsPathToolStripMenuItem.Click += new System.EventHandler(this.copyAsPathToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(127, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(127, 6);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(127, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(127, 6);
            // 
            // searchFileToolStripMenuItem1
            // 
            this.searchFileToolStripMenuItem1.Name = "searchFileToolStripMenuItem1";
            this.searchFileToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.searchFileToolStripMenuItem1.Text = "Search File";
            this.searchFileToolStripMenuItem1.Click += new System.EventHandler(this.searchFileToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(127, 6);
            // 
            // visibilityToolStripMenuItem
            // 
            this.visibilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.visibilityToolStripMenuItem.Name = "visibilityToolStripMenuItem";
            this.visibilityToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.visibilityToolStripMenuItem.Text = "Visibility";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // Icons
            // 
            this.Icons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.Icons.ImageSize = new System.Drawing.Size(32, 32);
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // drivesCombo
            // 
            this.drivesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drivesCombo.FormattingEnabled = true;
            this.drivesCombo.Location = new System.Drawing.Point(51, 8);
            this.drivesCombo.Name = "drivesCombo";
            this.drivesCombo.Size = new System.Drawing.Size(63, 23);
            this.drivesCombo.TabIndex = 3;
            this.drivesCombo.SelectedIndexChanged += new System.EventHandler(this.drivesCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Drives:";
            // 
            // pathTxtbox
            // 
            this.pathTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTxtbox.Location = new System.Drawing.Point(161, 8);
            this.pathTxtbox.Name = "pathTxtbox";
            this.pathTxtbox.ReadOnly = true;
            this.pathTxtbox.Size = new System.Drawing.Size(314, 23);
            this.pathTxtbox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Path:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(486, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(557, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 29);
            this.button2.TabIndex = 8;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // waitLbl
            // 
            this.waitLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.waitLbl.AutoSize = true;
            this.waitLbl.BackColor = System.Drawing.Color.Transparent;
            this.waitLbl.Location = new System.Drawing.Point(295, 174);
            this.waitLbl.Name = "waitLbl";
            this.waitLbl.Size = new System.Drawing.Size(40, 15);
            this.waitLbl.TabIndex = 9;
            this.waitLbl.Text = "Wait...";
            // 
            // countLbl
            // 
            this.countLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.countLbl.AutoSize = true;
            this.countLbl.Location = new System.Drawing.Point(7, 342);
            this.countLbl.Name = "countLbl";
            this.countLbl.Size = new System.Drawing.Size(138, 15);
            this.countLbl.TabIndex = 10;
            this.countLbl.Text = "[00]  Files       [00] Folders";
            // 
            // searchFileToolStripMenuItem
            // 
            this.searchFileToolStripMenuItem.Name = "searchFileToolStripMenuItem";
            this.searchFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.searchFileToolStripMenuItem.Text = "Search File";
            // 
            // FileManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 363);
            this.Controls.Add(this.countLbl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathTxtbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drivesCombo);
            this.Controls.Add(this.fileManagerView);
            this.Controls.Add(this.waitLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FileManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilemanagerForm";
            this.fileManagerMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer ConnectionCheckup;
        private System.Windows.Forms.ColumnHeader name_ch;
        private System.Windows.Forms.ColumnHeader date_ch;
        private System.Windows.Forms.ColumnHeader size_ch;
        public System.Windows.Forms.ListView fileManagerView;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox drivesCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox pathTxtbox;
        public System.Windows.Forms.ColumnHeader type_ch;
        public System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.ContextMenuStrip fileManagerMenu;
        public System.Windows.Forms.Label waitLbl;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appdataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localAppdataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tempToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneDriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.Label countLbl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem searchFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader filePath_ch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem copyAsPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visibilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}