using Client.Network;
using Client.Utils;
using PacketLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Handlers
{
    internal class HandleUpload
    {
        public void Run(MsgUnpack msgUnpack)
        {
            try
            {
                if (msgUnpack.GetAsBoolen("isCompleted"))
                {
                    string duid = msgUnpack.GetAsString("DUID");
                    string fileName = msgUnpack.GetAsString("FileName");
                    string filePath = msgUnpack.GetAsString("FilePath");
                    long fileSize = msgUnpack.GetAsLong("FileSize");
                    long TempCount = msgUnpack.GetAsInteger("TempCount");
                    SaveFile(duid, fileName, filePath, TempCount, fileSize);
                }
                else
                {
                    string TempName = msgUnpack.GetAsString("TempName");
                    byte[] fileBytes = msgUnpack.GetAsByteArray("FileBytes");
                    if (!string.IsNullOrEmpty(TempName))
                    {
                        SaveTempFile(TempName, fileBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ex.Message);
            }
        }
        public void SaveTempFile(string fileName, byte[] fileBytes)
        {
            string filePath = Path.Combine(Path.GetTempPath(), fileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fileStream.Write(fileBytes, 0, fileBytes.Length);
            }
        }
        public void SaveFile(string duid, string fileName, string filePath, long TempCount, long fileLength)
        {
            if (TempCount > 0)
            {
                Thread.Sleep(3000);
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "Upload");
                msgPack.Set("DUID", duid);
                msgPack.Set("isOk", true);
                msgPack.Set("Message", "Merging...");
                _Client.Send(msgPack.Pack());
                using (FileStream fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    for (int i = 1; i <= TempCount; i++)
                    {
                        string TempName = Helpers.MD5_STRING(Encoding.UTF8.GetBytes(fileName + duid + i.ToString()));
                        string TempFilePath = Path.Combine(Path.GetTempPath(), TempName);
                        if (!File.Exists(TempFilePath)) continue;
                        byte[] TempFileBytes = File.ReadAllBytes(TempFilePath);
                        fileStream.Write(TempFileBytes, 0, TempFileBytes.Length);
                        File.Delete(TempFilePath);
                    }
                }
                long RfileLength = new FileInfo(Path.Combine(filePath, fileName)).Length;
                if(RfileLength == fileLength)
                {
                    Console.WriteLine("File Recieved !");
                    msgPack = new MsgPack();
                    msgPack.Set("Packet", "Upload");
                    msgPack.Set("DUID", duid);
                    msgPack.Set("isOk", true);
                    msgPack.Set("Message", "Uploaded !");
                    _Client.Send(msgPack.Pack());
                }
                else
                {
                    Console.WriteLine("Failed !");
                    msgPack = new MsgPack();
                    msgPack.Set("Packet", "Upload");
                    msgPack.Set("DUID", duid);
                    msgPack.Set("isOk", false);
                    _Client.Send(msgPack.Pack());
                    Logger.ErrorLog("File length not matched.");
                }
            }
        }

    }
}
