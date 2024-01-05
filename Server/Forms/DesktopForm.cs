using PacketLib;
using Server.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Forms
{
    public partial class DesktopForm : Form
    {
        public _Client _Client { get; set; }
        public int FPS { get; set; }
        public object OneByOne { get; set; }
        public Point imageSize { get; set; }
        private List<Keys> _keysPressed { get; set; }
        public DesktopForm()
        {
            InitializeComponent();
            OneByOne = new object();
            _keysPressed = new List<Keys>();
        }

        private void DesktopForm_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(_MouseWheel);
            qualityComboBx.Items.AddRange(Enumerable.Range(1, 100).ToArray().Select(x => (object)x + "%").ToArray());
            qualityComboBx.SelectedIndex = 29;
        }


        private void ConnectionCheckup_Tick(object sender, EventArgs e)
        {
            if (_Client == null || !_Client.isConnected())
            {
                this.Close();
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            StopCapture();
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
            FPSCounter.Enabled = false;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            StartCapture(screensCombo.SelectedIndex);
            startBtn.Enabled = false;
            stopBtn.Enabled = true;
            FPSCounter.Enabled = true;
        }

        private void DesktopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCapture();
        }

        public void StartCapture(int screen)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "Desktop");
            msgPack.Set("Command", "Start");
            msgPack.Set("Quality", Convert.ToInt32(qualityComboBx.SelectedItem.ToString().Replace("%", string.Empty)));
            msgPack.Set("Screen", screen);
            _Client.Send(msgPack.Pack());
        }

        public void StopCapture()
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "Desktop");
            msgPack.Set("Command", "Stop");
            _Client.Send(msgPack.Pack());
        }

        private void FPSCounter_Tick(object sender, EventArgs e)
        {
            fpsLbl.Text = "FPS: " + FPS;
            FPS = 0;
        }

        private void desktopPicBox_MouseClick(object sender, MouseEventArgs e)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.Set("Packet", "Desktop");
            msgPack.Set("Command", "Stop");
            _Client.Send(msgPack.Pack());
        }

        private void desktopPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            int button = 0;
            if (e.Button == MouseButtons.Left)
                button = 2;
            if (e.Button == MouseButtons.Right)
                button = 8;

            _MouseClick(button);
        }


        private void desktopPicBox_MouseUp(object sender, MouseEventArgs e)
        {
            int button = 0;
            if (e.Button == MouseButtons.Left)
                button = 4;
            if (e.Button == MouseButtons.Right)
                button = 16;

            _MouseClick(button);
        }
        private void desktopPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseCkBx.Checked && !startBtn.Enabled)
            {
                Point p = new Point(e.X * imageSize.X / desktopPicBox.Width, e.Y * imageSize.Y / desktopPicBox.Height);
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "Desktop");
                msgPack.Set("Command", "MouseMove");
                msgPack.Set("X", p.X);
                msgPack.Set("Y", p.Y);
                _Client.Send(msgPack.Pack());
            }
        }

        private void _MouseClick(int button)
        {
            if (mouseCkBx.Checked && !startBtn.Enabled)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "Desktop");
                msgPack.Set("Command", "MouseClick");
                msgPack.Set("Button", button);
                _Client.Send(msgPack.Pack());
            }
        }
        private void _MouseWheel(object sender, MouseEventArgs e)
        {
            if (mouseCkBx.Checked && !startBtn.Enabled)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "Desktop");
                msgPack.Set("Command", "MouseWheel");
                msgPack.Set("Delta", e.Delta);
                _Client.Send(msgPack.Pack());
            }
        }

        private bool IsLockKey(Keys key)
        {
            return ((key & Keys.CapsLock) == Keys.CapsLock)
                   || ((key & Keys.NumLock) == Keys.NumLock)
                   || ((key & Keys.Scroll) == Keys.Scroll);
        }

        private void DesktopForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyboardCkBx.Checked && !startBtn.Enabled)
            {

                if (!IsLockKey(e.KeyCode))
                    e.Handled = true;

                if (_keysPressed.Contains(e.KeyCode))
                    return;

                _keysPressed.Add(e.KeyCode);

                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "Desktop");
                msgPack.Set("Command", "KeyboardClick");
                msgPack.Set("isKeyDown", true);
                msgPack.Set("Key", Convert.ToInt32(e.KeyCode));
                _Client.Send(msgPack.Pack());
            }
        }

        private void DesktopForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyboardCkBx.Checked && !startBtn.Enabled)
            {
                if (!IsLockKey(e.KeyCode))
                    e.Handled = true;

                _keysPressed.Remove(e.KeyCode);

                MsgPack msgPack = new MsgPack();
                msgPack.Set("Packet", "Desktop");
                msgPack.Set("Command", "KeyboardClick");
                msgPack.Set("isKeyDown", false);
                msgPack.Set("Key", Convert.ToInt32(e.KeyCode));
                _Client.Send(msgPack.Pack());
            }
        }
    }
}
