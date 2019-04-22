using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TicketsDB();
            var mainTicket = db.GetTicket(1);
            mainTicket.DisplayTicket();

            mainTicket.FinishTicket();

            var allTickets = db.GetAllTickets();

            foreach (var ticket in allTickets)
            {
                ticket.DisplayTicket();
            }

            //db.AddTicket(3, "Fix connection issues", "Iphone users cant connect whenever they have the paint app open");




            /*
             * actualy creating a ticket in C# instead is gonna screw everything up, make it impossible to create one just liek that?
             * 
             * 
             */
        }
    }
}
