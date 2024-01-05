using PacketLib;
using Server.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Forms.UtilsForm
{
    public partial class DownUp_loadForm : Form
    {
        public _Client _Client { get; set; }
        public string FileName { get; set; }
        public string UID { get; set; }
        public long FileSize { get; set; }
        public object OneByOne { get;set; }
        public long TotalFileSize { get; set; }
        public DownUp_loadForm()
        {
            InitializeComponent();
            OneByOne = new object();
        }
        private void ConnectionCheckup_Tick(object sender, EventArgs e)
        {
            if (_Client == null || !_Client.isConnected())
            {
                this.Close();
            }
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            UidLbl.Text = "Uid -> " + UID;
            fileNameLbl.Text = "File name -> " + FileName;
            fileSizeLbl.Text = "File size -> " + Helpers.BytesToString(FileSize);
            if (TotalFileSize > 0)
            {
                float progress = (((100 * TotalFileSize) + 0.5f) / FileSize);
                progressBar1.Value = Convert.ToInt32(progress);
                statusLbl.Text = "Status -> " + Helpers.BytesToString(TotalFileSize) + "/" + Helpers.BytesToString(FileSize) + $" ({progress}%)";
            }
        }


        public void Status(string status)
        {
            this.Invoke(new MethodInvoker(() => statusLbl.Text = "Status -> " + status));
        }
    }
}
