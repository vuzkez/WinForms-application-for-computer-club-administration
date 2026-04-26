using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Database;
using AdminPanelLibrary.Interfaces;
using AdminPanelLibrary.UnitOfWork;

namespace AdminPanelLibrary.Entities
{
    public class AuthenticationService : IAuthentication
    {
        private readonly IDataConnection dataConnection;

        public AuthenticationService(IDataConnection dataConnection)
        {
            this.dataConnection = dataConnection;
        }
        public async Task<bool> IsUserActiveAsync(int userId)
        {
            using (var uow = new UnitOfWorkLinq2db(dataConnection))
            {
                var user = await uow.Users.GetByIdAsync(userId);

                if (user == null)
                    return false;
                return user.IsActive;
            }
        }

        public async Task<User?> LoginAsync(string login, string password)
        {
            using (var uow = new UnitOfWorkLinq2db(dataConnection))
            {
                var user = await uow.Users.GetByLoginAsync(login, password);

                if (user != null && user.IsActive == false)
                {
                    uow.BeginTransaction();
                    try
                    {
                        await uow.Users.SetUserActiveAsync(user.UserId, true);
                        uow.Commit();
                    }
                    catch 
                    { 
                        uow.RollBack();
                        throw;
                    }
                    return user;
                }

                return null;
            }
        }

        public async Task LogoutAsync(int userId)
        {
            using (var uow = new UnitOfWorkLinq2db(dataConnection))
            {
                uow.BeginTransaction();
                try
                {
                    await uow.Users.SetUserActiveAsync(userId, false);
                    uow.Commit();
                }
                catch
                {
                    uow.RollBack();
                    throw;
                }
            }
        }
    }
}
