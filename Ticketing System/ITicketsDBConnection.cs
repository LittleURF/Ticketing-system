using System.Data.SqlClient;

namespace Ticketing_System
{
    public interface ITicketsDBConnection
    {
        SqlConnection GetConnection();
    }
}
