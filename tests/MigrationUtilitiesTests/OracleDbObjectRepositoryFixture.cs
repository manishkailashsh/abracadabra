using MigrationUtilities.Repositories;
using NUnit.Framework;

namespace MigrationUtilitiesTests
{
    [TestFixture]
    public class OracleDbObjectRepositoryFixture : RepositoryTestFixtureBase
    {
        private static string ConnectionString =>
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=TEST)));User Id=hr;Password=password;";

        protected override IDbObjectRepository InitializeRepository()
        {
            return new OracleDbObjectRepository(ConnectionString);
        }
    }
}