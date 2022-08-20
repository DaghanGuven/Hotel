using System.Data.SqlClient;

namespace Güven_otel
{
    class Sql
    {
        public static SqlConnection con = new SqlConnection(); // Data source here
        public static SqlDataReader reader;
        public static SqlCommand cmd;
    }
}
