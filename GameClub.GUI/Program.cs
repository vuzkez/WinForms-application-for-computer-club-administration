using System.Configuration;
using GameClub.GUI.Presenters;
using GameClub.GUI.ViewInterfaces;
using GameClub.BusinessLogic.ServiceInterfaces;
using GameClub.BusinessLogic.Services;
using GameClub.DataAccess.Database;
using GameClub.DataAccess.UnitOfWork;

namespace GameClub.GUI.Views
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var connectionStringSettings = ConfigurationManager.ConnectionStrings["SqlGameClubDb"];

            IDataConnection dataContextFactory = new ConnectionFactory(
                connectionStringSettings.ConnectionString,
                connectionStringSettings.ProviderName);
            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory(dataContextFactory);

            IOperator operatorService = new OperatorService(unitOfWorkFactory);
            IAdministrator administratorService = new AdminService(unitOfWorkFactory);
            IAuthentication authenticationService = new AuthenticationService(unitOfWorkFactory);

            using (var loginForm = new LoginForm())
            {
                var loginPresenter = new LoginPresenter(loginForm, authenticationService);

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    var currentUser = loginForm.AuthenticatedUser;

                    using (var mainForm = new MainForm())
                    {
                        var mainPresenter = new MainPresenter(
                            mainForm,
                            currentUser,
                            operatorService,
                            administratorService);

                        Application.Run(mainForm);
                    }
                }
            }
        }
    }
}