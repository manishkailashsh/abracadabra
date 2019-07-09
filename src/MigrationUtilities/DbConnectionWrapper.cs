using System;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace MigrationUtilities
{
    public abstract class DbConnectionWrapper
    {
        protected DbConnectionWrapper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected string ConnectionString { get; }

        protected abstract IDbConnection GetOpenConnection();

        public virtual TResult Execute<TResult>(Func<IDbConnection, TResult> func)
        {
            using (var connection = GetOpenConnection())
            {
                return func(connection);
            }
        }
    }

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
