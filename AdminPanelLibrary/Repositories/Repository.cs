using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace AdminPanelLibrary.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDataConnection dataConnection;

        public Repository(IDataConnection dataConnection)
        {
            this.dataConnection = dataConnection;
        }

        public void Add(T entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Insert(entity);
            }
        }

        public void Delete(T entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Delete(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var db = dataConnection.Create())
            {
                return db.GetTable<T>().ToList();
            }
        }

        public void Update(T entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Update(entity);
            }
        }
    }
}
