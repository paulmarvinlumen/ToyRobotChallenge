namespace ToyRobot
{
    public class TableDimension
    {
        public int width;
        public int length;
        public bool IsValidLocation(int x, int y) => x >= 0 && x < width && y >= 0 && y < length;

        public bool IsValidMove(int x, int y, string _direction)
        {
            bool ret = true;
            if ((x == 0 && _direction == "west") || (y == 0 && _direction == "south") || (x == width-1 && _direction == "east") || (y == length-1 && _direction == "north"))
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
