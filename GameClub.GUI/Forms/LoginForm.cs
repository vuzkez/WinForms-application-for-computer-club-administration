using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClub.Library.Entities;
using GameClub.Library.Interfaces;
using GameClub.Library.RepositoryInterfaces;
using LinqToDB;

namespace GameClub.GUI
{
    public partial class LoginForm : Form
    {
        private readonly IAuthentication authenticationService;

        public User CurrentUser { get; private set; }

        public LoginForm(IAuthentication authenticationService)
        {
            InitializeComponent();
            this.authenticationService = authenticationService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            try
            {
                var user = await authenticationService.LoginAsync(login, password);

                if (user != null)
                {
                    CurrentUser = user;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неудалось подключиться к БД:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}