using PacketLib;
using Server.Forms.UtilsForm;
using Server.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Handlers
{
    public class HandleDownload
    {
        public async void Run(_Client _Client, MsgUnpack msgUnpack)
        {
            string duid = msgUnpack.GetAsString("DUID");
            DownUp_loadForm downloadForm = (DownUp_loadForm)Application.OpenForms["Download:" + duid];
            if (downloadForm != null)
            {
                try
                {
                    if (downloadForm._Client == null)
                    {
                        downloadForm._Client = _Client;
                        downloadForm.ConnectionCheckup.Start();
                    }

                    await Task.Run(async () =>
                    {
                        string uid = msgUnpack.GetAsString("UID");
                        string fileName = msgUnpack.GetAsString("FileName");
                        long fileSize = msgUnpack.GetAsLong("FileSize");
                        byte[] fileBytes = msgUnpack.GetAsByteArray("FileBytes");
                        downloadForm.UID = uid;
                        downloadForm.FileName = fileName;
                        downloadForm.FileSize = fileSize;
                        string TempName = msgUnpack.GetAsString("TempName");
                        if (!string.IsNullOrEmpty(TempName))
                        {
                            await SaveTempFile(uid, TempName, fileBytes);
                            lock (downloadForm.OneByOne)
                            {
                                downloadForm.TotalFileSize += fileBytes.Length;
                            }
                            if (downloadForm.TotalFileSize == fileSize)
                            {
                                Thread.Sleep(1500);
                                downloadForm.progressBar1.Value = 100;
                                downloadForm.Update.Stop();
                                downloadForm.Status("Merging...");
                                Thread.Sleep(1500);
                                long TempCount = msgUnpack.GetAsInteger("TempCount");
                                await SaveFile(uid, duid, fileName, TempCount, downloadForm);
                                Thread.Sleep(1500);
                                downloadForm.Status("Downloaded !");
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    downloadForm.Update.Stop();
                    downloadForm.Status("Failed !");
                    string errorMsg = ex.Message;
                    errorMsg += "\nUID: " + msgUnpack.GetAsString("UID");
                    MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public async Task SaveTempFile(string uid, string fileName, byte[] fileBytes)
        {
            string tempFolder = Path.Combine(Program.TempFolder, uid);
            if (!Directory.Exists(tempFolder)) Directory.CreateDirectory(tempFolder);
            string filePath = Path.Combine(tempFolder, fileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                await fileStream.WriteAsync(fileBytes, 0, fileBytes.Length);
            }
        }
        public async Task SaveFile(string uid, string duid, string fileName, long TempCount, DownUp_loadForm downloadForm)
        {
            string clientFolder = Path.Combine(Program.ClientsFolder, uid);
            if (!Directory.Exists(clientFolder)) Directory.CreateDirectory(clientFolder);
            string filePath = Path.Combine(clientFolder, fileName);

            if (TempCount > 0)
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    string tempFolder = Path.Combine(Program.TempFolder, uid);
                    int offset = 0;
                    for (int i = 1; i <= TempCount; i++)
                    {
                        string TempName = Helpers.MD5_STRING(Encoding.UTF8.GetBytes(fileName + duid + i.ToString()));
                        string TempFilePath = Path.Combine(tempFolder, TempName);
                        if (!File.Exists(TempFilePath)) continue;
                        byte[] TempFileBytes = File.ReadAllBytes(TempFilePath);
                        await fileStream.WriteAsync(TempFileBytes, offset, TempFileBytes.Length);
                        File.Delete(TempFilePath);
                        downloadForm.Status($"Merging ({i}/{TempCount})");
                    }
                }
            }
        }
    }
}
