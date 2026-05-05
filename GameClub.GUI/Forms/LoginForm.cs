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
using GameClub.Library.ServiceInterfaces;

namespace GameClub.GUI
{
    /// <summary>
    /// Форма авторизации для админов/операторов
    /// </summary>
    public partial class LoginForm : Form
    {
        private readonly IAuthentication authenticationService;

        public User CurrentUser { get; private set; }

        public LoginForm(IAuthentication authenticationService)
        {
            InitializeComponent();
            this.authenticationService = authenticationService;
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            AcceptButton = btnLogin;
            txtLogin.KeyDown += TxtBox_KeyDown;
            txtPassword.KeyDown += TxtBox_KeyDown;
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
        private void TxtBox_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    e.SuppressKeyPress = true;
                    if (sender == txtPassword)
                    {
                        txtLogin.Focus();
                    }
                    break;

                case Keys.Down:
                    e.SuppressKeyPress = true;
                    if (sender == txtLogin)
                    {
                        txtPassword.Focus();
                    }
                    break;
            }
        }
    }
}