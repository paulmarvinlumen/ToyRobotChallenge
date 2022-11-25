namespace ToyRobot
{
    public class TableDimension
    {
        public int width;
        public int length;
        public bool IsValidLocation(int x, int y)
        {
            bool ret = false;

            if (x >= 0 && x < width && y >= 0 && y < length)
            {
                ret = true;
            }

            return ret;
        }

        public bool IsValidDirection(string direction)
        {
            bool ret = false;

            if (direction == "north" || direction == "east" || direction == "west" || direction == "south")
            {
                ret = true;
            }

            return ret;
        }

        public bool IsValidMove(int x, int y, string direction)
        {
            bool ret = true;
            if ((x == 0 && direction == "west") || (y == 0 && direction == "south") || (x == width-1 && direction == "east") || (y == length-1 && direction == "north"))
            {
                ret = false;
            }
            
            return ret;
            
        }

        public TableDimension(int width, int length)
        {
            this.width = width;
            this.length = length;
        }
    }
}
