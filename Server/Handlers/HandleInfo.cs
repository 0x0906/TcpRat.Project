using PacketLib;
using Server.Forms;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Handlers
{
    internal class HandleInfo
    {
        public HandleInfo(_Client _Client, MsgUnpack msgUnpack) 
        {
            InfoForm infoForm = (InfoForm)Application.OpenForms["Info:" + msgUnpack.GetAsString("UID")];
            if (infoForm != null)
            {
                if (infoForm._Client == null)
                {
                    infoForm._Client = _Client;
                    infoForm.ConnectionCheckup.Start();
                }
                infoForm.Invoke(new MethodInvoker(() =>
                {
                    infoForm.infoView.Items.Clear();
                    Dictionary<string, object> dict = msgUnpack.GetAll();
                    infoForm.infoView.BeginUpdate();
                    foreach (var dictItem in dict)
                    {
                        if (dictItem.Key == "UID") continue;
                        if (dictItem.Key == "Packet") continue;

                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.Text = dictItem.Key;
                        listViewItem.SubItems.Add(dictItem.Value.ToString());
                        infoForm.infoView.Items.Add(listViewItem);
                    }
                    infoForm.infoView.EndUpdate();
                }));
            }
        }

    }
}
