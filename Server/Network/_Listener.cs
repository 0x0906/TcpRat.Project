using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Network
{
    internal class _Listener
    {
        TcpListener listener { get; set; }
        CancellationTokenSource cancellationTokenSource { get; set; }
        List<_Client> _Clients { get; set; }
        public _Listener(int port)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
            listener = new TcpListener(endPoint);
        }

        public void Start()
        {
            _Clients = new List<_Client>();
            listener.Start();
            cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => { TcpClientCallback(); }, cancellationTokenSource.Token);
        }

        public List<_Client> getClients()
        {
            return _Clients;
        }

        public void Stop()
        {
            try
            {
                cancellationTokenSource?.Cancel();
                foreach (_Client client in _Clients)
                {
                    client?.Disconnect();
                }
                _Clients.Clear();
                listener?.Stop();
            }
            catch { }
        }

        private void TcpClientCallback()
        {
            while (true)
            {
                try
                {
                    TcpClient tcpClient = listener.AcceptTcpClient();
                    _Clients.Add(new _Client(tcpClient));
                }
                catch { continue; }
            }
        }

/*        void Error([CallerMemberName] string name = null, Exception ex = null)
        {
            Debug.WriteLine("[Error] " + name + ": " + ex.Message);
            return;
        }*/

    }
}
