using System;
using Client.Abstractions;

namespace Client
{
    public class ConsoleInput : IObjectInput<string>
    {
        public string Receive()
        {
            return Console.ReadLine();
        }
    }
}