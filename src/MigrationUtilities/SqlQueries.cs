using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationUtilities
{
    public static class SqlQueries
    {
        public static readonly string GetTableNames = @"SELECT name
						                                FROM dbo.sysobjects
						                                WHERE xtype = 'U' 
						                                AND name <> 'sysdiagrams'
						                                order by name asc";

        public static readonly string GetTableInfo = @"SELECT
	                                                        c.TABLE_CATALOG AS [TableCatalog]
                                                        ,	c.TABLE_SCHEMA AS [Schema]
                                                        ,	c.TABLE_NAME AS [TableName]
                                                        ,	c.COLUMN_NAME AS [ColumnName]
                                                        ,	c.ORDINAL_POSITION AS [OrdinalPosition]
                                                        ,	c.COLUMN_DEFAULT AS [ColumnDefault]
                                                        ,	c.IS_NULLABLE AS [Nullable]
                                                        ,	c.DATA_TYPE AS [DataType]
                                                        ,	c.CHARACTER_MAXIMUM_LENGTH AS [CharacterMaxLength]
                                                        ,	c.CHARACTER_OCTET_LENGTH AS [CharacterOctetLenth]
                                                        ,	c.NUMERIC_PRECISION AS [NumericPrecision]
                                                        ,	c.NUMERIC_PRECISION_RADIX AS [NumericPrecisionRadix]
                                                        ,	c.NUMERIC_SCALE AS [NumericScale]
                                                        ,	c.DATETIME_PRECISION AS [DatTimePrecision]
                                                        ,	c.CHARACTER_SET_CATALOG AS [CharacterSetCatalog]
                                                        ,	c.CHARACTER_SET_SCHEMA AS [CharacterSetSchema]
                                                        ,	c.CHARACTER_SET_NAME AS [CharacterSetName]
                                                        ,	c.COLLATION_CATALOG AS [CollationCatalog]
                                                        ,	c.COLLATION_SCHEMA AS [CollationSchema]
                                                        ,	c.COLLATION_NAME AS [CollationName]
                                                        ,	c.DOMAIN_CATALOG AS [DomainCatalog]
                                                        ,	c.DOMAIN_SCHEMA AS [DomainSchema]
                                                        ,	c.DOMAIN_NAME AS [DomainName]
                                                        ,	IsPrimaryKey = CONVERT(BIT, (SELECT
			                                                        COUNT(*)
		                                                        FROM	INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
			                                                        ,	INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE cu
		                                                        WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
		                                                        AND tc.CONSTRAINT_NAME = cu.CONSTRAINT_NAME
		                                                        AND tc.TABLE_NAME = c.TABLE_NAME
		                                                        AND cu.TABLE_SCHEMA = c.TABLE_SCHEMA
		                                                        AND cu.COLUMN_NAME = c.COLUMN_NAME)
	                                                        )
                                                        ,	IsIdentity = CONVERT(BIT, (SELECT
			                                                        col.is_identity
		                                                        FROM sys.objects obj
		                                                        INNER JOIN sys.COLUMNS col
			                                                        ON obj.object_id = col.object_id
		                                                        WHERE obj.type = 'U'
		                                                        AND obj.Name = c.TABLE_NAME
		                                                        AND col.Name = c.COLUMN_NAME)
	                                                        )
                                                        FROM INFORMATION_SCHEMA.COLUMNS c
                                                        WHERE (@Schema IS NULL
		                                                        OR c.TABLE_SCHEMA = @Schema)
	                                                        AND (@TableName IS NULL
		                                                        OR c.TABLE_NAME = @TableName)
                                                            ";

        public static readonly string GetPrimaryKeyColumnName = @"SELECT
	                                                                B.COLUMN_NAME
                                                                FROM	INFORMATION_SCHEMA.TABLE_CONSTRAINTS A
	                                                                ,	INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE B
                                                                WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
	                                                                AND A.CONSTRAINT_NAME = B.CONSTRAINT_NAME
	                                                                AND A.TABLE_NAME = @TableName
	                                                                AND A.TABLE_SCHEMA = @Schema";

        public static readonly string GetIdentityColumnName = @"SELECT
	                                                                c.Name
                                                                FROM sys.objects o
                                                                INNER JOIN sys.columns c ON o.object_id = c.object_id
                                                                WHERE o.type = 'U'
	                                                                AND c.is_identity = 1
	                                                                AND o.Name = @TableName";

        public static readonly string GetStoredProcedureInfo = @"SELECT
	                                                                SPECIFIC_NAME AS [Name]
                                                                ,	SPECIFIC_SCHEMA AS [Schema]
                                                                ,	Created AS [Created]
                                                                ,	LAST_ALTERED AS [LastAltered]
                                                                FROM INFORMATION_SCHEMA.ROUTINES
                                                                WHERE ROUTINE_TYPE = 'PROCEDURE'
	                                                                AND (SPECIFIC_SCHEMA = @Schema
		                                                                OR @Schema IS NULL)
	                                                                AND (SPECIFIC_NAME = @ProcName
		                                                                OR @ProcName IS NULL)
	                                                                AND ((SPECIFIC_NAME NOT LIKE 'sp_%'
			                                                                AND SPECIFIC_NAME NOT LIKE 'procUtils_GenerateClass'
			                                                                AND (SPECIFIC_SCHEMA = @Schema
				                                                                OR @Schema IS NULL))
		                                                                OR SPECIFIC_SCHEMA <> @Schema)";


        public static string GetStoredProcedureInputParameters = @"SELECT
	                                                                SCHEMA_NAME(schema_id) AS [Schema]
                                                                ,	P.Name AS Name
                                                                ,	@ProcName AS ProcedureName
                                                                ,	TYPE_NAME(P.user_type_id) AS [ParameterDataType]
                                                                ,	P.max_length AS [MaxLength]
                                                                ,	P.Precision AS [Precision]
                                                                ,	P.Scale AS Scale
                                                                ,	P.has_default_value AS HasDefaultValue
                                                                ,	P.default_value AS DefaultValue
                                                                ,	P.object_id AS ObjectId
                                                                ,	P.parameter_id AS ParameterId
                                                                ,	P.system_type_id AS SystemTypeId
                                                                ,	P.user_type_id AS UserTypeId
                                                                ,	P.is_output AS IsOutput
                                                                ,	P.is_cursor_ref AS IsCursor
                                                                ,	P.is_xml_document AS IsXmlDocument
                                                                ,	P.xml_collection_id AS XmlCollectionId
                                                                ,	P.is_readonly AS IsReadOnly
                                                                FROM sys.objects AS SO
                                                                INNER JOIN sys.parameters AS P ON SO.object_id = P.object_id
                                                                WHERE SO.object_id IN (SELECT
			                                                                object_id
		                                                                FROM sys.objects
		                                                                WHERE type IN ('P', 'FN'))
	                                                                AND (SO.Name = @ProcName
		                                                                OR @ProcName IS NULL)
	                                                                AND (SCHEMA_NAME(schema_id) = @Schema
		                                                                OR @Schema IS NULL)
                                                                ORDER BY P.parameter_id ASC";


        public static readonly string AllObjectsQuery =
            @"SELECT name as Name, 
                object_id as Id, 
                parent_object_id as ParentId, 
                type_desc AS Type 
              FROM sys.all_objects 
              WHERE is_ms_shipped = 0
              ORDER BY object_id";


    }
}
