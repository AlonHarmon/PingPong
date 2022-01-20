using System.Net;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse(args[0]); 
            int port = int.Parse(args[1]);

            var serverBuilder = new EchoServerBuilder();
            var server = serverBuilder.Build();

            server.Start(port, ipAddress);
        }
    }
}
