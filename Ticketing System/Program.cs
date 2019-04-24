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
            var db = new TicketsDB();
            var mainTicket = db.GetTicket(6);
            mainTicket.DisplayTicket();

            mainTicket.ModifyDescription("I cant play candy crush when connected to my boys wi-fi");
            // mainTicket.FinishTicket();

            var openTickets = db.GetOpenTickets();
            foreach (var ticket in openTickets)
            {
                ticket.DisplayTicket();
            }

            Console.WriteLine("\n" + mainTicket.GetCreatorName() + "\n\n");

            var archivedTickets = db.GetArchivedTickets();

            foreach (var ticket in archivedTickets)
            {
                ticket.DisplayTicket();
            }

            Console.WriteLine("\n\n\n");
            var allTickets = db.GetAllTickets();

            foreach (var ticket in allTickets)
            {
                ticket.DisplayTicket();
            }


           // db.AddTicket(1, "Fix connection issues", "I cant get the damn app to open on my tablet");




            /* Functionalities to add:
             * - Getting all tickets made by a specific employee, open/archived or both
             * 
             * 
             * 
             * actualy creating a ticket in C# instead is gonna screw everything up, make it impossible to create one just liek that?
             * 
             * 
             */
        }
    }
}
