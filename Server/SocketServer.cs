using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;  
using System.Net.Sockets;
using Server.Abstractions;
using System.Collections.Concurrent;

namespace Server
{
    public class SocketServer : IServer
    {
        public int BufferSize { get; set; }
        private ConcurrentDictionary<Guid, Socket> _sockets;
        public SocketServer(int bufferSize)
        {
            BufferSize = bufferSize;
            _sockets = new ConcurrentDictionary<Guid, Socket>();
        }
        public void Start(int port, IPAddress ipAddress, Func<Guid, Task> clientHandler)
        {
            var endPoint = new IPEndPoint(ipAddress, port);
            var listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(endPoint);
            listener.Listen(10);

            while (true)
            {
                Socket handler = listener.Accept();
                Guid clientGuid = Guid.NewGuid();
                _sockets[clientGuid] = handler;
                clientHandler?.Invoke(clientGuid);
            }
        }

        public string Receive(Guid connection)
        {
            var buffer = new byte[BufferSize];
            int bytesReceived = _sockets[connection].Receive(buffer);
            return Encoding.ASCII.GetString(buffer, 0, bytesReceived);
        }

        public void Send(Guid connection, string message)
        {
            _sockets[connection].Send(Encoding.UTF8.GetBytes(message));
        }
    }
}