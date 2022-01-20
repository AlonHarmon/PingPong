using System.Threading.Tasks;

namespace Client.Abstractions
{
    public interface ISender
    {
         Task Start();
    }
}