using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Ticketing_System
{
    public class TicketsDB 
    {
        private readonly ITicketsDBConnection _connectionMaker = new TicketsDBConnection();


        public Ticket GetTicket(int ticketID)
        {
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate, isFinished FROM Tickets WHERE TicketID = @ticketID";

            using (var connection = _connectionMaker.GetConnection())
            {
               connection.Open();
               return connection.QuerySingle<Ticket>(query, new { TicketID = ticketID });
            }
         
        }

        public List<Ticket> GetOpenTickets()
        {
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate, isFinished FROM Tickets";

            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                return connection.Query<Ticket>(query).AsList();
            }
        }

        public List<ArchivedTicket> GetArchivedTickets()
        {
            string query = "SELECT ArchivisationID, TicketID, CreatorID, Title, Description, CreationDate, FinishedDate FROM TicketsArchived";

            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                return connection.Query<ArchivedTicket>(query).AsList();
            }

        }

        public List<Ticket> GetAllTickets()
        {
            var allTickets = new List<Ticket>();
            allTickets.AddRange(GetOpenTickets());
            allTickets.AddRange(GetArchivedTickets());

            return allTickets;
        }


        public void AddTicket(int creatorID, string title, string description)
        {
            string query = "INSERT INTO Tickets(CreatorID, Title, Description, CreationDate) VALUES (@CreatorID, @Title, @Description, @CreationDate);";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@CreatorID", creatorID);
            parameters.Add("@Title", title);
            parameters.Add("@Description", description);
            parameters.Add("@CreationDate", DateTime.Now);

            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                connection.Execute(query, parameters);
            }
        }
    }
}
