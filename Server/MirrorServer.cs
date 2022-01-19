using System.Threading.Tasks;
using System;
using System.Net;  
using System.Net.Sockets;  

namespace Server
{
    public class MirrorServer
    {
        public int BufferSize { get; set; }
        private byte[] _buffer;
        public MirrorServer(int bufferSize)
        {
            BufferSize = bufferSize;
            _buffer = new byte[bufferSize];
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
                int bytesReceived = handler.Receive(_buffer);

                handler.Send(_buffer);
                Array.Clear(_buffer, 0, _buffer.Length);
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