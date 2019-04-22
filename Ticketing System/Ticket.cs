using System;

namespace Ticketing_System
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int CreatorID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsFinished { get; set; }

        // does that make any sense? i think it does
        public ITicketsDB db = new TicketsDB();


        public void DisplayTicket()
        {
            Console.WriteLine($"Ticket ID: {TicketID}, Creator ID: {CreatorID}\n{Title}\n{Description}\n{CreationDate}\n");
        }

        public void FinishTicket()
        {
            db.FinishTicket(TicketID);
        }
    }
}
