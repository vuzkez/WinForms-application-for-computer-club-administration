using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Domain.Entities;

namespace GameClub.BusinessLogic.ServiceInterfaces
{
    public interface IAuthentication
    {
        Task<User?> LoginAsync(string login, string password);
    }
}

