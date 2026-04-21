using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Interfaces;
using AdminPanelLibrary.RepositoryInterfaces;

namespace AdminPanelLibrary.Entities
{
    public class AuthenticationService : IAuthentication
    {
        private readonly IUserRepository userRepo;

        public AuthenticationService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public bool IsUserActive(int userId)
        {
            var user = userRepo.GetById(userId);

            if (user == null) 
                return false;
            return user.IsActive;
        }

        public User? Login(string login, string password)
        {
            var user = userRepo.GetByLogin(login,password);

            if (user != null && user.IsActive == false)
            {
                userRepo.SetUserActive(user.UserId, true);
                return user;
            } 
                
            return null;
        }

        public void Logout(int userId)
        {
            userRepo.SetUserActive(userId, false);
        }
    }
}
