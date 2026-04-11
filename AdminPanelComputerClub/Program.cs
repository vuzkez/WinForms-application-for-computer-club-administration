using System.Configuration;
using AdminPanelLibrary;
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

            IDataConnection dataContextFactory = ConnectionFactory
                .GetInstance(connectionStringSettings.ConnectionString,connectionStringSettings.ProviderName);

            var sessionRepo = new SessionRepository(dataContextFactory);
            var seatRepo = new SeatRepository(dataContextFactory);
            var tariffRepo = new TariffSettingRepository(dataContextFactory);

            IOperator operatorService = new Operator(sessionRepo, seatRepo, tariffRepo);
            IAdministrator administratorService = new Admin(tariffRepo, sessionRepo);

            using (var loginForm = new LoginForm(dataContextFactory))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    User currentUser = loginForm.CurrentUser;
                    Application.Run(new MainForm(currentUser,operatorService,administratorService,dataContextFactory));
                }
            }
        }
    }
}