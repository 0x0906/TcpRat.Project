using Client.Handlers;
using PacketLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client.Utils
{
    internal class UID
    {
        public static string Value { get; set; }
        public static string Get()
        {
            if (Value == null)
            {
                byte[] unique = Encoding.UTF8.GetBytes(HandleInfo.GetCpuName() +
                    HandleInfo.GetGpuName() +
                    HandleInfo.GetBiosManufacturer() +
                    HandleInfo.GetMainboardName());

                Value = Helpers.MD5_STRING(unique).ToUpper();
            }
            return Value;
        }
        
    }
}
