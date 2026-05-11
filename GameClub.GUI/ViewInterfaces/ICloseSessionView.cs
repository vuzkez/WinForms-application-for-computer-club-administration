using GameClub.Domain.DTO;
using GameClub.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления формы закрытия активной сессии
    /// </summary>
    public interface ICloseSessionView
    {
        /// <summary>
        /// Свойства для получения данных из формы
        /// </summary>
        int SelectedSeatId { get; }
        int SessionId { get; }
        int SelectedComboSeatId { get; }

        /// <summary>
        /// Событие подтверждения закрытия сессии
        /// </summary>
        event EventHandler ConfirmClose;

        /// <summary>
        /// Событие выбора места в выпадающем списке
        /// </summary>
        event EventHandler SeatSelectionChanged;

        /// <summary>
        /// Загрузка списка активных мест в выпадающий список
        /// </summary>
        /// <param name="items">Список мест для отображения</param>
        void LoadActiveSeats(List<ComboBoxItem> items);

        /// <summary>
        /// Установка состояния при отсутствии активных сессий
        /// </summary>
        void SetNoActiveSeats();

        /// <summary>
        /// Обновление информации о выбранной сессии
        /// </summary>
        /// <param name="text">Текст информации</param>
        void UpdateSessionInfo(string text);

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        void ShowError(string message);

        /// <summary>
        /// Сохранение ID выбранной сессии
        /// </summary>
        /// <param name="sessionId">ID сессии</param>
        void SetSessionId(int sessionId);

        /// <summary>
        /// Сохранение ID выбранного места
        /// </summary>
        /// <param name="seatId">ID места</param>
        void SetSelectedSeatId(int seatId);

        /// <summary>
        /// Закрытие формы с положительным результатом
        /// </summary>
        void CloseWithOk();

        /// <summary>
        /// Закрытие формы
        /// </summary>
        void Close();
    }
}