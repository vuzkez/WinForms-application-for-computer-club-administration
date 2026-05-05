using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Library.Entities;

namespace GameClub.Library.ServiceInterfaces
{
    public interface IAuthentication
    {
        Task<User?> LoginAsync(string login, string password);
    }
}
