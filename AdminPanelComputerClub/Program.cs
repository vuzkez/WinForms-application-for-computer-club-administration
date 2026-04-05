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

            string connectionString = "Data Source=VUZKEZ\\SQLEXPRESS;Initial Catalog=GameClub;Integrated Security=True;TrustServerCertificate=True";
            
            IDataContext dataContextFactory = DataContextSingleton.GetInstance(connectionString);
            IOperator operatorService = new Operator(dataContextFactory);
            IAdministrator administratorService = new Admin(dataContextFactory);

            using (var loginForm = new LoginForm(dataContextFactory))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // ѕолучаем авторизованного пользовател€
                    User currentUser = loginForm.CurrentUser;

                    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
                    // «апускаем главную форму, передава€ ей пользовател€ и сервисы
                    Application.Run(new MainForm(currentUser,operatorService,administratorService,dataContextFactory));
                }
            }
        }
    }
}