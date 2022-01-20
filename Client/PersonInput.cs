using Client.Abstractions;
using System;

namespace Client
{
    public class PersonInput : IObjectInput<Person>
    {
        private IObjectInput<string> _input;
        private IOutput _output;
        public PersonInput(IObjectInput<string> input, IOutput output)
        {
            _input = input;
            _output = output;
        }
        public Person Receive()
        {
            _output.Out("Enter person name:");
            string name = _input.Receive();
            _output.Out("Enter person age:");
            string age = _input.Receive();
            return new Person(name, int.Parse(age));
        }
    }
}