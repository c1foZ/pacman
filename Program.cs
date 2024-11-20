using System;
using System.Threading;

namespace pacman
{
    class Program
    {
        const string W = "■";
        const string S = "\u2009";
        const string PLAYER = "◖";
        const string ENEMY = "☠";
        const string o = ".";
        const int maxRight = 23;
        const int maxDown = 20;
        static void Main(string[] args)
        {
            Game game = new Game();
            game.printOnBoarding();
            int playerX = 1, playerY = 1;
            int enemyX = 10, enemyY = 10;
            var random = new Random();

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
            var direction = Direction.DOWN;

            void MovePlayer()
            {
                switch (direction)
                {
                    case Direction.UP:
                        if (playerY > 1 && maze[playerY - 1, playerX] != W) playerY--;
                        break;
                    case Direction.DOWN:
                        if (playerY < maxDown && maze[playerY + 1, playerX] != W) playerY++;
                        break;
                    case Direction.LEFT:
                        if (playerX > 1 && maze[playerY, playerX - 1] != W) playerX--;
                        break;
                    case Direction.RIGHT:
                        if (playerX < maxRight && maze[playerY, playerX + 1] != W) playerX++;
                        break;
                }
            }

            void MoveEnemy()
            {
                int move = random.Next(4);
                switch (move)
                {
                    case 0: // Up
                        if (enemyY > 1 && maze[enemyY - 1, enemyX] != W) enemyY--;
                        break;
                    case 1: // Down
                        if (enemyY < maxDown && maze[enemyY + 1, enemyX] != W) enemyY++;
                        break;
                    case 2: // Left
                        if (enemyX > 1 && maze[enemyY, enemyX - 1] != W) enemyX--;
                        break;
                    case 3: // Right
                        if (enemyX < maxRight && maze[enemyY, enemyX + 1] != W) enemyX++;
                        break;
                }
            }

            void Draw()
            {
                Console.Clear();
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(maze[i, j]);
                    }
                }
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(PLAYER);
                Console.SetCursorPosition(enemyX, enemyY);
                Console.Write(ENEMY);
            }

            Console.CursorVisible = false;
            var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var stepMs = 200;

            while (true)
            {
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    direction = key switch
                    {
                        ConsoleKey.UpArrow => Direction.UP,
                        ConsoleKey.DownArrow => Direction.DOWN,
                        ConsoleKey.LeftArrow => Direction.LEFT,
                        ConsoleKey.RightArrow => Direction.RIGHT,
                        _ => direction
                    };
                }

                long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                if (now - startTime < stepMs) continue;
                startTime = now;

                MovePlayer();
                MoveEnemy();
                Draw();

                if (playerX == enemyX && playerY == enemyY)
                {
                    Console.SetCursorPosition(0, maxDown + 2);
                    Console.WriteLine("Game Over!");
                    break;
                }
            }
        }

        enum Direction { UP, DOWN, LEFT, RIGHT }
    }
}
