using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Server.Abstractions;
using System.Collections.Concurrent;
using System.Text;

namespace Server
{
    public class TcpListenerServer : IServer
    {
        public int BufferSize { get; set; }
        private ConcurrentDictionary<Guid, NetworkStream> _clients;


        public TcpListenerServer(int bufferSize)
        {
            _clients = new ConcurrentDictionary<Guid, NetworkStream>();
            BufferSize = bufferSize;
        }
        public void Start(int port, IPAddress ipAddress, Func<Guid, Task> clientHandler)
        {
            var listener = new TcpListener(ipAddress, port);
            listener.Start();

            while(true)
            {
                TcpClient client = listener.AcceptTcpClient();
                var clientConnection = Guid.NewGuid();
                _clients[clientConnection] = client.GetStream();
                clientHandler?.Invoke(clientConnection);
            }
        }

        public string Receive(Guid connection)
        {
            var buffer = new byte[BufferSize];
            int bytesReceived = _clients[connection].Read(buffer);
            return System.Text.Encoding.ASCII.GetString(buffer, 0, bytesReceived);
        }

        public void Send(Guid connection, string message)
        {
            _clients[connection].Write(Encoding.UTF8.GetBytes(message), 0, message.Length);
        }
    }
}