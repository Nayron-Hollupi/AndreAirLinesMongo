namespace FlightsAPI.Utils
{
    public class VooUtilsDatabaseSettings :IVooUtilsDatabaseSettings
    {
        public string VooCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
