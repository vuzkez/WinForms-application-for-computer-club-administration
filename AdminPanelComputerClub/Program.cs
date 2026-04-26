using System.Configuration;
using AdminPanelLibrary;
using AdminPanelLibrary.Database;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Interfaces;
using AdminPanelLibrary.Repositories;

namespace AdminPanelComputerClub
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var connectionStringSettings = ConfigurationManager.ConnectionStrings["SqlGameClubDb"];

            IDataConnection dataContextFactory = new ConnectionFactory(connectionStringSettings.ConnectionString,connectionStringSettings.ProviderName);

            IOperator operatorService = new OperatorService(dataContextFactory);
            IAdministrator administratorService = new AdminService(dataContextFactory);
            IAuthentication authenticationService = new AuthenticationService(dataContextFactory);

            using (var loginForm = new LoginForm(authenticationService))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    User currentUser = loginForm.CurrentUser;
                    Application.Run(new MainForm(currentUser,operatorService,administratorService,authenticationService));
                }
            }
        }
    }
}