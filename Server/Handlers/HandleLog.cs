using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Handlers
{
    internal class HandleLog
    {
        static object Log = new object();
        public static void Add(string message, Color color) 
        {
            lock (Log)
            {
                ListViewItem item = new ListViewItem();
                item.Text = DateTime.Now.ToString("hh:mm:ss");
                item.SubItems.Add(message);
                item.ForeColor = color;
                Program.mainForm.logView.Items.Add(item);
            }
        }
    }
}
