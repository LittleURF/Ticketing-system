using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Ticketing_System
{
    public class TicketsDB
    {
        private readonly SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Tickets"].ConnectionString);

        public Ticket GetTicket(int ticketID)
        {
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate, isFinished FROM Tickets WHERE TicketID = @ticketID";
            using (_connection)
            {
                _connection.Open();
               return _connection.QuerySingle<Ticket>(query, new { TicketID = ticketID });
            }
         
        }

        public List<Ticket> GetAllTickets()
        {
            throw new NotImplementedException();
        }
    }
}
