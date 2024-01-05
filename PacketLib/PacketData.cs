using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketLib
{
    [Serializable]
    class PacketData
    {
        public Dictionary<string, object> Objects { get; set; }
    }
}
