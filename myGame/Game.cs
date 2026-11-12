using System;
namespace myGame
{
    public class Game
    {
        private int number;
        public event Action? GameWon;
        public event Action<int>? GuessMade;

        public Game(INumberGenerator generator, int minNumber, int maxNumber)
        {
            number = generator.Generate(minNumber, maxNumber);
        }

        public int CheckGuess(int guess)
        {
            GuessMade?.Invoke(guess);
            if (guess < number)
            {
                return 1;
            }
            else if (guess > number)
            {
                return -1;
            }
            else
            {
                GameWon?.Invoke();
                return 0;
            }
        }
    }
}
