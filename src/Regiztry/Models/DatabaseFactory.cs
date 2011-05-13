using System.Configuration;
using SisoDb;

namespace Regiztry.Models
{
    public class DatabaseFactory
    {
        ISisoDatabase database;

        public ISisoDatabase CreateDatabase()
        {
            if (database != null) return database;
            return database;
        }
    }
}