using System.Net.WebSockets;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ipAddress = IPAddress.Parse(args[0]); 
            int port = int.Parse(args[1]);
            var socketClient = new SocketClient(1024, ipAddress, port);
            EchoClient client = new EchoClient(socketClient, new ConsoleInput(), new ConsoleOutput());
            await client.Start();
        }
    }
}
