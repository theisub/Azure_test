using System;
namespace DSIP_.Models
{
    public class ItemsDatabaseSettings : IDatabaseSettings
    {
        public string DatabaseCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface IDatabaseSettings
    {
            string DatabaseCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
    }
}

