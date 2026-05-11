using System;
using System.Drawing;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления главной формы приложения
    /// </summary>
    public interface IMainView
    {
        /// <summary>
        /// Событие обновления карты мест
        /// </summary>
        event EventHandler RefreshRequested;

        /// <summary>
        /// Событие поиска свободного места
        /// </summary>
        event EventHandler FindFreeSeatRequested;

        /// <summary>
        /// Событие закрытия активной сессии
        /// </summary>
        event EventHandler CloseSessionRequested;

        /// <summary>
        /// Событие добавления часов к сессии
        /// </summary>
        event EventHandler AddHoursRequested;

        /// <summary>
        /// Событие просмотра выручки
        /// </summary>
        event EventHandler RevenueRequested;

        /// <summary>
        /// Событие открытия панели администратора (настройка тарифов)
        /// </summary>
        event EventHandler AdminPanelRequested;

        /// <summary>
        /// Событие управления операторами
        /// </summary>
        event EventHandler ManageOperatorsRequested;

        /// <summary>
        /// Событие нажатия на кнопку места на карте
        /// </summary>
        event EventHandler<int> SeatButtonClicked;

        /// <summary>
        /// Установка заголовка главной формы
        /// </summary>
        /// <param name="title">Текст заголовка</param>
        void SetTitle(string title);

        /// <summary>
        /// Отображение или скрытие кнопок администратора
        /// </summary>
        /// <param name="visible">Флаг видимости</param>
        void ShowAdminButtons(bool visible);

        /// <summary>
        /// Установка цвета кнопки места на карте
        /// </summary>
        /// <param name="seatId">ID места</param>
        /// <param name="color">Цвет</param>
        void SetSeatColor(int seatId, Color color);

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