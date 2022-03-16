using System;

namespace Pacman
{
    class Enemy
    {
        public int enemyPositionX = 0, enemyPositionY = 0;
        int enemyCursorX = 14, enemyCursorY = 16;
        public void EnemyMove()
        {
            if (enemyCursorX != 10 && enemyCursorY == 16)
            {
                enemyCursorX--;
                Console.SetCursorPosition(enemyCursorX, enemyCursorY);
                Console.Write(Constants.ENEMY);
                enemyPositionX = enemyCursorX;
                enemyPositionY = enemyCursorY;
            }

            if (enemyCursorX == 10 && enemyCursorY != 3)
            {
                enemyCursorY--;
                Console.SetCursorPosition(enemyCursorX, enemyCursorY + 1);
                Console.Write(Constants.ENEMY);
                enemyPositionX = enemyCursorX;
                enemyPositionY = enemyCursorY + 1;
            }

            if (enemyCursorX != 15 && enemyCursorY == 3)
            {
                enemyCursorX++;
                Console.SetCursorPosition(enemyCursorX - 1, enemyCursorY + 1);
                Console.Write(Constants.ENEMY);
                enemyPositionX = enemyCursorX - 1;
                enemyPositionY = enemyCursorY + 1;
            }

            if (enemyCursorX == 15 && enemyCursorY != 16)
            {
                enemyCursorY++;
                Console.SetCursorPosition(enemyCursorX - 1, enemyCursorY);
                Console.Write(Constants.ENEMY);
                enemyPositionX = enemyCursorX - 1;
                enemyPositionY = enemyCursorY;

            }
        }
    }
}