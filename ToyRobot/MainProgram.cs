using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToyRobot
{
    class MainProgram
    {

        //Default file. MAKE SURE TO CHANGE THIS LOCATION AND FILE PATH TO YOUR FILE 
        static readonly string textFile = @"C:\ToyRobot\Settings\Commands.txt";

        public static void Init()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }

        static void Main(string[] args)
        {
            
            if (File.Exists(textFile))
            {
                string[] commands = File.ReadAllLines(textFile);
                Console.WriteLine(Commander(commands));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Commands.txt was not found. Please try again.");
                Console.WriteLine(@"Please make sure you have Commands.txt file located in C:\ToyRobot\Settings\ folder.");
                Console.ReadKey();
            }
        }

        static string Commander(string[]commands)
        {
            string message = "";
            Command obj = new Command();
            if (obj != null)
            {
                message = obj.Start(commands);
            }
            return message;
        }
    }
}
