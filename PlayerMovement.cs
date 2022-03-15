using System;
using System.Threading;

namespace pacman
{
    enum Direction
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }
    class PlayerMovement
    {
        World world = new World();
        EnemyMovement em = new EnemyMovement();
        Coin cn = new Coin();
        const string PLAYER = "◔";
        int playerPositionX = 1, playerPositionY = 1;
        bool isOver = false;
        public void movePlayer()
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
                runningGame();
            }

            void moveCursor()
            {
                if (playerPositionX >= 1 && playerPositionY >= 1)
                {
                    Console.SetCursorPosition(playerPositionX, playerPositionY);
                    Console.Write(PLAYER);
                }
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
                        Up();
                        break;
                    case Direction.RIGHT:
                        Right();
                        break;
                    case Direction.LEFT:
                        Left();
                        break;
                    case Direction.DOWN:
                        Down();
                        break;
                }
            }

            void Right()
            {
                if (world.maze[playerPositionY, playerPositionX + 1] != world.W)
                {
                    playerPositionX++;
                }
            }

            void Left()
            {
                if (world.maze[playerPositionY, playerPositionX - 1] != world.W)
                {
                    playerPositionX--;
                }
            }

            void Up()
            {
                if (world.maze[playerPositionY - 1, playerPositionX] != world.W)
                {
                    playerPositionY--;
                }
            }

            void Down()
            {
                if (world.maze[playerPositionY + 1, playerPositionX] != world.W)
                {
                    playerPositionY++;
                }
            }

            void runningGame()
            {
                world.renderWorld();
                moveCursor();
                em.enemyMove();
                checkCoin();
                checkGameOver();
            }

            void checkGameOver()
            {
                if (em.enemyPositionX == playerPositionX && em.enemyPositionY == playerPositionY)
                {
                    isOver = true;
                    Game game = new Game();
                    game.printGameOver(cn.coins);
                }
            }
            void checkCoin()
            {
                if (world.maze[playerPositionY, playerPositionX] == world.O)
                {
                    world.maze[playerPositionY, playerPositionX] = world.S;
                    cn.getCoin();
                }
            }
        }

    }
}