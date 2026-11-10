
using System;

namespace myGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите уровень сложности:");
            Console.WriteLine("1 - Легкий (1-50)");
            Console.WriteLine("2 - Средний (1-100)");
            Console.WriteLine("3 - Сложный (1-333)");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice)
                   || choice < 1 || choice > 3)
            {
                Console.WriteLine("Введите число от 1 до 3:");
            }

            Levels level = (Levels)choice;

            NumberGenerator generator = new NumberGenerator();
            Game game = new Game(generator, level);

            int result = 1;

            Console.WriteLine("Игра началась!");

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
