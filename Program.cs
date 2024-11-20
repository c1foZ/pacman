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

    class Program
    {
        const string W = "■";
        const string S = "\u2009";
        const string PLAYER = "◖";
        const string o = ".";
        const int maxRight = 23; // delete
        const int maxDown = 20; // delete
        const int timeout = 1000;
        static void Main(string[] args)
        {
            Game game = new Game();
            // World world = new World();
            // PlayerMovement movement = new PlayerMovement();

            game.printOnBoarding();
            // movement.movePlayer();
            // Console.Clear();
            int x = 1, y = 1;

            Move(PLAYER, x, y);
            string[,] maze = {
                {W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W},
            };

            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);
            int coins = 0;

            DrawWorld();
            Move(PLAYER, x, y);

            Console.CursorVisible = false;

            var direction = Direction.DOWN;
            var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var stepMs = 200;
            ConsoleKey? lastKeyPress = null;
            long now;
            while (true)
            {
                while (Console.KeyAvailable)
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
                Play();
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
                if (x < maxRight && maze[y, x + 1] != W)
                {
                    x++;
                }
            }

            void Left()
            {
                if (x > 1 && maze[y, x - 1] != W)
                {
                    x--;
                }
            }

            void Up()
            {
                if (y > 1 && maze[y - 1, x] != W)
                {
                    y--;
                }
            }

            void Down()
            {
                if (y < maxDown && maze[y + 1, x] != W)
                {
                    y++;
                }
            }

            void Play()
            {
                DrawWorld();
                Move(PLAYER, x, y);
                GetCoin();
            }

            void GetCoin()
            {
                if (maze[y, x] == o)
                {
                    maze[y, x] = S;
                    coins += 1;
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(coins);
                    Console.WriteLine("");
                }
            }

            void Move(string PLAYER, int x, int y)
            {
                if (x >= 1 && y >= 1 && x <= maxRight && y <= maxDown)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(PLAYER);
                }
            }
            // void enemyMove(string ENEMY, int x = 10, int y = 10)
            // {
            //     Console.Write(ENEMY);
            // }

            void DrawWorld()
            {
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        string element = maze[i, j];
                        Console.SetCursorPosition(j, i);
                        Console.Write(element);
                    }
                }
            }
        }
    }
}
