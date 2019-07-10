using MigrationUtilities.Repositories;
using NUnit.Framework;

namespace MigrationUtilitiesTests
{
    [TestFixture]
    public class SqlDbObjectRepositoryFixture : RepositoryTestFixtureBase
    {
        private static string ConnectionString => "Server=.;Database=AdventureWorks2017;Trusted_Connection=True;";

        protected override IDbObjectRepository InitializeRepository()
        {
            return new SqlDbObjectRepository(ConnectionString);
        }
    }
}