namespace Server.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.clientView = new System.Windows.Forms.ListView();
            this.ip_port_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.country_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uid_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.os_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filemanagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.builderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.portView = new System.Windows.Forms.ListView();
            this.port_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PortsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.logView = new System.Windows.Forms.ListView();
            this.time_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.log_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.autoListenCb = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ClientsMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.PortsMenu.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(692, 398);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.clientView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(684, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Clients";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // clientView
            // 
            this.clientView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ip_port_ch,
            this.country_ch,
            this.user_ch,
            this.uid_ch,
            this.os_ch});
            this.clientView.ContextMenuStrip = this.ClientsMenu;
            this.clientView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientView.FullRowSelect = true;
            this.clientView.GridLines = true;
            this.clientView.HideSelection = false;
            this.clientView.Location = new System.Drawing.Point(3, 3);
            this.clientView.Name = "clientView";
            this.clientView.Size = new System.Drawing.Size(678, 366);
            this.clientView.TabIndex = 0;
            this.clientView.UseCompatibleStateImageBehavior = false;
            this.clientView.View = System.Windows.Forms.View.Details;
            // 
            // ip_port_ch
            // 
            this.ip_port_ch.Text = "IP : Port";
            this.ip_port_ch.Width = 120;
            // 
            // country_ch
            // 
            this.country_ch.Text = "Country";
            this.country_ch.Width = 110;
            // 
            // user_ch
            // 
            this.user_ch.Text = "User";
            this.user_ch.Width = 120;
            // 
            // uid_ch
            // 
            this.uid_ch.Text = "Uid";
            this.uid_ch.Width = 129;
            // 
            // os_ch
            // 
            this.os_ch.Text = "Os";
            this.os_ch.Width = 110;
            // 
            // ClientsMenu
            // 
            this.ClientsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.shellToolStripMenuItem,
            this.desktopToolStripMenuItem,
            this.filemanagerToolStripMenuItem,
            this.processManagerToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.pcToolStripMenuItem,
            this.toolStripSeparator2,
            this.builderToolStripMenuItem});
            this.ClientsMenu.Name = "ClientsMenu";
            this.ClientsMenu.Size = new System.Drawing.Size(162, 186);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // shellToolStripMenuItem
            // 
            this.shellToolStripMenuItem.Name = "shellToolStripMenuItem";
            this.shellToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.shellToolStripMenuItem.Text = "Shell";
            this.shellToolStripMenuItem.Click += new System.EventHandler(this.shellToolStripMenuItem_Click);
            // 
            // desktopToolStripMenuItem
            // 
            this.desktopToolStripMenuItem.Name = "desktopToolStripMenuItem";
            this.desktopToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.desktopToolStripMenuItem.Text = "Desktop";
            this.desktopToolStripMenuItem.Click += new System.EventHandler(this.desktopToolStripMenuItem_Click);
            // 
            // filemanagerToolStripMenuItem
            // 
            this.filemanagerToolStripMenuItem.Name = "filemanagerToolStripMenuItem";
            this.filemanagerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.filemanagerToolStripMenuItem.Text = "FileManager";
            this.filemanagerToolStripMenuItem.Click += new System.EventHandler(this.filemanagerToolStripMenuItem_Click);
            // 
            // processManagerToolStripMenuItem
            // 
            this.processManagerToolStripMenuItem.Name = "processManagerToolStripMenuItem";
            this.processManagerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.processManagerToolStripMenuItem.Text = "ProcessManager";
            this.processManagerToolStripMenuItem.Click += new System.EventHandler(this.processManagerToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killToolStripMenuItem,
            this.reconnectToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.reconnectToolStripMenuItem.Text = "Reconnect";
            this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.reconnectToolStripMenuItem_Click);
            // 
            // pcToolStripMenuItem
            // 
            this.pcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOffToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.pcToolStripMenuItem.Name = "pcToolStripMenuItem";
            this.pcToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.pcToolStripMenuItem.Text = "System";
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.logOffToolStripMenuItem.Text = "Log Off";
            this.logOffToolStripMenuItem.Click += new System.EventHandler(this.logOffToolStripMenuItem_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // builderToolStripMenuItem
            // 
            this.builderToolStripMenuItem.Name = "builderToolStripMenuItem";
            this.builderToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.builderToolStripMenuItem.Text = "Builder";
            this.builderToolStripMenuItem.Click += new System.EventHandler(this.builderToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.portView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(684, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ports";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // portView
            // 
            this.portView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.port_ch,
            this.status_ch});
            this.portView.ContextMenuStrip = this.PortsMenu;
            this.portView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portView.FullRowSelect = true;
            this.portView.GridLines = true;
            this.portView.HideSelection = false;
            this.portView.Location = new System.Drawing.Point(3, 3);
            this.portView.Name = "portView";
            this.portView.Size = new System.Drawing.Size(678, 366);
            this.portView.TabIndex = 1;
            this.portView.UseCompatibleStateImageBehavior = false;
            this.portView.View = System.Windows.Forms.View.Details;
            // 
            // port_ch
            // 
            this.port_ch.Text = "Port";
            this.port_ch.Width = 135;
            // 
            // status_ch
            // 
            this.status_ch.Text = "Status";
            this.status_ch.Width = 149;
            // 
            // PortsMenu
            // 
            this.PortsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listenToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.PortsMenu.Name = "PortsMenu";
            this.PortsMenu.Size = new System.Drawing.Size(118, 76);
            // 
            // listenToolStripMenuItem
            // 
            this.listenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.listenToolStripMenuItem.Name = "listenToolStripMenuItem";
            this.listenToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.listenToolStripMenuItem.Text = "Listen";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.logView);
            this.tabPage3.Controls.Add(this.autoListenCb);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(684, 372);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // logView
            // 
            this.logView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time_ch,
            this.log_ch});
            this.logView.FullRowSelect = true;
            this.logView.GridLines = true;
            this.logView.HideSelection = false;
            this.logView.Location = new System.Drawing.Point(8, 29);
            this.logView.Name = "logView";
            this.logView.Size = new System.Drawing.Size(668, 337);
            this.logView.TabIndex = 1;
            this.logView.UseCompatibleStateImageBehavior = false;
            this.logView.View = System.Windows.Forms.View.Details;
            // 
            // time_ch
            // 
            this.time_ch.Text = "Time";
            this.time_ch.Width = 127;
            // 
            // log_ch
            // 
            this.log_ch.Text = "Connection Log";
            this.log_ch.Width = 537;
            // 
            // autoListenCb
            // 
            this.autoListenCb.AutoSize = true;
            this.autoListenCb.Location = new System.Drawing.Point(8, 7);
            this.autoListenCb.Name = "autoListenCb";
            this.autoListenCb.Size = new System.Drawing.Size(82, 17);
            this.autoListenCb.TabIndex = 0;
            this.autoListenCb.Text = "Auto Listen";
            this.autoListenCb.UseVisualStyleBackColor = true;
            this.autoListenCb.Click += new System.EventHandler(this.autoListenCb_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 398);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ClientsMenu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.PortsMenu.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView portView;
        private System.Windows.Forms.ColumnHeader port_ch;
        private System.Windows.Forms.ColumnHeader status_ch;
        private System.Windows.Forms.ContextMenuStrip PortsMenu;
        private System.Windows.Forms.ToolStripMenuItem listenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        public System.Windows.Forms.ListView clientView;
        public System.Windows.Forms.ColumnHeader uid_ch;
        public System.Windows.Forms.ColumnHeader ip_port_ch;
        public System.Windows.Forms.ColumnHeader user_ch;
        private System.Windows.Forms.ContextMenuStrip ClientsMenu;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox autoListenCb;
        private System.Windows.Forms.ColumnHeader time_ch;
        private System.Windows.Forms.ColumnHeader log_ch;
        public System.Windows.Forms.ListView logView;
        private System.Windows.Forms.ToolStripMenuItem shellToolStripMenuItem;
        public System.Windows.Forms.ColumnHeader os_ch;
        public System.Windows.Forms.ColumnHeader country_ch;
        private System.Windows.Forms.ToolStripMenuItem filemanagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem builderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}