using Dapper;
using System;
using System.Collections.Generic;
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


        public virtual void DisplayTicket()
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




        public void FinishTicket()
        {
            string query = "UPDATE Tickets SET IsFinished = 1 WHERE TicketID = @TicketID";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("TicketID", this.TicketID);

            ExecuteQuery(query, parameters);
        }
        

        private void Modify(string query, string newValue)
        {
            if (String.IsNullOrWhiteSpace(newValue))
                throw new ArgumentNullException();

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("NewValue", newValue);
            parameters.Add("TicketID", this.TicketID);

            ExecuteQuery(query, parameters);

        }

        public void ModifyTitle(string newValue)
        {
            string query = "UPDATE Tickets SET Title = @NewValue WHERE TicketID = @TicketID";
            Modify(query, newValue);
            this.Title = newValue;
        }

        public void ModifyDescription(string newValue)
        {
            string query = "UPDATE Tickets SET Description = @NewValue WHERE TicketID = @TicketID";
            Modify(query, newValue);
            this.Description = newValue;
        }
    }
}
