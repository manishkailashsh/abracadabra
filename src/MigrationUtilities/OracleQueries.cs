using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationUtilities
{
    public static class OracleQueries
    {
        public static readonly string AllObjectsQuery = @"SELECT 
                                                        OBJECT_NAME Name, 
                                                        OBJECT_ID Id, 
                                                        DATA_OBJECT_ID ParentId, 
                                                        OBJECT_TYPE Type 
                                                        FROM ALL_OBJECTS 
                                                        WHERE ORACLE_MAINTAINED = 'N'
                                                        ORDER BY OBJECT_ID";
    }
}
