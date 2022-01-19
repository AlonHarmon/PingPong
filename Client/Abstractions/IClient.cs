using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Client
{
    public interface IClient
    {
         Task<string> Receive();
         Task Receive(string Message);
    }
}