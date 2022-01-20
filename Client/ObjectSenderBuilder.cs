using System.Net;

namespace Client
{
    public class ObjectSenderBuilder
    {
        public ObjectSenderClient<Person> Build(IPAddress ipAddress, int port)
        {
            var client = new SocketClient(1027, ipAddress, port);
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            return new ObjectSenderClient<Person>(client, new PersonInput(input, output), output, new ObjectSerializer());
        }
    }
}