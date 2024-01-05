using PacketLib;
using Server.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Forms
{
    public partial class InfoForm : Form
    {
        public _Client _Client {  get; set; }   
        public InfoForm()
        {
            InitializeComponent();
        }

        private void ConnectionCheckup_Tick(object sender, EventArgs e)
        {
            if(_Client == null || !_Client.isConnected())
            {
                this.Close();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "Info");
            _Client.Send(msgPack.Pack());
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(ListViewItem item in infoView.SelectedItems)
            {
                stringBuilder.AppendLine(item.Text + " = " + item.SubItems[1].Text);
            }
            string copyData = stringBuilder.ToString();
            if (!string.IsNullOrEmpty(copyData))
            {
                Thread thread = new Thread(() => Clipboard.SetText(copyData));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }
        }
    }
}
