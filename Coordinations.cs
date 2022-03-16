namespace Pacman
{
    struct EnemyCoords
    {
        public static int X;
        public static int Y;
        public static int CursorX = Constants.ENEMY_RIGHT_TRAJECTORY;
        public static int CursorY = Constants.ENEMY_BOTTOM_TRAJECTORY;
    }

    struct PlayerCoords
    {
        public static int X = Constants.PLAYER_STARTING_POSITION_X;
        public static int Y = Constants.PLAYER_STARTING_POSITION_Y;
    }
}