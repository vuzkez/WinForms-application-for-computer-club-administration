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
        User? Login(string login, string password);
        void Logout(int userId);
        bool IsUserActive(int userId);
    }
}
