using MigrationUtilities.Queries;
using MigrationUtilities.Wrappers;

namespace MigrationUtilities.Repositories
{
    public class OracleDbObjectRepository : DbObjectRepository<OracleDbConnectionWrapper, OracleQueryProvider>
    {
        public OracleDbObjectRepository(string connectionString) 
            : base(new OracleDbConnectionWrapper(connectionString), new OracleQueryProvider())
        {
        }
    }
}