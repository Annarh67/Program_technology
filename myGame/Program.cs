
using System;

namespace myGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator generator = new NumberGenerator();

            int number = generator.Generate(1, 100);

            Console.WriteLine(number);
        }
    }
}
