using System;

namespace Pacman
{
    class Enemy
    {
        public int enemyPositionX = 0, enemyPositionY = 0;
        private int enemyCursorX = Constants.ENEMY_RIGHT_TRAJECTORY, enemyCursorY = Constants.ENEMY_BOTTOM_TRAJECTORY;

        public void EnemyMove()
        {
            if (enemyCursorX != Constants.ENEMY_LEFT_TRAJECTORY && enemyCursorY == Constants.ENEMY_BOTTOM_TRAJECTORY)
            {
                enemyCursorX--;
                Console.SetCursorPosition(enemyCursorX, enemyCursorY);
                Console.Write(Constants.ENEMY);
                enemyPositionX = enemyCursorX;
                enemyPositionY = enemyCursorY;
            }

            if (enemyCursorX == Constants.ENEMY_LEFT_TRAJECTORY && enemyCursorY != Constants.ENEMY_TOP_TRAJECTORY)
            {
                enemyCursorY--;
                Console.SetCursorPosition(enemyCursorX, enemyCursorY + 1);
                Console.Write(Constants.ENEMY);
                enemyPositionX = enemyCursorX;
                enemyPositionY = enemyCursorY + 1;
            }

            if (enemyCursorX != Constants.ENEMY_RIGHT_TRAJECTORY && enemyCursorY == Constants.ENEMY_TOP_TRAJECTORY)
            {
                enemyCursorX++;
                Console.SetCursorPosition(enemyCursorX - 1, enemyCursorY + 1);
                Console.Write(Constants.ENEMY);
                enemyPositionX = enemyCursorX - 1;
                enemyPositionY = enemyCursorY + 1;
            }

            if (enemyCursorX == Constants.ENEMY_RIGHT_TRAJECTORY && enemyCursorY != Constants.ENEMY_BOTTOM_TRAJECTORY)
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