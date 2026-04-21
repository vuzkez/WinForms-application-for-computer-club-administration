using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Database;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.RepositoryInterfaces;
using LinqToDB;

namespace AdminPanelLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataConnection dataConnection;

        public UserRepository(IDataConnection dataConnection)
        {
            this.dataConnection = dataConnection;
        }

        public void Add(User entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Insert(entity);
            }
        }

        public void Update(User entity)
        {
            using (var db = dataConnection.Create())
            {
                db.Update(entity);
            }
        }

        public void Delete(int id)
        {
            using (var db = dataConnection.Create())
            {
                var user = db.GetTable<User>().FirstOrDefault(u => u.UserId == id);
                if (user != null)
                    db.Delete(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var db = dataConnection.Create())
            {
                return db.GetTable<User>().ToList();
            }
        }

        public User? GetById(int id)
        {
            using (var db = dataConnection.Create())
            {
                return db.GetTable<User>().FirstOrDefault(u => u.UserId == id);
            }
        }

        public User? GetByLogin(string login, string password)
        {
            using (var db = dataConnection.Create())
            {
                return db.GetTable<User>()
                    .FirstOrDefault(u => u.Login == login && u.Password == password);
            }
        }

        public void SetUserActive(int userId, bool isActive)
        {
            using (var db = dataConnection.Create())
            {
                var user = db.GetTable<User>().FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    user.IsActive = isActive;
                    db.Update(user);
                }
            }
        }
    }
}
