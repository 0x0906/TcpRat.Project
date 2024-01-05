using Client.Network;
using PacketLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Utils
{
    internal class Logger
    {
        public static void ErrorLog(string message)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "ErrorLog");
            msgPack.Set("UID", UID.Get());
            msgPack.Set("Message", message);
            _Client.Send(msgPack.Pack());
        }
        public static void InfoLog(string message)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "InfoLog");
            msgPack.Set("UID", UID.Get());
            msgPack.Set("Message", message);
            _Client.Send(msgPack.Pack());
        }
    }
}
