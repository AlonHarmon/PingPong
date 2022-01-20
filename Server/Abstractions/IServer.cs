using System.Security.AccessControl;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Server.Abstractions
{
    public interface IServer
    {
         string Receive(Guid connection);
         void Send(Guid connection, string message);

         void Start(int port, IPAddress ipAddress, Func<Guid, Task> clientHandler);
    }
}