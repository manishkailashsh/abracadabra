using System.Data;
using System.Data.SqlClient;

namespace MigrationUtilities.Wrappers
{
    public class SqlDbConnectionWrapper : DbConnectionWrapper
    {
        public SqlDbConnectionWrapper(string connectionString) 
            : base(connectionString)
        {
        }

        protected override IDbConnection GetOpenConnection()
        {
            return  new SqlConnection(ConnectionString);
        }
    }
}