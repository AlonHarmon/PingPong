using System;
using Client.Abstractions;

namespace Client
{
    public class ConsoleInput : IInput
    {
        public string Receive()
        {
            return Console.ReadLine();
        }
    }
}