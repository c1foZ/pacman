namespace Pacman
{
    class World
    {
        private Renderer rd = new Renderer();
        public string[,] maze =  {
                {Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W},
            };

        public void RenderWorld()
        {
            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);

            for (int mazePositionX = 0; mazePositionX < rowLength; mazePositionX++)
            {
                for (int mazePositionY = 0; mazePositionY < colLength; mazePositionY++)
                {
                    string element = maze[mazePositionX, mazePositionY];
                    rd.PrintWorld(element, mazePositionY, mazePositionX);
                }
            }
        }
    }
}
