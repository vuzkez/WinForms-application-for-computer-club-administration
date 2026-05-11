using System;
using System.Collections.Generic;
using GameClub.Domain.Entities;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления формы управления операторами
    /// </summary>
    public interface IOperatorsView
    {
        /// <summary>
        /// Свойства для получения данных из полей ввода
        /// </summary>
        string LoginInput { get; }
        string PasswordInput { get; }
        string FullNameInput { get; }
        int? SelectedOperatorId { get; }

        /// <summary>
        /// Событие добавления нового оператора
        /// </summary>
        event EventHandler AddRequested;

        /// <summary>
        /// Событие редактирования выбранного оператора
        /// </summary>
        event EventHandler EditRequested;

        /// <summary>
        /// Событие удаления выбранного оператора
        /// </summary>
        event EventHandler DeleteRequested;

        /// <summary>
        /// Событие выбора оператора в таблице
        /// </summary>
        event EventHandler SelectionChanged;

        /// <summary>
        /// Событие очистки формы
        /// </summary>
        event EventHandler ClearRequested;

        /// <summary>
        /// Загрузка списка операторов в таблицу
        /// </summary>
        /// <param name="operators">Список операторов</param>
        void LoadOperators(List<User> operators);

        /// <summary>
        /// Заполнение полей ввода данными выбранного оператора
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="fullName">ФИО</param>
        /// <param name="labelText">Текст информационной метки</param>
        void SetSelectedOperatorInfo(string login, string password, string fullName, string labelText);

        /// <summary>
        /// Сброс выбранного оператора
        /// </summary>
        void ClearSelection();

        /// <summary>
        /// Очистка полей ввода
        /// </summary>
        void ClearInputFields();

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        void ShowError(string message);

        /// <summary>
        /// Отображение информационного сообщения
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void ShowInfo(string message);
    }
}