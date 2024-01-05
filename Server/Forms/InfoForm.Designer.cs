namespace Server.Forms
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.infoView = new System.Windows.Forms.ListView();
            this.component_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectionCheckup = new System.Windows.Forms.Timer(this.components);
            this.infoMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoView
            // 
            this.infoView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.component_ch,
            this.value_ch});
            this.infoView.ContextMenuStrip = this.infoMenu;
            this.infoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoView.FullRowSelect = true;
            this.infoView.GridLines = true;
            this.infoView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.infoView.HideSelection = false;
            this.infoView.Location = new System.Drawing.Point(0, 0);
            this.infoView.Name = "infoView";
            this.infoView.Size = new System.Drawing.Size(536, 395);
            this.infoView.TabIndex = 0;
            this.infoView.UseCompatibleStateImageBehavior = false;
            this.infoView.View = System.Windows.Forms.View.Details;
            // 
            // component_ch
            // 
            this.component_ch.Text = "Component";
            this.component_ch.Width = 257;
            // 
            // value_ch
            // 
            this.value_ch.Text = "Value";
            this.value_ch.Width = 269;
            // 
            // infoMenu
            // 
            this.infoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.infoMenu.Name = "infoMenu";
            this.infoMenu.Size = new System.Drawing.Size(114, 48);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // ConnectionCheckup
            // 
            this.ConnectionCheckup.Enabled = true;
            this.ConnectionCheckup.Interval = 500;
            this.ConnectionCheckup.Tick += new System.EventHandler(this.ConnectionCheckup_Tick);
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 395);
            this.Controls.Add(this.infoView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfoForm";
            this.infoMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader component_ch;
        private System.Windows.Forms.ColumnHeader value_ch;
        public System.Windows.Forms.Timer ConnectionCheckup;
        public System.Windows.Forms.ListView infoView;
        private System.Windows.Forms.ContextMenuStrip infoMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}