namespace Pacman
{
    public class CoinCounter
    {
        private Renderer rd = new Renderer();
        public int coins { get; private set; }
        public bool CheckWinningCondition() => coins >= Constants.WINNING_COIN_COUNT;

        public void Increment()
        {
            coins += 1;
            rd.PrintCoin(coins);
        }
    }
}