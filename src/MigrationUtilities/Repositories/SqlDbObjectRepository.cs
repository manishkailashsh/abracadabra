using MigrationUtilities.Queries;
using MigrationUtilities.Wrappers;

namespace MigrationUtilities.Repositories
{
    public class SqlDbObjectRepository : DbObjectRepository<SqlDbConnectionWrapper, SqlQueryProvider>
    {
        public SqlDbObjectRepository(string connectionString)
            : base(new SqlDbConnectionWrapper(connectionString), new SqlQueryProvider())
        {
        }
    }
}