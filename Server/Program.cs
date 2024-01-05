using Server.Forms;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    internal class Program
    {
        public static string ClientsFolder = Path.Combine(Environment.CurrentDirectory, "Clients Folder");
        public static string TempFolder = Path.Combine(Environment.CurrentDirectory, "Temp");
        public static MainForm mainForm { get; set; }
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
   }
}
