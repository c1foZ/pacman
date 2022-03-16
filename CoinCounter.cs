using System;

namespace Pacman
{
    public class CoinCounter
    {
        public int coins { get; private set; }
        public bool CheckWinningCondition() => coins >= Constants.WINNING_COIN_COUNT;

        public void Increment()
        {
            coins += 1;
            Console.SetCursorPosition(0, 20);
            Console.Write("Score: ");
            Console.Write(coins);
        }
    }
}