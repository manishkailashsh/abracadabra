namespace MigrationUtilities
{
    public interface IDbQueryProvider
    {
        string GetAllObjectsQuery { get; }
        string GetAllProceduresQuery { get; }
        string GetAllColumnsQuery { get; }
    }
}
