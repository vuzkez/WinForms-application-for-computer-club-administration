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
using AdminPanelLibrary.Interfaces;
using AdminPanelLibrary.RepositoryInterfaces;
using LinqToDB;

namespace AdminPanelComputerClub
{
    public partial class LoginForm : Form
    {
        private readonly IAuthentication authenticationService;
        private readonly IUserRepository userRepo;
        public User CurrentUser { get; private set; }

        public LoginForm(IAuthentication authenticationService,IUserRepository userRepo)
        {
            InitializeComponent();
            this.authenticationService = authenticationService;
            this.userRepo = userRepo;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            try
            {
                var user = authenticationService.Login(login, password);

                if (user != null)
                {
                    CurrentUser = user;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    var tempUser = userRepo.GetByLogin(login, password);

                    if (tempUser != null && tempUser.IsActive)
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