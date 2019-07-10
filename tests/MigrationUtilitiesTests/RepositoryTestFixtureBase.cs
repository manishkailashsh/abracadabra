using MigrationUtilities.Repositories;
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
            Assert.IsNotNull(data);
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void TestColumns()
        {
            var data = Repository.GetAllColumns();
            Assert.IsNotNull(data);
            Assert.IsNotEmpty(data);
        }
    }
}
