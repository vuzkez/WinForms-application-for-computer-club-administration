using System;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Entities;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Форма представления аунтификации
    /// </summary>
    public partial class LoginForm : Form, ILoginView
    {
        /// <summary>
        /// Конструктор представления
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();

            btnLogin.Click += (sender, args) => LoginAttempt.Invoke(this, EventArgs.Empty);
            AcceptButton = btnLogin;
            txtLogin.KeyDown += TextBox_KeyDown;
            txtPassword.KeyDown += TextBox_KeyDown;
        }

        /// <summary>
        /// Свойства для хранения логина, пароля и пользователя
        /// </summary>
        public User AuthenticatedUser { get; private set; }
        public string Login => txtLogin.Text;
        public string Password => txtPassword.Text;
        
        /// <summary>
        /// Обработчик попытки входа
        /// </summary>

        public event EventHandler LoginAttempt;

        /// <summary>
        /// Метод для отображения ошибки
        /// </summary>
        /// <param name="message">Сообщение ошибки</param>
        public void ShowError(string message)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.Red;
        }

        /// <summary>
        /// Метод вызывающийся при успешной аунтификации
        /// </summary>
        /// <param name="user"></param>
        public void LoginSuccessful(User user)
        {
            AuthenticatedUser = user;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обработчик для стрелочек Up,Down для логина и пароля
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!txtLogin.Focused)
                        txtLogin.Focus();
                    break;
                case Keys.Down:
                    if (!txtPassword.Focused)
                        txtPassword.Focus();
                    break;
            }
        }
    }
}