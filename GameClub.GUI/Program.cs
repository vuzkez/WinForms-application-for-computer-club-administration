using System.Configuration;
using GameClub.GUI.Presenters;
using GameClub.Library.Database;
using GameClub.Library.Entities;
using GameClub.Library.ServiceInterfaces;
using GameClub.Library.UnitOfWork;

namespace GameClub.GUI.Views
{
    internal static class Program
    {
        /// <summary>
        ///  Главная точка входа в программу
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var connectionStringSettings = ConfigurationManager.ConnectionStrings["SqlGameClubDb"];

            IDataConnection dataContextFactory = new ConnectionFactory(connectionStringSettings.ConnectionString,connectionStringSettings.ProviderName);
            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory(dataContextFactory);

            IOperator operatorService = new OperatorService(unitOfWorkFactory);
            IAdministrator administratorService = new AdminService(unitOfWorkFactory);
            IAuthentication authenticationService = new AuthenticationService(unitOfWorkFactory);

            using (var loginForm = new LoginForm())
            {
                var loginPresenter = new LoginPresenter(loginForm, authenticationService);

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    User currentUser = loginForm.AuthenticatedUser;

                    var mainForm = new MainForm(currentUser, operatorService, administratorService, authenticationService);

                    var mainPresenter = new MainPresenter(mainForm, currentUser, operatorService, administratorService);

                    Application.Run(mainForm);
                }

            }
        }
    }
}