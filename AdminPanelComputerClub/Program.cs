using System.Configuration;
using AdminPanelLibrary;
using AdminPanelLibrary.Database;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Interfaces;
using AdminPanelLibrary.Repositories;
using LinqToDB;

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

            var sessionRepo = new SessionRepository(dataContextFactory);
            var seatRepo = new SeatRepository(dataContextFactory);
            var tariffRepo = new TariffSettingRepository(dataContextFactory);
            var userRepo = new UserRepository(dataContextFactory);

            IOperator operatorService = new OperatorService(sessionRepo, seatRepo, tariffRepo);
            IAdministrator administratorService = new AdminService(tariffRepo, sessionRepo);
            IAuthentication authenticationService = new AuthenticationService(userRepo);

            using (var loginForm = new LoginForm(authenticationService,userRepo))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    User currentUser = loginForm.CurrentUser;
                    Application.Run(new MainForm(currentUser,operatorService,administratorService,authenticationService,
                        seatRepo,sessionRepo,tariffRepo));
                }
            }
        }
    }
}