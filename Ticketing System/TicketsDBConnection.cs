using System.Configuration;
using System.Data.SqlClient;

namespace Ticketing_System
{

    public class TicketsDBConnection : ITicketsDBConnection
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Tickets"].ConnectionString;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
