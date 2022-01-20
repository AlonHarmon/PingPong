using System.Collections.Immutable;
using System.Net.NetworkInformation;
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
            var builder = new ObjectSenderBuilder();
            var sender = builder.Build(ipAddress, port);
            await sender.Start();
        }
    }
}
