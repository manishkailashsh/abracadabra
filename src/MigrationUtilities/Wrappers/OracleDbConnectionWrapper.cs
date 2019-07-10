using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace MigrationUtilities.Wrappers
{
    public class OracleDbConnectionWrapper : DbConnectionWrapper
    {
        public OracleDbConnectionWrapper(string connectionString) 
            : base(connectionString)
        {
        }

        protected override IDbConnection GetOpenConnection()
        {
            return  new OracleConnection(ConnectionString);
        }
    }
}