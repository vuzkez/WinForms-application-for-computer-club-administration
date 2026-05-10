using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Library.Entities;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления формы аунтификации
    /// </summary>
    public interface ILoginView
    {
        /// <summary>
        /// Поля для хранения логина и пароля
        /// </summary>
        string Login { get; }
        string Password { get; }

        /// <summary>
        /// Событие при попытке аунтификации
        /// </summary>
        event EventHandler LoginAttempt;

        /// <summary>
        /// Метод для вывода ошибки
        /// </summary>
        /// <param name="message">Сообщение ошибки</param>
        void ShowError(string message);

        /// <summary>
        /// Метод использующийся при успешной аунтификации
        /// </summary>
        /// <param name="user">Пользователь</param>
        void LoginSuccessful(User user);
    }
}
