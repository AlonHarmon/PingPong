using System.Net;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = new IPAddress(Encoding.ASCII.GetBytes(args[1])); 
            int port = int.Parse(args[0]);
            var server = new MirrorServer(1024);
            server.Start(6060, ipAddress);
        }
    }
}
