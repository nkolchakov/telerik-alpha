using System;
using Traveller.Core.Contracts;

namespace Traveller.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
