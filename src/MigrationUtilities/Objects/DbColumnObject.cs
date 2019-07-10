namespace MigrationUtilities.Objects
{
    public class DbColumnObject : DbObject
    {
        public int Order => Id;
        public int MaxLength { get; set; }
        public int Precision { get; set; }
        public bool IsNullable { get; set; }
        public bool IsComputed { get; set; }
    }
}