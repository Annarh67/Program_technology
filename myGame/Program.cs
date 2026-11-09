

using System;

namespace myGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator generator = new NumberGenerator();

            int number = generator.Generate(1, 100);
            int guess = 0;

            Console.WriteLine("Угадайте число от 1 до 100");

            while (guess != number)
            {
                Console.Write("Введите число: ");

                if (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Введите целое число!");
                    continue;
                }

                if (guess < number)
                {
                    Console.WriteLine("Больше");
                }
                else if (guess > number)
                {
                    Console.WriteLine("Меньше");
                }
                else
                {
                    Console.WriteLine("Вы угадали!");
                }
            }
        }
    }
}
