using System;
using System.Threading;

namespace Pacman
{
    class Game
    {
        private Renderer rd = new Renderer();
        private World world = new World();
        private Enemy em = new Enemy();
        private CoinCounter cn = new CoinCounter();
        private PlayerMovement pm = new PlayerMovement();
        private bool isOver = false;

        public void InitGame()
        {
            rd.PrintOnBoarding();
            RunningGame();
        }

        private void RestartGame()
        {
            Game game = new Game();
            game.RunningGame();
        }

        private void QuitGame()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        private void RunningGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            var direction = Direction.DOWN;
            var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var stepMs = 200;
            ConsoleKey? lastKeyPress = null;
            long now;

            while (true)
            {
                while (Console.KeyAvailable || isOver)
                {
                    var cmd = Console.ReadKey(false).Key;
                    lastKeyPress = cmd;
                }
                Thread.Sleep(5);
                now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                if (now - startTime <= stepMs)
                {
                    continue;
                }
                startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                if (lastKeyPress != null)
                {
                    ChangeDirection(lastKeyPress);
                    lastKeyPress = null;
                }
                Step();
                RenderingGame();
            }

            void ChangeDirection(ConsoleKey? command)
            {
                switch (command)
                {
                    case ConsoleKey.DownArrow:
                        direction = Direction.DOWN;
                        break;
                    case ConsoleKey.UpArrow:
                        direction = Direction.UP;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = Direction.RIGHT;
                        break;
                }
            }

            void Step()
            {
                switch (direction)
                {
                    case Direction.UP:
                        pm.Up();
                        break;
                    case Direction.RIGHT:
                        pm.Right();
                        break;
                    case Direction.LEFT:
                        pm.Left();
                        break;
                    case Direction.DOWN:
                        pm.Down();
                        break;
                }
            }
        }

        private void RenderingGame()
        {
            world.RenderWorld();
            pm.MoveCursor();
            em.EnemyMove();
            CheckCoin();
            CheckGameOver();
        }

        private void CheckGameOver()
        {
            if (em.enemyPositionX == pm.playerPositionX && em.enemyPositionY == pm.playerPositionY)
            {
                isOver = true;
                GameOver();
            }
        }

        private void GameOver()
        {
            rd.PrintGameOver(cn.coins);
            PressButton();
        }

        private void CheckCoin()
        {
            if (world.maze[pm.playerPositionY, pm.playerPositionX] == Constants.O)
            {
                world.maze[pm.playerPositionY, pm.playerPositionX] = Constants.S;
                cn.Increment();
            }

            if (cn.CheckWinningCondition())
            {
                rd.PrintWin(cn.coins);
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
