using System.Security.AccessControl;
using System;
using System.Net;

namespace Server.Abstractions
{
    public interface IServer
    {
         string Receive();
         void Send();

         void Start(int port, IPAddress ipAddress, Action<IServer> clientHandler);
    }
}