using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using MigrationUtilities;
using NUnit.Framework;

namespace MigrationUtilitiesTests
{
    [TestFixture]
    public class DbConnectionWrapperFixture
    {
        private const string ConnectionString = "Server=.;Database=AdventureWorks2017;Trusted_Connection=True;";
        private static DbConnectionWrapper _wrapper;

        [OneTimeSetUp]
        public void Initialize()
        {
            _wrapper = new SqlDbConnectionWrapper(ConnectionString);
        }

        [Test]
        public void TestTableNames()
        {
            var data = _wrapper.Execute(connection => connection.Query<DbObject>(sql: SqlQueries.AllObjectsQuery)).ToList();
        }
    }

    [TestFixture]
    public class OracleDbConnectionWrapperFixture
    {
        private const string ConnectionString =
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=TEST)));User Id=hr;Password=password;";
        private static DbConnectionWrapper _wrapper;

        [OneTimeSetUp]
        public void Initialize()
        {
            _wrapper = new OracleDbConnectionWrapper(ConnectionString);
        }

        [Test]
        public void TestTableNames()
        {
            var data = _wrapper.Execute(connection => connection.Query<DbObject>(sql: OracleQueries.AllObjectsQuery)).ToList();
        }

    }
}
