using GameClub.BusinessLogic.ServiceInterfaces;
using GameClub.DataAccess.UnitOfWork;
using GameClub.Domain.Entities;

namespace GameClub.BusinessLogic.Services
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

