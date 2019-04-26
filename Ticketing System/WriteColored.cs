using System;

namespace Ticketing_System
{
    partial class Program
    {
        static class WriteColored
        {
            public static void ColoredWriteLine(string Message)
            {
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(Message);
                Console.ForegroundColor = originalColor;
            }
        }
    }
}
