using System;

namespace Ticketing_System
{
    public class ArchivedTicket : Ticket
    {
        public int ArchivisationID { get; set; }
        public DateTime FinishedDate { get; set; }

        public void DisplayTicket()
        {
            Console.WriteLine($"Archivisation ID: {ArchivisationID}, Ticket ID: {TicketID}, Creator ID: {CreatorID}\n{Title}\n{Description}\n{CreationDate} - {FinishedDate}\n");
        }
    }
}


