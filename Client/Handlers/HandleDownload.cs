using Client.Network;
using Client.Utils;
using PacketLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Handlers
{
    internal class HandleDownload
    {
        public static int OneMb = 1000000;
        public HandleDownload(MsgUnpack msgUnpack)
        {
            string file = msgUnpack.GetAsString("File");
            string duid = msgUnpack.GetAsString("DUID");
            if (File.Exists(file))
            {
                long fileSize = new FileInfo(file).Length;
                if (fileSize > 0)
                {
                    int count = 1;
                    if (fileSize < OneMb)
                    {
                        MsgPack msgPack = new MsgPack();
                        msgPack.Set("Packet", "Download");
                        msgPack.Set("UID", UID.Get());
                        msgPack.Set("DUID", duid);
                        msgPack.Set("FileName", Path.GetFileName(file));
                        msgPack.Set("FileBytes", File.ReadAllBytes(file));
                        msgPack.Set("FileSize", fileSize);
                        msgPack.Set("TempName", Helpers.MD5_STRING(Encoding.UTF8.GetBytes(Path.GetFileName(file) + duid + count)));
                        msgPack.Set("TempCount", 1);
                        _Client.Send(msgPack.Pack());
                    }
                    else
                    {
                        int bytesRead = 0;
                        long totalSize = fileSize;
                        byte[] buffer = new byte[OneMb];
                        using (Stream source = File.OpenRead(file))
                        {
                            while (((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0) && _Client.isConnected())
                            {
                                MsgPack msgPack = new MsgPack();
                                msgPack.Set("Packet", "Download");
                                msgPack.Set("UID", UID.Get());
                                msgPack.Set("DUID", duid);
                                msgPack.Set("FileName", Path.GetFileName(file));
                                msgPack.Set("FileBytes", buffer);
                                msgPack.Set("FileSize", fileSize);
                                msgPack.Set("TempName", Helpers.MD5_STRING(Encoding.UTF8.GetBytes(Path.GetFileName(file) + duid + (count++).ToString())));
                                msgPack.Set("TempCount", Convert.ToInt32((fileSize / OneMb) + 2));
                                _Client.Send(msgPack.Pack());
                                totalSize -= bytesRead;
                                if (totalSize < OneMb)
                                    buffer = new byte[totalSize];
                            }
                        }
                    }
                }
            }
        }
    }
}
