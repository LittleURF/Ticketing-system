using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_System
{
    partial class Program
    {

        static void Main(string[] args)
        {
            var db = new TicketsDB();
            Ticket currentTicket = null;

            Console.WriteLine("Ticketing System 1.0\n");

            while (true)
            {
                if (currentTicket == null)
                    Console.WriteLine($"Current ticket is not set\n");
                else
                    Console.WriteLine($"Current ticket: ID: {currentTicket.TicketID} - {currentTicket.Title}\n" );
                WriteColored.ColoredWriteLine("Available operations:\n");
                Console.WriteLine("0. Set current ticket(ID)");
                Console.WriteLine("1. Add a ticket(CreatorID, title, description)");
                Console.WriteLine("2. Display a specific ticket(ID)");
                Console.WriteLine("3. Display all active tickets");
                Console.WriteLine("4. Display all archived tickets");
                Console.WriteLine("5. Display all tickets");
                Console.WriteLine("6. Display employee data(ID)");

                WriteColored.ColoredWriteLine("\nCurrent Ticket based:");

                Console.WriteLine("7. Set ticket to finished");
                Console.WriteLine("8. Change ticket's title");
                Console.WriteLine("9. Change ticket's descriptions\n");


                var userInputOperation = Console.ReadKey(true);
                
                switch (userInputOperation.KeyChar)
                {
                    case '0':
                        {
                            int ticketID = VerifyInput.GetVerifyIdInput();

                            if (!db.CheckTicketIdExists(ticketID))
                                WriteColored.ColoredWriteLine("Ticket with that ID does not exist in the database");

                            else
                                currentTicket = db.GetTicket(ticketID);
                                
                            break;
                        }
                    case '1':
                        {
                            var creatorID = VerifyInput.GetVerifyIdInput();
                            if (!db.CheckEmployeeIdExists(creatorID))
                            {
                                WriteColored.ColoredWriteLine("Employee with that ID does not exist in the database");
                                break;
                            }
                            Console.WriteLine("Pass the ticket's title");
                            var title = Console.ReadLine();

                            Console.WriteLine("Pass the ticket's description");
                            var description = Console.ReadLine();

                            if (String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(description))
                            {
                                Console.WriteLine("\nTitle and description fields cannot be empty\n");
                                break;
                            }

                            db.AddTicket(creatorID, title, description);
                            break;
                        }
                    case '2':
                        {
                            var ticket = db.GetTicket(VerifyInput.GetVerifyIdInput());
                            ticket.DisplayTicket();
                            break;
                        }
                    case '3':
                        {
                            var ticketsActive = db.GetActiveTickets();

                            foreach (var ticket in ticketsActive)
                            {
                                ticket.DisplayTicket();
                            }
                            break;
                        }

                    case '4':
                        {
                            var ticketsArchived = db.GetArchivedTickets();

                            foreach (var ticket in ticketsArchived)
                            {
                                ticket.DisplayTicket();
                            }
                            break;
                        }

                    case '5':
                        {
                            var ticketsAll = db.GetAllTickets();


                            foreach (var ticket in ticketsAll)
                            {
                                ticket.DisplayTicket();
                            }
                            break;
                        }
                    case '6':
                        {
                            var employeeID = VerifyInput.GetVerifyIdInput();
                            if (!db.CheckEmployeeIdExists(employeeID))
                            {
                                WriteColored.ColoredWriteLine("Employee with that ID does not exist in the database");
                                break;
                            }
                                
                            var employee = db.GetEmployee(employeeID);
                            employee.DisplayInfo();
                            break;
                        }
                    case '7':
                        {
                            if(currentTicket == null)
                            {
                                WriteColored.ColoredWriteLine("Current ticket is not defined");
                                break;
                            }

                            currentTicket.FinishTicket();
                            currentTicket = null;
                            break;
                        }
                    case '8':
                        {
                            if (currentTicket == null)
                            {
                                WriteColored.ColoredWriteLine("Current ticket is not defined");
                                break;
                            }

                            WriteColored.ColoredWriteLine("Pass the new title");
                            string userInputArgument = Console.ReadLine();
                            currentTicket.ModifyTitle(userInputArgument);

                            break;
                        }
                    case '9':
                        {
                            if (currentTicket == null)
                            {
                                WriteColored.ColoredWriteLine("Current ticket is not defined");
                                break;
                            }

                            Console.WriteLine("Pass the new description");
                            string userInputArgument = Console.ReadLine();
                            currentTicket.ModifyDescription(userInputArgument);
                            break;
                        }

                    default:
                        WriteColored.ColoredWriteLine("You've pressed a wrong character, you can only choose characters seen on the list\n");
                            break;
                }
                WriteColored.ColoredWriteLine("\nOperation finished\n\n");
            }


            /* Functionalities to add:
             * - (?) Make some TicketsDBConnection methods to inherit? the using statement is god damn everywhere()
             * 
             * 
             */
        }
    }
}
