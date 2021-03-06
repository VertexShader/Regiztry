using System;
using System.Configuration;
using SisoDb;

namespace Regiztry
{
    public delegate T QueryDelegate<T>(Func<IQueryEngine, T> query);
    public delegate T GenericWorkOnDelegate<T>(Func<IUnitOfWork, T> work);
    public delegate void WorkOnDelegate(Action<IUnitOfWork> work);

    public class Regiztry {

        public static QueryDelegate<T> GetQueryDelegate<T>() {
            return new QueryDelegate<T>(Regiztry.QueryWith);
        }

        public static GenericWorkOnDelegate<T> GetGenericWorkOnDelegate<T>() {
            return new GenericWorkOnDelegate<T>(Regiztry.WorkOn);
        }

        public static WorkOnDelegate GetWorkOnDelegate() {
            return new WorkOnDelegate(Regiztry.WorkOn);
        }
        static ISisoDatabase database;
        
        public static T WorkOn<T>(Func<IUnitOfWork,T> work)
        {
            InitializeDatabase();
            using (var unitOfWork = database.CreateUnitOfWork())
                return work(unitOfWork);
        }

        public static void WorkOn(Action<IUnitOfWork> work)
        {
            InitializeDatabase();
            using (var unitOfWork = database.CreateUnitOfWork())
                work(unitOfWork);
        }

        public static T QueryWith<T>(Func<IQueryEngine,T> query)
        {
            InitializeDatabase();
            using (var q = database.CreateQueryEngine())
                return query(q);
        }

        static void InitializeDatabase()
        {
            if (database != null) return;
            var connectionString = ConfigurationManager.ConnectionStrings["default"];
            var connectionInfo =
                new SisoConnectionInfo(string.Format(@"sisodb:provider=Sql2008||plain:{0}", connectionString));
            var factory = new SisoDbFactory();
            database = factory.CreateDatabase(connectionInfo);
            database.CreateIfNotExists();
        }
    }
}