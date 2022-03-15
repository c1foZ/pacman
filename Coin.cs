using System;

namespace pacman
{
    class Coin
    {
        int _coins;
        public int coins
        {
            get { return _coins; }
            private set { }
        }
        public void getCoin()
        {
            _coins += 1;
            Console.SetCursorPosition(0, 20);
            Console.Write("Score: ");
            Console.Write(_coins);
            if (_coins == 15)
            {
                Game game = new Game();
                game.printWin(_coins);

            }
        }
    }
}