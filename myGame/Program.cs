
using System;

namespace myGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator generator = new NumberGenerator();
            Game game = new Game(generator);

            int result = 1;

            Console.WriteLine("Угадайте число от 1 до 100");

            while (result != 0)
            {
                Console.Write("Введите число: ");

                if (!int.TryParse(Console.ReadLine(), out int guess))
                {
                    Console.WriteLine("Введите целое число!");
                    continue;
                }

                result = game.CheckGuess(guess);

                if (result == 1)
                {
                    Console.WriteLine("Больше");
                }
                else if (result == -1)
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
