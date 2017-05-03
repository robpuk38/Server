using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheServer
{
    class Debug
    {

        public static void Log(string mess)
        {
             Console.WriteLine("Log: " + mess);
        }

        public static void Error(string mess)
        {
           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + mess);
           
            Console.ResetColor();
        }

        public static void Info(string mess)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Info: " + mess);

            Console.ResetColor();
        }

        public static void Starting(string mess)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Starting: " + mess);

            Console.ResetColor();
        }

        public static void Finished(string mess)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Finished: " + mess);

            Console.ResetColor();
        }

        public static void Cleared(string mess)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Cleared: " + mess);

            Console.ResetColor();
        }

        public static void Custom(string mess, ConsoleColor color)
        {

            Console.ForegroundColor = color;
            Console.WriteLine("Custom: "+mess);

            Console.ResetColor();
        }
    }
}
