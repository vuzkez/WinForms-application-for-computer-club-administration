using System;
using System.Threading.Tasks;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Entities;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    /// <summary>
    /// Презентер формы логирования
    /// </summary>
    public class LoginPresenter
    {
        /// <summary>
        /// Поля для хранения сервиса аутентификации и представления
        /// </summary>
        private readonly ILoginView view;
        private readonly IAuthentication authenticationService;

        /// <summary>
        /// Конструктор презентера
        /// </summary>
        /// <param name="view">Представление</param>
        /// <param name="authenticationService">Сервис</param>
        public LoginPresenter(ILoginView view, IAuthentication authenticationService)
        {
            this.view = view ;
            this.authenticationService = authenticationService;

            this.view.LoginAttempt += OnLoginAttempt;
        }

        /// <summary>
        /// Обработчик попытки входа
        /// </summary>
        private async void OnLoginAttempt(object sender, EventArgs e)
        {
            string login = view.Login.Trim();
            string password = view.Password.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                view.ShowError("Введите логин и пароль.");
                return;
            }

            try
            {
                User user = await authenticationService.LoginAsync(login, password);

                if (user != null)
                {
                    view.LoginSuccessful(user);
                }
                else
                {
                    view.ShowError("Неверный логин или пароль.");
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }
    }
}