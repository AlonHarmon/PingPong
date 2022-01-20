using System.Net;
using System;
using Server.Abstractions;
using System.Threading.Tasks;

namespace Server
{
    public class EchoServer
    {
        private IServer _server;

        public EchoServer(IServer server)
        {
            _server = server;

        }

        public void Start(int port, IPAddress ipAddress)
        {
            _server.Start(port, ipAddress, ClientHandler);
        }

        private async Task ClientHandler(Guid connection)
        {
            while(true)
            {
                await Task.Delay(1000);
                string message = _server.Receive(connection);

                _server.Send(connection, message);
            }
        }

    }
}