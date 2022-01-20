using Client.Abstractions;
using System.Threading.Tasks;

namespace Client
{
    public class EchoClient
    {
        private IClient _client;
        private IInput _input;
        private IOutput _output;
        public EchoClient(IClient client, IInput input, IOutput output)
        {
            _client = client;
            _input = input;
            _output = output;
        }

        public async Task Start()
        {
            while(true)
            {
                await Task.Delay(1000);
                string message = _input.Receive();
                _client.Send(message);
                string receivedMessage = _client.Receive();
                _output.Out(receivedMessage);
            }
        }
    }
}