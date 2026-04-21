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
        User? GetById(int id);
        User? GetByLogin(string login, string password);
        void SetUserActive(int userId, bool isActive);
    }
}
