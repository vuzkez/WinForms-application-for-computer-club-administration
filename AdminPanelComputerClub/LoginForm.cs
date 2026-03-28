using AdminPanelLibrary;
using System.ComponentModel;

namespace AdminPanelComputerClub
{
    public partial class LoginForm : Form
    {
        private readonly IDataContext context;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public User CurrentUser { get; private set; }
        public LoginForm(IDataContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;  
            string password = txtPassword.Text;

            using (var db = context.Create())
            {
                var user = db.GetTable<User>()
                    .FirstOrDefault(u => u.Login == login && u.Password == password && u.IsActive);

                if (user != null)
                {
                    CurrentUser = user;        
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
