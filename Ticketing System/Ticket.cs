using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

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

        private readonly ITicketsDBConnection _connectionMaker = new TicketsDBConnection();


        public void DisplayTicket()
        {
            Console.WriteLine($"Ticket ID: {TicketID}, Creator ID: {CreatorID}\n{Title}\n{Description}\n{CreationDate}\n");
        }

        public string GetCreatorName()
        {
            string query = "SELECT Employees.FirstName, Employees.LastName FROM Tickets INNER JOIN Employees ON Tickets.CreatorID = Employees.EmployeeID WHERE TicketID = @TicketID";

            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                var creator = connection.QuerySingle<Employee>(query, new { TicketID });

                return creator.GetFullName();
            }
        }

        private void ExecuteQuery(string query)
        {
            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                connection.Execute(query);
            }
        }

        private void ExecuteQuery(string query, DynamicParameters parameters)
        {
            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                connection.Execute(query, parameters);
            }
        }


        public void AddTicket(int creatorID, string title, string description)
        {
            string query = "INSERT INTO Tickets(CreatorID, Title, Description, CreationDate) VALUES (@CreatorID, @Title, @Description, @CreationDate);";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@CreatorID", creatorID);
            parameters.Add("@Title", title);
            parameters.Add("@Description", description);
            parameters.Add("@CreationDate", DateTime.Now);

            ExecuteQuery(query, parameters);
        }


        public void FinishTicket(int ticketID)
        {
            string query = "UPDATE Tickets SET IsFinished = 1 WHERE TicketID = @TicketID";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("TicketID", ticketID);

            ExecuteQuery(query, parameters);
        }
    }
}
