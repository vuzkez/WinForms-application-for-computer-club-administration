using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Entities;

namespace AdminPanelLibrary.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByLoginAsync(string login, string password);
        Task SetUserActiveAsync(int userId, bool isActive);
    }
}
