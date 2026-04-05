using System.Configuration;
using AdminPanelLibrary;

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

            string connectionString = ConfigurationManager.ConnectionStrings["GameClubDb"].ConnectionString;
            
            IDataContext dataContextFactory = DataContextSingleton.GetInstance(connectionString);
            IOperator operatorService = new Operator(dataContextFactory);
            IAdministrator administratorService = new Admin(dataContextFactory);

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