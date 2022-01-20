using System.Net.Sockets;
using System.Net.NetworkInformation;
namespace Server
{
    public class EchoServerBuilder
    {
        public EchoServer Build()
        {
            
            var socketServer = new TcpListenerServer(1024);
            return new EchoServer(socketServer);
        }
    }
}