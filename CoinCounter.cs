namespace Pacman
{
    public class CoinCounter
    {
        public int coins { get; set; }
        public bool CheckWinningCondition() => coins >= Constants.WINNING_COIN_COUNT;

        public void Increment()
        {
            coins += 1;
        }
    }
}