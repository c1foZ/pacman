using System;
using System.Threading;
using System.Transactions;

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
        const string PLAYER = "◔";
        const string ENEMY = "X";
        const string o = ".";
        const int maxRight = 23; // delete
        const int maxDown = 20; // delete
        static void Main(string[] args)
        {
            Game game = new Game();
            game.printOnBoarding();

            Console.Clear();
            int x = 1, y = 1;
            int enemyX = 14, enemyY = 16;
            int enemyPositionX = 0, enemyPositionY = 0;
            int distance = 0;
            bool isOver = false;

            Move(x, y);
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
            Move(x, y);

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
                Move(x, y);
                GetCoin();
                enemyMove();
                gameOver();
            }

            void gameOver()
            {
                if (enemyPositionX == x && enemyPositionY == y)
                {
                    isOver = true;
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine(@"
                    ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
                    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
                    ██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
                    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
                    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║
                    ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝                                                                          
");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    Console.Clear();
                    Environment.Exit(0);
                }
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

            void Move(int playerX, int playerY)
            {
                if (playerX >= 1 && playerY >= 1 && playerX <= maxRight && playerY <= maxDown)
                {
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write(PLAYER);
                }
            }

            void enemyMove()
            {
                if (enemyX >= 1 && enemyY >= 1 && enemyX <= maxRight && enemyY <= maxDown)
                {
                    distance = Math.Abs(x - enemyX) + Math.Abs(y - enemyY);
                    Console.SetCursorPosition(3, 20);
                    System.Console.WriteLine(distance);

                    if (enemyX != 10 && enemyY == 16)
                    {
                        enemyX--;
                        Console.SetCursorPosition(enemyX, enemyY);
                        Console.Write(ENEMY);
                        enemyPositionX = enemyX;
                        enemyPositionY = enemyY;
                    }

                    if (enemyX == 10 && enemyY != 3)
                    {
                        enemyY--;
                        Console.SetCursorPosition(enemyX, enemyY + 1);
                        Console.Write(ENEMY);
                        enemyPositionX = enemyX;
                        enemyPositionY = enemyY + 1;
                    }

                    if (enemyX != 15 && enemyY == 3)
                    {
                        enemyX++;
                        Console.SetCursorPosition(enemyX - 1, enemyY + 1);
                        Console.Write(ENEMY);
                        enemyPositionX = enemyX - 1;
                        enemyPositionY = enemyY + 1;
                    }

                    if (enemyX == 15 && enemyY != 16)
                    {
                        enemyY++;
                        Console.SetCursorPosition(enemyX - 1, enemyY);
                        Console.Write(ENEMY);
                        enemyPositionX = enemyX - 1;
                        enemyPositionY = enemyY;
                    }
                    // else
                    // {
                    //     enemyPositionX = enemyX;
                    //     enemyPositionY = enemyY;
                    // }
                }
            }

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
