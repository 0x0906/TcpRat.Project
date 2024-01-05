using Server.Handlers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Network
{
    public class _Client
    {
        public static int OneMb = 1000000;
        public TcpClient tcpClient {  get; set; }
        private NetworkStream networkStream { get; set; }  
        private CancellationTokenSource cancellationToken { get; set; } 
        public string uid { get; set; }
        public ListViewItem ListViewItem { get; set; }
        private static object SendOneByOne { get; set; }
        public _Client(TcpClient _tcpClient) 
        {
            tcpClient = _tcpClient;
            SendOneByOne = new object();
            networkStream = tcpClient.GetStream();
            cancellationToken = new CancellationTokenSource();  
            HandleLog.Add("[Connected]  Client: " + tcpClient.Client.RemoteEndPoint.ToString(), Color.Green);
            Task.Run(() => { Recieve(); }, cancellationToken.Token);
        }
        private async void Recieve()
        {
            try
            {
                while (true)
                {
                    if (tcpClient == null) throw new Exception("no connection");
                    byte[] bytes = new byte[4];
                    int byteSize = await networkStream.ReadAsync(bytes, 0, bytes.Length);
                    byteSize = BitConverter.ToInt32(bytes, 0);
                    if (byteSize > 0)
                    {
                        bytes = new byte[byteSize];
                        int totalRecieved = 0;
                        while (totalRecieved < byteSize)
                        {
                            totalRecieved += await networkStream.ReadAsync(bytes, totalRecieved, bytes.Length - totalRecieved);
                        }
                        ThreadPool.QueueUserWorkItem(state =>
                        {
                            new HandlePacket
                            {
                                _Client = this,
                                packet = bytes
                            }.Run(state);
                        }, null);
                    }
                    else
                    {
                        Disconnect();
                    }
                }    
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Server: " + ex.ToString());
                Disconnect();
            }
        }

        public void Send(byte[] bytes)
        {
            lock (SendOneByOne)
            {
                try
                {

                    byte[] byteSize = BitConverter.GetBytes(bytes.Length);
                    networkStream.Write(byteSize, 0, byteSize.Length);

                    if (bytes.Length > OneMb)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(bytes))
                        {
                            int read = 0;
                            memoryStream.Position = 0;
                            byte[] chunk = new byte[OneMb];
                            while ((read = memoryStream.Read(chunk, 0, chunk.Length)) > 0)
                            {
                                networkStream.Write(chunk, 0, read);
                            }
                        }
                    }
                    else
                    {
                        networkStream.Write(bytes, 0, bytes.Length);
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Server: " + ex.ToString());
                    Disconnect();
                }
            }
        }

        public bool isConnected()
        {
            if (tcpClient == null) return false;
            return tcpClient.Connected;
        }

        public void Disconnect()
        {
            try
            {
                Program.mainForm.Invoke(new MethodInvoker(() =>
                {
                    HandleLog.Add("[Disconnected]  Client: " + tcpClient.Client.RemoteEndPoint.ToString(), Color.Red);
                    Program.mainForm.clientView.Items.Remove(ListViewItem);
                }));
                cancellationToken?.Cancel();
                tcpClient?.Close();
                tcpClient?.Dispose();
                networkStream = null;
                tcpClient = null;
                cancellationToken = null;
                GC.Collect();
            }
            catch {  }
        }
    }
}
