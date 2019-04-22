using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Ticketing_System
{
    public class TicketsDB 
    {
        private readonly TicketsDBConnection _connectionMaker = new TicketsDBConnection();


        public Ticket GetTicket(int ticketID)
        {
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate, isFinished FROM Tickets WHERE TicketID = @ticketID";
            using (var connection = _connectionMaker.GetConnection())
            {
               connection.Open();
               return connection.QuerySingle<Ticket>(query, new { TicketID = ticketID });
                
            }
         
        }

        public List<Ticket> ReturnQueryList(string query)
        {
            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                return connection.Query<Ticket>(query).AsList();
            }
        }

        public List<Ticket> GetOpenTickets()
        {
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate, isFinished FROM Tickets";

            return ReturnQueryList(query);
        }

        public List<Ticket> GetArchivedTickets()
        {
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate FROM TicketsArchived";

            return ReturnQueryList(query);

        }




    }
}
