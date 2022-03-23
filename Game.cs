using System;
using System.Threading;

namespace Pacman
{
    class Game
    {
        private Renderer rd = new Renderer();
        private World world = new World();
        private Enemy enemy = new Enemy();
        private CoinCounter cc = new CoinCounter();
        private Player player = new Player();
        private bool isOver = false;
        private int stepMs = 200;

        public void InitGame()
        {
            rd.PrintOnBoarding();
            GameLoop();
        }

        private void RestartGame()
        {
            Reset();
            GameLoop();
        }

        private void Reset()
        {
            isOver = false;
            cc.coins = 0;
            player.coords.X = Constants.PLAYER_STARTING_POSITION_X;
            player.coords.Y = Constants.PLAYER_STARTING_POSITION_Y;
            world = new World();
        }

        private void QuitGame()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        private void GameLoop()
        {
            Console.Clear();
            Console.CursorVisible = false;
            var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            ConsoleKey? lastKeyPress = ConsoleKey.DownArrow;

            while (true)
            {
                while (Console.KeyAvailable || isOver)
                {
                    var cmd = Console.ReadKey(false).Key;
                    lastKeyPress = cmd;
                }
                Thread.Sleep(5);
                long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                if (now - startTime <= stepMs)
                {
                    continue;
                }
                startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                if (lastKeyPress != null)
                {
                    player.ChangeDirection(GetDirection(lastKeyPress));
                    lastKeyPress = null;
                }
                player.Step();
                RenderingGame();
                CheckGameConditions();

            }

            Direction GetDirection(ConsoleKey? command) =>
             command switch
             {
                 ConsoleKey.DownArrow => Direction.DOWN,
                 ConsoleKey.UpArrow => Direction.UP,
                 ConsoleKey.LeftArrow => Direction.LEFT,
                 ConsoleKey.RightArrow => Direction.RIGHT,
                 _ => throw new Exception("Invalid console key"),
             };
        }

        private void RenderingGame()
        {
            RenderWorld();
            rd.PrintPlayer(player.coords.X, player.coords.Y);
            RenderEnemy();
        }

        private void RenderWorld()
        {
            int rowLength = world.GameWorld.GetLength(0);
            int colLength = world.GameWorld.GetLength(1);

            for (var x = 0; x < rowLength; x++)
            {
                for (var y = 0; y < colLength; y++)
                {
                    string element = world.GameWorld[x, y];
                    rd.PrintWorld(element, y, x);
                }
            }
        }

        private void RenderEnemy()
        {
            enemy.EnemyMove();
            rd.PrintEnemy(enemy.coords.X, enemy.coords.Y);
        }

        private void CheckGameConditions()
        {
            CheckCoin();
            CheckGameOver();
        }

        private void CheckGameOver()
        {
            if (enemy.coords.X == player.coords.X && enemy.coords.Y == player.coords.Y)
            {
                isOver = true;
                GameOver();
            }
        }

        private void GameOver()
        {
            rd.PrintGameOver(cc.coins);
            PressButton();
        }

        private void CheckCoin()
        {
            if (world.GameWorld[player.coords.Y, player.coords.X] == Constants.O)
            {
                world.GameWorld[player.coords.Y, player.coords.X] = Constants.S;
                cc.Increment();
                rd.PrintCoinScore(cc.coins);
            }

            if (cc.CheckWinningCondition())
            {
                rd.PrintWin(cc.coins);
                PressButton();
            }
        }

        private void PressButton()
        {
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        RestartGame();
                        break;
                    case ConsoleKey.Escape:
                        QuitGame();
                        break;
                }
            }
        }
    }
}
