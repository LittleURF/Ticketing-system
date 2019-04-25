using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_System
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Ticketing System 1.0\n");
            while (true)
            {
                Ticket currentTicket = null;
                if (currentTicket == null)
                    Console.WriteLine($"Current ticket is not set");
                else
                    Console.WriteLine($"Current ticket: ID: {currentTicket.TicketID} - {currentTicket.Title}" );
                Console.WriteLine("Available operations:\n");
                Console.WriteLine("0. Set current ticket");
                Console.WriteLine("1. Display a specific ticket(ID)");
                Console.WriteLine("2. Display all active tickets");
                Console.WriteLine("3. Display all archived tickets");
                Console.WriteLine("4. Display all tickets");
                Console.WriteLine("5. Display employee data(ID)");

                Console.WriteLine("\nCurrent Ticket based:");

                Console.WriteLine("6. Set ticket to finished");
                Console.WriteLine("7. Change ticket's title");
                Console.WriteLine("8. Change ticket's descriptions");


                var userInput = Console.ReadKey(true);

                switch (userInput.KeyChar)
                {
                    case '0':
                        {
                            break;
                        }
                    case '1':
                        {
                            break;
                        }
                    case '2':
                        {
                            break;
                        }

                    case '3':
                        {
                            break;
                        }

                    case '4':
                        {
                            break;
                        }
                    case '5':
                        {
                            break;
                        }
                    case '6':
                        {
                            break;
                        }
                    case '7':
                        {
                            break;
                        }
                    case '8':
                        {
                            break;
                        }

                    default:
                        Console.WriteLine("You've pressed a wrong character, you can only choose characters seen on the list");
                            break;
                }
            }
            var db = new TicketsDB();
            var mainTicket = db.GetTicket(6);
            mainTicket.DisplayTicket();
            // db.RemoveTicket(5);
            // mainTicket.ModifyDescription("I cant play when connected to wi-fi");
            // mainTicket.FinishTicket();

            var openTickets = db.GetOpenTickets();
            foreach (var ticket in openTickets)
            {
                ticket.DisplayTicket();
            }

            Console.WriteLine("\n" + mainTicket.GetCreatorName() + "\n\n");

            //var archivedTickets = db.GetArchivedTickets();

            //foreach (var ticket in archivedTickets)
            //{
            //    ticket.DisplayTicket();
            //}

            //Console.WriteLine("\n\n\n");
            //var allTickets = db.GetAllTickets();

            //foreach (var ticket in allTickets)
            //{
            //    ticket.DisplayTicket();
            //}

            var hubson = db.GetEmployee(1);
            
            var hubsonTickets = hubson.GetAllCreatedTickets();

            foreach (var ticket in hubsonTickets)
            {
                ticket.DisplayTicket();
            }


            // db.AddTicket(1, "Fix connection issues", "I cant get the damn app to open on my tablet");




            /* Functionalities to add:
             * - create a small console menu loop to operate the thing? with arguments passed from the user
             * 
             * - (?) Make some TicketsDBConnection methods to inherit? the using statement is god damn everywhere()
             * 
             * actualy creating a ticket in C# instead is gonna screw everything up, make it impossible to create one just liek that?
             * 
             * 
             */
        }
    }
}
