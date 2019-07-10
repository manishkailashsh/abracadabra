using MigrationUtilities;
using NUnit.Framework;

namespace MigrationUtilitiesTests
{
    [TestFixture]
    public abstract class RepositoryTestFixtureBase
    {
        protected abstract IDbObjectRepository InitializeRepository();
        private IDbObjectRepository Repository { get; set; }
        
        [OneTimeSetUp]
        public void Initialize()
        {
            Repository = InitializeRepository();
        }
        
        [Test]
        public void TestObjects()
        {
            var data = Repository.GetAllObjects();
        }

        [Test]
        public void TestColumns()
        {
            var data = Repository.GetAllColumns();
        }
    }
    
    [TestFixture]
    public class DbConnectionWrapperFixture : RepositoryTestFixtureBase
    {
        private static string ConnectionString => "Server=.;Database=AdventureWorks2017;Trusted_Connection=True;";

        protected override IDbObjectRepository InitializeRepository()
        {
            return new SqlDbObjectRepository(ConnectionString);
        }
    }

    [TestFixture]
    public class OracleDbConnectionWrapperFixture : RepositoryTestFixtureBase
    {
        private static string ConnectionString =>
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=TEST)));User Id=hr;Password=password;";

        protected override IDbObjectRepository InitializeRepository()
        {
            return new OracleDbObjectRepository(ConnectionString);
        }
    }
}
