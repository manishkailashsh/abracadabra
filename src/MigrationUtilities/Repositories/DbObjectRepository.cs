using System.Collections.Generic;
using System.Linq;
using Dapper;
using MigrationUtilities.Objects;
using MigrationUtilities.Queries;
using MigrationUtilities.Wrappers;

namespace MigrationUtilities.Repositories
{
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

        public virtual List<DbObject> GetAllObjects()
        {
            return _dbObjectCache ?? (_dbObjectCache = _wrapper
                       .Execute(connection => connection.Query<DbObject>(sql: _queryProvider.GetAllObjectsQuery))
                       .ToList());
        }

        public virtual List<DbColumnObject> GetAllColumns()
        {
            return _dbColumnCache ?? (_dbColumnCache = _wrapper
                       .Execute(connection => connection.Query<DbColumnObject>(sql: _queryProvider.GetAllColumnsQuery))
                       .ToList());
        }

        public virtual void RefreshAll()
        {
            _dbObjectCache = null;
            _dbColumnCache = null;
        }
    }
}
