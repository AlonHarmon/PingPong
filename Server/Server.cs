using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;  
using System.Threading;

namespace Server
{
    internal class Server
    {
        public int BufferSize { get; set; }
        private byte[] _Buffer;
        public Server(int bufferSize)
        {
            BufferSize = bufferSize;
        }
        public void Start(int port, IPAddress ipAddress)
        {
            var endPoint = new IPEndPoint(ipAddress, port);
            StartListen(endPoint, ipAddress);
        }

        private async Task ClientHandler(Socket handler)
        {
            //TODO : send back to client clients msg
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