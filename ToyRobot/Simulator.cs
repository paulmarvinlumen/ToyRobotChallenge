namespace ToyRobot
{
    public class Simulator
    {
        public Robot robot;
        public TableDimension Surface;
        private DisplayTableBoard displayTableBoard;
        private string CommandSteps, CommandStatus;

        public Simulator(TableDimension table)
        {
            Surface = table;
            displayTableBoard = new DisplayTableBoard(Surface);
        }

        public void Place(int _x, int _y, string direction)
        {
            if (Surface.IsValidLocation(_x, _y))
            {
                robot = new Robot
                {
                    direction = direction.ToLower(),
                    x = _x,
                    y = _y
                };

                CommandSteps = "PLACE";
                CommandStatus = string.Empty;
            }
        }

        public void RobotMoves(string movement)
        {
            CommandSteps = string.Format("{0}", movement.ToUpper());
            if (robot != null)
            {
                CommandStatus = string.Empty;
                switch (movement)
                {
                    case "move":
                        if (Surface.IsValidMove(robot.x, robot.y, robot.direction))
                        {
                            CommandStatus = string.Empty;
                            robot.Move();
                        }
                        else
                        {
                            CommandStatus = "Toy Robot must not move outside the given dimension.";
                        }
                        break;
                    case "right":
                        robot.TurnRight();
                        break;
                    case "left":
                        robot.TurnLeft();
                        break;
                }
            }
            else
            {
                CommandStatus = "Place Command has not been executed.";
            }
        }

        public void displaySimulation()
        {
            if (robot != null)
            {
                displayTableBoard.displayTableWithContent(robot.x, robot.y, robot.direction, CommandSteps, CommandStatus);
            }
            else
            {
                displayTableBoard.displayTableWithContent(-1, -1, "", CommandSteps, CommandStatus);
            }
        }
        
        public string Report()
        {
            CommandSteps = "REPORT";
            return robot.Report();
        }
    }
}
