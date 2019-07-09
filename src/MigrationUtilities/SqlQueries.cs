namespace MigrationUtilities
{
    public class SqlQueryProvider : IDbQueryProvider
    {
        private static readonly string AllObjectsQuery =
            @"SELECT name as Name, 
                object_id as Id, 
                parent_object_id as ParentId, 
                type_desc AS Type 
              FROM sys.all_objects 
              WHERE is_ms_shipped = 0
              ORDER BY object_id";

        private static readonly string AllColumnsQuery =
            @"SELECT                 
                C.name AS Name,
                C.column_id AS Id,
                C.object_id AS ParentId,
                T.name AS Type,
                C.max_length AS MaxLength,
                C.precision as Precision,
                C.is_nullable AS IsNullable,
                C.is_computed AS IsComputed
                FROM sys.all_columns AS C
                JOIN sys.types as T ON C.user_type_id = T.user_type_id
                JOIN sys.tables AS ST ON ST.object_id = C.object_id
                WHERE ST.is_ms_shipped = 0;";

        private static readonly string AllProceduresQuery =
            @"SELECT                 
                C.name AS Name,
                C.column_id AS Id,
                C.object_id AS ParentId,
                T.name AS Type,
                C.max_length AS MaxLength,
                C.precision as Precision,
                C.is_nullable AS IsNullable,
                C.is_computed AS IsComputed
                FROM sys.all_columns AS C
                JOIN sys.types as T ON C.user_type_id = T.user_type_id
                JOIN sys.tables AS ST ON ST.object_id = C.object_id
                WHERE ST.is_ms_shipped = 0;";


        public string GetAllObjectsQuery => AllObjectsQuery;
        public string GetAllProceduresQuery => AllProceduresQuery;
        public string GetAllColumnsQuery => AllColumnsQuery;
    }
}
