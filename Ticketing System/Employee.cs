using Dapper;
using System;
using System.Collections.Generic;

namespace Ticketing_System
{

    public class Employee: IEmployee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private readonly ITicketsDBConnection _connectionMaker = new TicketsDBConnection();

        public void DisplayInfo()
        {
            Console.WriteLine($"Employee ID: {EmployeeID} - {GetFullName()}");
        }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public List<Ticket> GetCreatedActiveTickets()
        {
            string query = "SELECT TicketID, CreatorID, Title, Description, CreationDate, isFinished FROM Tickets WHERE CreatorID = @CreatorID";
            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                return  connection.Query<Ticket>(query, new { CreatorID = this.EmployeeID }).AsList();

            }
        }

        public List<ArchivedTicket> GetCreatedArchivedTickets()
        {
            string query = "SELECT ArchivisationID, TicketID, CreatorID, Title, Description, CreationDate, FinishedDate FROM TicketsArchived WHERE CreatorID = @CreatorID";
            using (var connection = _connectionMaker.GetConnection())
            {
                connection.Open();
                return connection.Query<ArchivedTicket>(query, new { CreatorID = this.EmployeeID }).AsList();
            }
        }

        public List<Ticket> GetAllCreatedTickets()
        {
            var activeTickets = GetCreatedActiveTickets();
            var archivedTickets = GetCreatedArchivedTickets();

            activeTickets.AddRange(archivedTickets);
            return activeTickets;
        }



        public void ShowFinishedTickets()
        {
            // Gotta make FinishedBy in the Database
            throw new NotImplementedException();
        }
    }
}
