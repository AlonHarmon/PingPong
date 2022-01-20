using System;
using Client.Abstractions;

namespace Client
{
    public class ConsoleOutput : IOutput
    {
        public void Out(string message)
        {
            Console.WriteLine(message);
        }
    }
}