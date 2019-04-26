using System;

namespace Ticketing_System
{
    partial class Program
    {
        static class VerifyInput
        {
            public static int GetVerifyIdInput()
            {
                WriteColored.ColoredWriteLine("Pass the ID ");
                string userInputArgument = Console.ReadLine();
                int id = -1;

                // if input is null or isnt parsable to int.   Shouldnt the out change ticketID even in the if
                if (String.IsNullOrWhiteSpace(userInputArgument) || !(Int32.TryParse(userInputArgument, out id)))
                {
                    WriteColored.ColoredWriteLine("\nThe argument is empty or isn't an integer\n");
                    return -1;
                }

                Int32.TryParse(userInputArgument, out id);


                return id;
            }
        }
    }
}
