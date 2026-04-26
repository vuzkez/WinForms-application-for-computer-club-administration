using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Database;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.RepositoryInterfaces;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace AdminPanelLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataConnection db;

        public UserRepository(DataConnection connection)
        {
            db = connection;
        }

        public async Task AddAsync(User entity)
        {
            await db.InsertAsync(entity);
        }

        public async Task UpdateAsync(User entity)
        {
            await db.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await db.GetTable<User>().FirstOrDefaultAsync(u => u.UserId == id);
            if (user != null)
                await db.DeleteAsync(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await db.GetTable<User>().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await db.GetTable<User>().FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User?> GetByLoginAsync(string login, string password)
        {
            return await db.GetTable<User>()
                .FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }

        public async Task SetUserActiveAsync(int userId, bool isActive)
        {
            var user = await db.GetTable<User>().FirstOrDefaultAsync(u => u.UserId == userId);
            if (user != null)
            {
                user.IsActive = isActive;
                await db.UpdateAsync(user);
            }
        }
    }
}
