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
                    .FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user != null && user.IsActive == false)
                {
                    user.IsActive = true;
                    CurrentUser = user;
                    DialogResult = DialogResult.OK;
                    db.SubmitChanges();
                    Close();
                }
                else if (user != null && user.IsActive == true)
                {
                    MessageBox.Show("Пользователь уже активен.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
