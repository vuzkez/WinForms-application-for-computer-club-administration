using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Library.Database;
using GameClub.Library.Interfaces;
using GameClub.Library.UnitOfWork;

namespace GameClub.Library.Entities
{
    public class AuthenticationService : IAuthentication
    {
        private readonly IUnitOfWorkFactory uowFactory;

        public AuthenticationService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }
        public async Task<User?> LoginAsync(string login, string password)
        {
            using (var uow = uowFactory.Create())
            {
                var user = await uow.Users.GetByLoginAsync(login, password);

                if (user != null)
                {
                    return user;
                }
                return null;
            }
        }
    }
}
