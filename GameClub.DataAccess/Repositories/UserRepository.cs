using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Domain.Entities;
using GameClub.DataAccess.RepositoryInterfaces;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace GameClub.DataAccess.Repositories
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
        public async Task<bool> IsLoginExistsAsync(string login)
        {
            return await db.GetTable<User>().AnyAsync(u => u.Login == login);
        }
    }
}

