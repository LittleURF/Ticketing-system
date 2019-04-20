using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Ticketing_System
{
    public class TicketsDB
    {
        private readonly SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Tickets"].ConnectionString);

    }
}
