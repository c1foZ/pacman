using System;

namespace Pacman
{
    public class CoinCounter
    {

        public int coins { get; private set; }

        public void Increment()
        {
            coins += 1;
            Console.SetCursorPosition(0, 20);
            Console.Write("Score: ");
            Console.Write(coins);
            // if (CheckWinningCondition())
            // {
            //     Game game = new Game();
            //     game.printWin(_coins);

            // }
        }

        public bool CheckWinningCondition() => coins >= Constants.WINNING_COIN_COUNT;
    }
}