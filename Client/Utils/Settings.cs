using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Utils
{
    internal class Settings
    {
        public static string MutexString = "[MUTEX]";
        public static string Host = "[HOST]";
        public static int Port = Convert.ToInt32("[PORT]");
        public static bool AppStartup = Convert.ToBoolean("[APPSTARTUP]");
    }
}
