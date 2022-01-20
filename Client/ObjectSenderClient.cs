using System.Threading.Tasks;
using Client.Abstractions;

namespace Client
{
    public class ObjectSenderClient<T> : ISender
    {
        private IClient _client;
        private IObjectSerializer _serializer;
        private IObjectInput<T> _input;
        private IOutput _output;

        public ObjectSenderClient(IClient client, IObjectInput<T> input, IOutput output, IObjectSerializer serializer)
        {
            _client = client;
            _input = input;
            _serializer = serializer;
            _output = output;
        }
        public Task Start()
        {
            while (true)
            {
                T personToSend = _input.Receive();
                string person = _serializer.Serialize(typeof(Person), personToSend);
                _client.Send(person);

                // TODO: rcv, send = socket.split

                string receivedPerson = _client.Receive();
                T deserializedPerson = (T) _serializer.Deserialize(typeof(T),  receivedPerson);
                _output.Out(deserializedPerson.ToString());
            }
        }
    }
}