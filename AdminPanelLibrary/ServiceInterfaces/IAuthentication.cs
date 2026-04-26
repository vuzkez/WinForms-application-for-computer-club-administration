using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Entities;

namespace AdminPanelLibrary.Interfaces
{
    public interface IAuthentication
    {
        Task<User?> LoginAsync(string login, string password);
        Task LogoutAsync(int userId);
        Task<bool> IsUserActiveAsync(int userId);
    }
}
