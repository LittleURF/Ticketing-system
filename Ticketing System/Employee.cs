using System;

namespace Ticketing_System
{

    class Employee: IEmployee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public void ShowActiveTickets()
        {
           throw new NotImplementedException();
        }

        public void ShowAllTickets()
        {
            throw new NotImplementedException();
        }

        public void ShowFinishedTickets()
        {
            // Gotta make FinishedBy in the Database
            throw new NotImplementedException();
        }
    }
}
