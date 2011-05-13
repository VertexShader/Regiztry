using System.Configuration;
using SisoDb;

namespace Regiztry
{
    public class Regiztry
    {
        static ISisoDatabase database;

        public static IUnitOfWork UnitOfWork()
        {
            if (database == null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["regiztry"];
                var connectionInfo =
                    new SisoConnectionInfo(string.Format(@"sisodb:provider=Sql2008||plain:{0}", connectionString));
                var factory = new SisoDbFactory();
                database = factory.CreateDatabase(connectionInfo);
                database.CreateIfNotExists();
            }
            return database.CreateUnitOfWork();
        }
    }
}