namespace RandomAteDataManager.Models
{
    /// <summary>
    /// Database settings storage class
    /// </summary>
    public class RandomAteDatabaseSettings : IRandomAteDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string DishesCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
    }

    public interface IRandomAteDatabaseSettings
    {
        string DatabaseName { get; set; }
        string DishesCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }

    }
}