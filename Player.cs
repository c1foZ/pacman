namespace Pacman
{
    class Player
    {
        private World world = new World(); //delete
        private Direction direction;
        public Coords coords = new Coords(1, 1);

        private void Right()
        {
            if (world.GameWorld[coords.Y, coords.X + 1] != Constants.W)
            {
                coords.X++;
            }
        }

        private void Left()
        {
            if (world.GameWorld[coords.Y, coords.X - 1] != Constants.W)
            {
                coords.X--;
            }
        }

        private void Up()
        {
            if (world.GameWorld[coords.Y - 1, coords.X] != Constants.W)
            {
                coords.Y--;
            }
        }

        private void Down()
        {
            if (world.GameWorld[coords.Y + 1, coords.X] != Constants.W)
            {
                coords.Y++;
            }
        }

        public void ChangeDirection(Direction direction)
        {
            this.direction = direction;
        }

        public void Step()
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
    }
}

