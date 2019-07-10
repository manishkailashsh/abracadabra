using System.Collections.Generic;
using MigrationUtilities.Objects;

namespace MigrationUtilities.Repositories
{
    public interface IDbObjectRepository
    {
        List<DbObject> GetAllObjects();

        List<DbColumnObject> GetAllColumns();

        void RefreshAll();
    }
}