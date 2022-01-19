using System.Net;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse(args[0]); 
            int port = int.Parse(args[1]);
            var server = new MirrorServer(1024);
            server.Start(6060, ipAddress);
        }
    }
}
