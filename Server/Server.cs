using System.Threading.Tasks;
using System;  
using System.Net;  
using System.Net.Sockets;  

namespace Server
{
    internal class Server
    {
        public int BufferSize { get; set; }
        private byte[] _Buffer;
        public Server(int bufferSize)
        {
            BufferSize = bufferSize;
            _Buffer = new byte[bufferSize];
        }
        public void Start(int port, IPAddress ipAddress)
        {
            var endPoint = new IPEndPoint(ipAddress, port);
            StartListen(endPoint, ipAddress);
        }

        private async Task ClientHandler(Socket handler)
        {
            while(true)
            {
                await Task.Delay(1000);
                int bytesReceived = handler.Receive(_Buffer);
                handler.Send(_Buffer);
                Array.Clear(_Buffer, 0, _Buffer.Length);
            }
            

        }
        private void StartListen(IPEndPoint endPoint, IPAddress ipAddress)
        {
            var listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(endPoint);
            listener.Listen(10);

            while (true)
            {
                Socket handler = listener.Accept();
                ClientHandler(handler);
            }
            
        }
    }
}