using System.Security.AccessControl;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Abstractions;
using System.Net;  
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class SocketClient : IClient
    {
        public int BufferSize { get; set; }
        private byte[] _buffer;
        private int _port;
        private Socket _socket;

        public SocketClient(int bufferSize, IPAddress ipAddress, int port)
        {
            BufferSize = bufferSize;
            _buffer = new byte[bufferSize];
            _socket = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp );
            _socket.Connect(ipAddress, port);
        }
        public string Receive()
        {
            int byteReceived = _socket.Receive(_buffer);
            return Encoding.ASCII.GetString(_buffer,0,byteReceived);
        }

        public void Send(string message)
        {
            _socket.Send(Encoding.ASCII.GetBytes(message));
        }
    }
}