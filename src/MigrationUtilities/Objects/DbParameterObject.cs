namespace MigrationUtilities.Objects
{
    public class DbParameterObject : DbObject
    {
        public string Direction { get; set; }

        public int Order => Id;
    }
}
