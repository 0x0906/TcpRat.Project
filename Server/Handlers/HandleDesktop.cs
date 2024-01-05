using PacketLib;
using Server.Forms;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Handlers
{
    internal class HandleDesktop
    {
        public void Run(_Client _Client, MsgUnpack msgUnpack)
        {
            DesktopForm desktopForm = (DesktopForm)Application.OpenForms["Desktop:" + msgUnpack.GetAsString("UID")];
            if (desktopForm != null)
            {
                try
                {
                    if (desktopForm._Client == null)
                    {
                        desktopForm._Client = _Client;
                        desktopForm.ConnectionCheckup.Start();
                    }
                    desktopForm.Invoke(new MethodInvoker(() =>
                    {
                        lock (desktopForm.OneByOne)
                        {
                            int Screens = msgUnpack.GetAsInteger("Screens");
                            if (desktopForm.screensCombo.Items.Count != Screens)
                            {
                                desktopForm.screensCombo.Items.Clear();
                                for (int i = 0; i < Screens; i++)
                                {
                                    string screen = "Screen " + i;
                                    desktopForm.screensCombo.Items.Add(screen);
                                }
                                if (desktopForm.screensCombo.SelectedIndex == -1)
                                {
                                    desktopForm.screensCombo.SelectedIndex = 0;
                                }
                            }
                            byte[] desktopImg = msgUnpack.GetAsByteArray("ImageBytes");
                            if (desktopImg == null || !(desktopImg.Length > 0)) return;
                            Image image = Image.FromStream(new MemoryStream(desktopImg));
                            desktopForm.imageSize = new Point(image.Width, image.Height);
                            desktopForm.FPS += 1;
                            desktopForm.desktopPicBox.Image = image;
                        }
                    }));
                }
                catch (System.ObjectDisposedException) { return; }
            }
        }
    }
}
