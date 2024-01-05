using PacketLib;
using Server.Forms.UtilsForm;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Handlers
{
    internal class HandleUpload
    {
        public void Run(_Client _Client, MsgUnpack msgUnpack)
        {
            string duid = msgUnpack.GetAsString("DUID");
            DownUp_loadForm uploadForm = (DownUp_loadForm)Application.OpenForms["Upload:" + duid];
            if (uploadForm != null)
            {
                if (uploadForm._Client == null)
                {
                    uploadForm._Client = _Client;
                    uploadForm.ConnectionCheckup.Start();
                }
                uploadForm.Update.Stop();
                bool isOk = msgUnpack.GetAsBoolen("isOk");
                if(isOk)
                {
                    uploadForm.Status(msgUnpack.GetAsString("Message"));
                }
                else
                {
                    uploadForm.Status("Failed !");
                }
            }
        }
    }
}
