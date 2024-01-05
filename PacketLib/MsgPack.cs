using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PacketLib;

namespace PacketLib
{
    public class MsgPack
    {
        private Dictionary<string, object> Objects { get; set; }
        public MsgPack()
        {
            Objects = new Dictionary<string, object>();
        }
        public void Set(string key, object value)
        {
            if (Objects.ContainsKey(key))
            {
                Objects[key] = value;
            }
            else
            {
                Objects.Add(key, value);
            }
        }

        public byte[] Pack()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, new PacketData() { Objects = Objects });
                return Zip.Compress(memoryStream.ToArray());
            }
        }
    }
}
