using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Repositories;
using LinqToDB;

namespace AdminPanelComputerClub
{
    public partial class LoginForm : Form
    {
        private readonly IDataConnection context;
        public User CurrentUser { get; private set; }

        public LoginForm(IDataConnection context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            try
            {
                using (var db = context.Create())
                {
                    var user = db.GetTable<User>()
                        .FirstOrDefault(u => u.Login == login && u.Password == password);

                    if (user != null && user.IsActive == false)
                    {
                        user.IsActive = true;
                        CurrentUser = user;
                        DialogResult = DialogResult.OK;
                        db.Update(user);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}