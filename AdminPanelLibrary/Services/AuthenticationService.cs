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
        public async Task<User?> LoginAsync(string login, string password)
        {
            using (var uow = new UnitOfWorkLinq2db(dataConnection))
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
