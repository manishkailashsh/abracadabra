namespace MigrationUtilities
{
    public class OracleQueryProvider : IDbQueryProvider
    {
        private static readonly string AllObjectsQuery = @"SELECT 
                                                        OBJECT_NAME Name, 
                                                        OBJECT_ID Id, 
                                                        DATA_OBJECT_ID ParentId, 
                                                        OBJECT_TYPE Type 
                                                        FROM ALL_OBJECTS 
                                                        WHERE ORACLE_MAINTAINED = 'N'
                                                        ORDER BY OBJECT_ID";

        private static readonly string AllColumnsQuery = @"SELECT
                                                        C.COLUMN_NAME Name,
                                                        C.COLUMN_ID Id, 
                                                        T.OBJECT_ID ParentId,
                                                        C.DATA_TYPE Type,
                                                        C.DATA_LENGTH MaxLength,
                                                        C.DATA_PRECISION Precision,
                                                        CASE(C.NULLABLE) WHEN 'Y' THEN 1 ELSE 0 END IsNullable
                                                        FROM ALL_TAB_COLUMNS C 
                                                        JOIN ALL_OBJECTS T 
                                                        ON C.OWNER = T.OWNER AND C.TABLE_NAME = T.OBJECT_NAME
                                                        WHERE T.ORACLE_MAINTAINED = 'N'";

        public string GetAllObjectsQuery => AllObjectsQuery;
        public string GetAllProceduresQuery => AllColumnsQuery;
        public string GetAllColumnsQuery => AllColumnsQuery;
    }
}
