using PacketLib;
using Server.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Server.Forms
{
    public partial class ProcessManagerForm : Form
    {
        public _Client _Client { get; set; }
        public ProcessManagerForm()
        {
            InitializeComponent();
        }

        private void ConnectionCheckup_Tick(object sender, EventArgs e)
        {
            if (_Client == null || !_Client.isConnected())
            {
                this.Close();
            }
        }

        private void suspendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Controls("Suspend");
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Controls("Resume");
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Controls("Kill");
        }

        private void _Controls(string option)
        {
            foreach (ListViewItem listViewItem in processView.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "ProcessManager");
                msgPack.Set("Command", option);
                msgPack.Set("ProcessId", Convert.ToInt32(listViewItem.Tag));
                _Client.Send(msgPack.Pack());
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "ProcessManager");
            msgPack.Set("Command", "List");
            _Client.Send(msgPack.Pack());
            ShowWait();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listViewItem in processView.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "ProcessManager");
                msgPack.Set("Command", "Info");
                msgPack.Set("ProcessId", Convert.ToInt32(listViewItem.Tag));
                _Client.Send(msgPack.Pack());
            }
        }

        public void ShowWait()
        {
            waitLbl.BringToFront();
            waitLbl.Visible = true;
            processView.Visible = false;
        }
         public void HideWait()
        {
            waitLbl.SendToBack();
            waitLbl.Visible = false;
            processView.Visible = true;
        }

        private void ProcessManagerForm_Load(object sender, EventArgs e)
        {
            ShowWait();
        }
    }
}
