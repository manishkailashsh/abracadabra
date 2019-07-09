using MigrationUtilities;
using NUnit.Framework;

namespace MigrationUtilitiesTests
{
    [TestFixture]
    public class DbConnectionWrapperFixture
    {
        private const string ConnectionString = "Server=.;Database=AdventureWorks2017;Trusted_Connection=True;";
        private static DbConnectionWrapper _wrapper;
        private static IDbQueryProvider _queryProvider;
        private static DbObjectRepository _repository;

        [OneTimeSetUp]
        public void Initialize()
        {
            _wrapper = new SqlDbConnectionWrapper(ConnectionString);
            _queryProvider = new SqlQueryProvider();
            _repository = new DbObjectRepository(_wrapper, _queryProvider);
        }

        [Test]
        public void TestObjects()
        {
            var data = _repository.GetAllObjects();
        }

        [Test]
        public void TestColumns()
        {
            var data = _repository.GetAllColumns();
        }
    }

    [TestFixture]
    public class OracleDbConnectionWrapperFixture
    {
        private const string ConnectionString =
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=TEST)));User Id=hr;Password=password;";
        private static DbConnectionWrapper _wrapper;
        private static IDbQueryProvider _queryProvider;
        private static DbObjectRepository _repository;

        [OneTimeSetUp]
        public void Initialize()
        {
            _wrapper = new OracleDbConnectionWrapper(ConnectionString);
            _queryProvider = new OracleQueryProvider();
            _repository = new DbObjectRepository(_wrapper, _queryProvider);
        }

        [Test]
        public void TestObjects()
        {
            var data = _repository.GetAllObjects();
        }

        [Test]
        public void TestColumns()
        {
            var data = _repository.GetAllColumns();
        }

    }
}
