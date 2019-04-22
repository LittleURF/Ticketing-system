using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Ticketing_System
{

    public  class TicketsDB : ITicketsDB
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Tickets"].ConnectionString;


        public Ticket GetTicket(int ticketID)
        {
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate, isFinished FROM Tickets WHERE TicketID = @ticketID";
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
               return _connection.QuerySingle<Ticket>(query, new { TicketID = ticketID });
                
            }
         
        }

        public List<Ticket> GetAllTickets()
        {
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate, isFinished FROM Tickets";
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                return _connection.Query<Ticket>(query).AsList();
            }
        }

        // Make adding parameters and executing query into a different method to avoid repetition
        public void AddTicket(int creatorID, string title, string description)
        {
            string query = "INSERT INTO Tickets(CreatorID, Title, Description, CreationDate) VALUES (@CreatorID, @Title, @Description, @CreationDate);";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@CreatorID", creatorID);
            parameters.Add("@Title", title);
            parameters.Add("@Description", description);
            parameters.Add("@CreationDate", DateTime.Now);

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                _connection.Execute(query, parameters);
            }
        }

        public void FinishTicket(int ticketID)
        {
            string query = "UPDATE Tickets SET IsFinished = 1 WHERE TicketID = @TicketID";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("TicketID", ticketID);

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                _connection.Execute(query, parameters);
            }
        }


    }
}
