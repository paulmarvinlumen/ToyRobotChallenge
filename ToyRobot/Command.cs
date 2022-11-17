using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class Command
    {
        public Simulator Simulation;
        public TableDimension Table = new TableDimension(5, 5);
        public bool Placed;
        public string Message = string.Empty;
        public string ErrorInputs = "The inputs in the file are not correctly formatted.";

        public string Start(string[] commands)
        {
            Simulation = new Simulator(Table);
            foreach (string command in commands)
            {
                ProcessCommand(command);

                if (Message == ErrorInputs)
                {
                    Console.Clear();
                    break;
                }
                if (Message.Length > 1)
                {
                    Simulation.displaySimulation(); //Display Simulation to CLI
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine(Message);
                    Message = "";
                }
                else
                {
                    Simulation.displaySimulation(); //Display Simulation to CLI
                }

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            return Message;
        }

        public void ProcessCommand(string command)
        {
            if (Regex.IsMatch(command, "^PLACE"))
            {
                string[] coordinates = command.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                if (coordinates.Length == 4)
                {
                    int x;
                    int y;
                    bool checkEastValue = Int32.TryParse(coordinates[1], out x);
                    bool checkNorthValue = Int32.TryParse(coordinates[2], out y);
                    if (checkEastValue && checkNorthValue)
                    {
                        Simulation.Place(x, y, coordinates[3]);
                    }
                }
                if (Simulation.robot == null)
                {
                    Message = ErrorInputs;
                }
            }
            else if (Regex.IsMatch(command, "^MOVE") || Regex.IsMatch(command, "^RIGHT") || Regex.IsMatch(command, "^LEFT"))
            {
                Simulation.RobotMoves(command.ToLower());
            }
            else if (Regex.IsMatch(command, "^REPORT"))
            {
                Message = Simulation.Report();
            }
            else
            {
                Message = ErrorInputs;
            }

        }
    }
}
