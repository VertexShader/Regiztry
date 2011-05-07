using System;
using System.Collections.Generic;
using System.Web.Configuration;
using SisoDb;
using Web.Models;

namespace Web.Codez
{
    public class StartupRepository : BaseRepository<Startup>
    {

        public void UpdateStartup(Startup updatedStartup)
        {
            Update(updatedStartup);
        }

        public Startup GetStartupById(int id)
        {
            return GetById(id);
        }

        public IEnumerable<Startup> GetAllStartups()
        {
            return GetAll();
        }


        public new void Post(Startup startup)
        {
            Post(startup);
        }
    }

    public abstract class BaseRepository<T>
        where T : class
    {
        
        private readonly ISisoDatabase _database;

        protected BaseRepository() {
            string connectionString = WebConfigurationManager.ConnectionStrings["default"].ConnectionString;
            var connectionInfo = new SisoConnectionInfo(string.Format(@"sisodb:provider=Sql2008||plain:{0}", connectionString));
            var factory = new SisoDbFactory();
            _database = factory.CreateDatabase(connectionInfo);
            _database.CreateIfNotExists();
        }

        public T GetById(int id)
        {
            VerifyDatabaseInitialized();
            var queryEngine = _database.CreateQueryEngine();
            T entity = queryEngine.GetById<T>(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            VerifyDatabaseInitialized();
            var queryEngine = _database.CreateQueryEngine();
            IEnumerable<T> entities = queryEngine.GetAll<T>();
            return entities;
        }



        public void Update(T entity)
        {
            VerifyDatabaseInitialized();
            using (IUnitOfWork unitOfWork = _database.CreateUnitOfWork())
            {
                unitOfWork.Update(entity);
                unitOfWork.Commit();
            }
        }


        public void Post(T entity)
        {
            VerifyDatabaseInitialized();
            using (var session = _database.CreateUnitOfWork())
            {
                session.Insert(entity);
                session.Commit();
            }
        }

        public void Delete(int id)
        {
            VerifyDatabaseInitialized();
            using (IUnitOfWork unitOfWork = _database.CreateUnitOfWork())
            {
                unitOfWork.DeleteById<T>(id);
                unitOfWork.Commit();
            }
        }

        private void VerifyDatabaseInitialized()
        {
            if (_database == null || !_database.Exists())
            {
                throw new InvalidOperationException("Database is not initialized.  That makes me a sad panda.");
            }
        }
        
    }
   
}