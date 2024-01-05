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

namespace Server.Forms.UtilsForm
{
    public partial class Editor_Form : Form
    {
        public _Client _Client { get; set; }
        public Editor_Form()
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "FileManager");
            msgPack.Set("Command", "Edit");
            msgPack.Set("Do", "Set");
            msgPack.Set("File", editorTxtbox.Tag as string);
            msgPack.Set("FileContent", editorTxtbox.Text);
            _Client.Send(msgPack.Pack());
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "FileManager");
            msgPack.Set("Command", "Edit");
            msgPack.Set("Do", "Get");
            msgPack.Set("File", editorTxtbox.Tag as string);
            msgPack.Set("EUID", (this.Name ?? this.Text).Replace("Editor:", string.Empty));
            _Client.Send(msgPack.Pack());
        }
    }
}
