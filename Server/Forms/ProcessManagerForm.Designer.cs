namespace Server.Forms
{
    partial class ProcessManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessManagerForm));
            this.processView = new System.Windows.Forms.ListView();
            this.name_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.window_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.state_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processManagerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.suspendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processIcon = new System.Windows.Forms.ImageList(this.components);
            this.ConnectionCheckup = new System.Windows.Forms.Timer(this.components);
            this.processLbl = new System.Windows.Forms.Label();
            this.waitLbl = new System.Windows.Forms.Label();
            this.processManagerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // processView
            // 
            this.processView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.processView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name_col,
            this.id_col,
            this.window_col,
            this.state_col});
            this.processView.ContextMenuStrip = this.processManagerMenu;
            this.processView.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.processView.FullRowSelect = true;
            this.processView.GridLines = true;
            this.processView.HideSelection = false;
            this.processView.Location = new System.Drawing.Point(1, 0);
            this.processView.Name = "processView";
            this.processView.Size = new System.Drawing.Size(530, 357);
            this.processView.SmallImageList = this.processIcon;
            this.processView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.processView.TabIndex = 0;
            this.processView.UseCompatibleStateImageBehavior = false;
            this.processView.View = System.Windows.Forms.View.Details;
            // 
            // name_col
            // 
            this.name_col.Text = "Name";
            this.name_col.Width = 117;
            // 
            // id_col
            // 
            this.id_col.Text = "ID";
            this.id_col.Width = 69;
            // 
            // window_col
            // 
            this.window_col.Text = "Window";
            this.window_col.Width = 84;
            // 
            // state_col
            // 
            this.state_col.Text = "State";
            this.state_col.Width = 79;
            // 
            // processManagerMenu
            // 
            this.processManagerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.toolStripSeparator2,
            this.refreshToolStripMenuItem,
            this.killToolStripMenuItem,
            this.toolStripSeparator1,
            this.suspendToolStripMenuItem,
            this.resumeToolStripMenuItem});
            this.processManagerMenu.Name = "processManagerMenu";
            this.processManagerMenu.Size = new System.Drawing.Size(120, 126);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(116, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // suspendToolStripMenuItem
            // 
            this.suspendToolStripMenuItem.Name = "suspendToolStripMenuItem";
            this.suspendToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.suspendToolStripMenuItem.Text = "Suspend";
            this.suspendToolStripMenuItem.Click += new System.EventHandler(this.suspendToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.resumeToolStripMenuItem.Text = "Resume";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
            // 
            // processIcon
            // 
            this.processIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.processIcon.ImageSize = new System.Drawing.Size(20, 20);
            this.processIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ConnectionCheckup
            // 
            this.ConnectionCheckup.Enabled = true;
            this.ConnectionCheckup.Interval = 500;
            this.ConnectionCheckup.Tick += new System.EventHandler(this.ConnectionCheckup_Tick);
            // 
            // processLbl
            // 
            this.processLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.processLbl.AutoSize = true;
            this.processLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.processLbl.Location = new System.Drawing.Point(1, 361);
            this.processLbl.Name = "processLbl";
            this.processLbl.Size = new System.Drawing.Size(85, 13);
            this.processLbl.TabIndex = 2;
            this.processLbl.Text = "[ 00 ] Processes";
            // 
            // waitLbl
            // 
            this.waitLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.waitLbl.AutoSize = true;
            this.waitLbl.BackColor = System.Drawing.Color.Transparent;
            this.waitLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitLbl.Location = new System.Drawing.Point(245, 182);
            this.waitLbl.Name = "waitLbl";
            this.waitLbl.Size = new System.Drawing.Size(42, 17);
            this.waitLbl.TabIndex = 3;
            this.waitLbl.Text = "Wait...";
            // 
            // ProcessManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 380);
            this.Controls.Add(this.processLbl);
            this.Controls.Add(this.processView);
            this.Controls.Add(this.waitLbl);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProcessManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProcessManagerForm";
            this.Load += new System.EventHandler(this.ProcessManagerForm_Load);
            this.processManagerMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer ConnectionCheckup;
        private System.Windows.Forms.ColumnHeader name_col;
        private System.Windows.Forms.ColumnHeader id_col;
        public System.Windows.Forms.ListView processView;
        private System.Windows.Forms.ContextMenuStrip processManagerMenu;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem suspendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        public System.Windows.Forms.Label processLbl;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ImageList processIcon;
        private System.Windows.Forms.ColumnHeader window_col;
        private System.Windows.Forms.ColumnHeader state_col;
        public System.Windows.Forms.Label waitLbl;
    }
}