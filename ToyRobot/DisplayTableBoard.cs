using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class DisplayTableBoard
    {
        public TableDimension _table;
        static int tableWidth = 200;

        public DisplayTableBoard(TableDimension table)
        {
            _table = table;
        }


        public void displayTableWithContent(int x, int y, string robotPosition, string _commandStep, string _commandStatus)
        {


            Console.Clear();
            Console.WriteLine("Legend: T -> Toy Robot");

            for (int i = _table.length-1; i >= 0; i--)
            {
                string[] col = new string[_table.width];
                for (int j = _table.width-1; j >= 0 ; j--)
                {

                    if (i== y && j == x)
                    {
                        col[j] = "T";
                    }
                    else
                        col[j] = " ";

                }
                PrintLine();
                PrintRow(col);
            }
            PrintLine();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Command: " + _commandStep);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(string.Format("{0}: {1}", _commandStatus.Length > 0 ? "Command Failed" : "Command Successfully Executed", _commandStatus));
            Console.WriteLine(Environment.NewLine);

            if (_commandStatus == string.Empty)
            {
                Console.WriteLine("Toy Robot is currently facing " + robotPosition + ".");
            }
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
