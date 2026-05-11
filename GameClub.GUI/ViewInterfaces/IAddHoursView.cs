using System;
using System.Collections.Generic;
using GameClub.Domain.Entities;
using GameClub.Domain.DTO;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления формы добавления часов к активной сессии
    /// </summary>
    public interface IAddHoursView
    {
        /// <summary>
        /// Свойства для получения данных из формы
        /// </summary>
        int SelectedSeatId { get; }
        int AdditionalHours { get; }
        int SessionId { get; }
        int SelectedComboSeatId { get; }

        /// <summary>
        /// Событие подтверждения добавления часов
        /// </summary>
        event EventHandler ConfirmAddHours;

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
        /// Сохранение ID выбранной сессии
        /// </summary>
        /// <param name="sessionId">ID сессии</param>
        void SetSessionId(int sessionId);

        /// <summary>
        /// Обновление информации о выбранной сессии
        /// </summary>
        /// <param name="text">Текст информации</param>
        /// <param name="isValid">Флаг валидности данных</param>
        void UpdateSessionInfo(string text, bool isValid);

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        void ShowError(string message);

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