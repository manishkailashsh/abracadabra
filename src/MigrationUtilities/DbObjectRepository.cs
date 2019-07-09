using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace MigrationUtilities
{
    public class DbObjectRepository
    {
        private readonly DbConnectionWrapper _wrapper;
        private readonly IDbQueryProvider _queryProvider;

        private List<DbObject> _dbObjectCache;
        private List<DbColumnObject> _dbColumnCache;

        public DbObjectRepository(DbConnectionWrapper wrapper, IDbQueryProvider queryProvider)
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
}
