using System;
using System.Collections.Generic;

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
            var random = new Random();

            // Initialize enemies
            var enemies = new List<(int x, int y)>
            {
                (10, 10), // Enemy 1
                (15, 5),  // Enemy 2
                (20, 15)  // Enemy 3
            };

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

            void MoveEnemies()
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    int move = random.Next(4);
                    var (x, y) = enemies[i];
                    switch (move)
                    {
                        case 0: if (y > 1 && maze[y - 1, x] != W) y--; break; // Up
                        case 1: if (y < maxDown && maze[y + 1, x] != W) y++; break; // Down
                        case 2: if (x > 1 && maze[y, x - 1] != W) x--; break; // Left
                        case 3: if (x < maxRight && maze[y, x + 1] != W) x++; break; // Right
                    }
                    enemies[i] = (x, y);
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

                // Draw the player
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(PLAYER);

                // Draw the enemies
                foreach (var (x, y) in enemies)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(ENEMY);
                }
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
                MoveEnemies();
                Draw();

                // Check for collision with any enemy
                foreach (var (x, y) in enemies)
                {
                    if (playerX == x && playerY == y)
                    {
                        Console.SetCursorPosition(0, maxDown + 2);
                        Console.WriteLine("Game Over!");
                        return;
                    }
                }
            }
        }

        enum Direction { UP, DOWN, LEFT, RIGHT }
    }
}
