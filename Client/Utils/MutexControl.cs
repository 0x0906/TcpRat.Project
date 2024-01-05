using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Utils
{
    internal class MutexControl
    {
        public static Mutex currentApp;
        public static bool CreateMutex()
        {
            currentApp = new Mutex(false, Settings.MutexString, out bool createdNew);
            return createdNew;
        }
        public static void CloseMutex()
        {
            if (currentApp != null)
            {
                currentApp.Close();
                currentApp = null;
            }
        }
    }
}
