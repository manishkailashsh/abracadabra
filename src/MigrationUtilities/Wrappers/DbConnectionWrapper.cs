using System;
using System.Data;

namespace MigrationUtilities.Wrappers
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
}
