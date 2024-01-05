using PacketLib;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Server.Handlers
{
    internal class HandleClient
    {
        public HandleClient(_Client _Client, MsgUnpack msgUnpack)
        {
            string uid = msgUnpack.GetAsString("UID");
            string ip = msgUnpack.GetAsString("IP");
            string port = _Client.tcpClient.Client.RemoteEndPoint.ToString().Split(':')[1];
            string username = msgUnpack.GetAsString("Username");
            string os = msgUnpack.GetAsString("Os");
            string country = msgUnpack.GetAsString("Country");

            Program.mainForm.Invoke(new MethodInvoker(() =>
            {
                if (!isClient(uid))
                {
                    _Client.uid = uid;
                    _Client.ListViewItem  = new ListViewItem();
                    _Client.ListViewItem.Text = ip + ":" + port;
                    _Client.ListViewItem.SubItems.Add(country);
                    _Client.ListViewItem.SubItems.Add(username);
                    _Client.ListViewItem.SubItems.Add(uid);
                    _Client.ListViewItem.SubItems.Add(os);
                    _Client.ListViewItem.Tag = _Client;
                    Program.mainForm.clientView.Items.Add(_Client.ListViewItem);
                    Program.mainForm.clientView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    if(Program.mainForm.country_ch.Width < 60)
                        Program.mainForm.country_ch.Width = 60;
                }
            }));
        }
        public bool isClient(string _uid)
        {
            foreach(ListViewItem listViewItem in Program.mainForm.clientView.Items)
            {
                string uid = listViewItem.SubItems[Program.mainForm.uid_ch.Index].Text;
                if(_uid == uid)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
