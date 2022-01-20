using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;  
using System.Net.Sockets;
using Server.Abstractions;
using System.Collections.Concurrent;

namespace Server
{
    public class SecketServer : IServer
    {
        public int BufferSize { get; set; }
        private byte[] _buffer;
        private ConcurrentDictionary<Guid, Socket> _sockets;
        public SecketServer(int bufferSize)
        {
            BufferSize = bufferSize;
            _buffer = new byte[bufferSize];
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

        private async Task ClientHandler(Socket handler)
        {
            while(true)
            {
                await Task.Delay(1000);
                int bytesReceived = handler.Receive(_buffer);

                handler.Send(_buffer);
                Array.Clear(_buffer, 0, _buffer.Length);
            }
        }

        public string Receive(Guid connection)
        {
            int bytesReceived = _sockets[connection].Receive(_buffer);
            return Encoding.ASCII.GetString(_buffer, 0, bytesReceived);
        }

        public void Send(Guid connection, string message)
        {
            _sockets[connection].Send(Encoding.UTF8.GetBytes(message));
        }
    }
}