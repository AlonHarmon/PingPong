using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Client.Abstractions
{
    public interface IClient
    {
         string Receive();
         void Send(string message);
         void Connect();
    }
}