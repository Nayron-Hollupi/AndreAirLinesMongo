namespace FlightsAPI.Utils
{
    public interface IVooUtilsDatabaseSettings
    {
        string VooCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
