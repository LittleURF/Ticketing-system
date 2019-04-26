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
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate, isFinished FROM Tickets WHERE TicketID = @TicketID";

            using (var connection = _connectionMaker.GetConnection())
            {
               connection.Open();
               return connection.QuerySingle<Ticket>(query, new { TicketID = ticketID });
            }
         
        }

        public void RemoveTicket(int ticketID)
        {
            string query = "DELETE FROM Tickets WHERE TicketID = @TicketID";

            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                connection.Execute(query, new { TicketID = ticketID });
            }
        }

        public Employee GetEmployee(int employeeID)
        {
            string query = "SELECT EmployeeID, FirstName, LastName FROM Employees WHERE EmployeeID = @EmployeeID";

            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                return connection.QuerySingle<Employee>(query, new { EmployeeID = employeeID });
            }
        }

        public List<Ticket> GetActiveTickets()
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
            allTickets.AddRange(GetActiveTickets());
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

        public bool CheckTicketIdExists(int ticketID)
        {
            try
            {
                var ticket = GetTicket(ticketID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckEmployeeIdExists(int employeeID)
        {
            try
            {
                var employee = GetEmployee(employeeID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
