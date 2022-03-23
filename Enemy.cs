using static Pacman.Constants;
namespace Pacman
{
    class Enemy
    {
        public Coords coords = new Coords(ENEMY_RIGHT_TRAJECTORY, ENEMY_BOTTOM_TRAJECTORY);

        public void EnemyMove()
        {
            if (coords.Y == ENEMY_BOTTOM_TRAJECTORY)
            {
                coords.X--;
            }

            if (coords.X == ENEMY_LEFT_TRAJECTORY)
            {
                coords.Y--;
            }

            if (coords.Y == ENEMY_TOP_TRAJECTORY)
            {
                coords.X++;
            }

            if (coords.X == ENEMY_RIGHT_TRAJECTORY)
            {
                coords.Y++;
            }
        }
    }
}
