namespace MigrationUtilities
{
    public class DbObject
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Type { get; set; }
    }

    public class DbColumnObject : DbObject
    {
        public int MaxLength { get; set; }
        public int Precision { get; set; }
        public bool IsNullable { get; set; }
        public bool IsComputed { get; set; }
    }
}
