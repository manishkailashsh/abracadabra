using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace MigrationUtilities
{
    public interface IDbObjectRepository
    {
        List<DbObject> GetAllObjects();

        List<DbColumnObject> GetAllColumns();

        void RefreshAll();
    }
    
    public class DbObjectRepository<TWrapper, TQueryProvider> : IDbObjectRepository
        where TWrapper: DbConnectionWrapper
        where TQueryProvider: IDbQueryProvider
    {
        private readonly TWrapper _wrapper;
        private readonly TQueryProvider _queryProvider;

        private List<DbObject> _dbObjectCache;
        private List<DbColumnObject> _dbColumnCache;

        protected DbObjectRepository(TWrapper wrapper, TQueryProvider queryProvider)
        {
            _wrapper = wrapper;
            _queryProvider = queryProvider;
        }

        public List<DbObject> GetAllObjects()
        {
            return _dbObjectCache ?? (_dbObjectCache = _wrapper
                       .Execute(connection => connection.Query<DbObject>(sql: _queryProvider.GetAllObjectsQuery))
                       .ToList());
        }

        public List<DbColumnObject> GetAllColumns()
        {
            return _dbColumnCache ?? (_dbColumnCache = _wrapper
                       .Execute(connection => connection.Query<DbColumnObject>(sql: _queryProvider.GetAllColumnsQuery))
                       .ToList());
        }

        public void RefreshAll()
        {
            _dbObjectCache = null;
            _dbColumnCache = null;
        }
    }

    public class OracleDbObjectRepository : DbObjectRepository<OracleDbConnectionWrapper, OracleQueryProvider>
    {
        public OracleDbObjectRepository(string connectionString) 
            : base(new OracleDbConnectionWrapper(connectionString), new OracleQueryProvider())
        {
        }
    }

    public class SqlDbObjectRepository : DbObjectRepository<SqlDbConnectionWrapper, SqlQueryProvider>
    {
    public SqlDbObjectRepository(string connectionString)
        : base(new SqlDbConnectionWrapper(connectionString), new SqlQueryProvider())
    {
    }
    }
}
