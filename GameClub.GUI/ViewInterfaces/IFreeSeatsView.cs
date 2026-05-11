using System;
using System.Collections.Generic;
using GameClub.Domain.Entities;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления формы отображения свободных мест в выбранном зале
    /// </summary>
    public interface IFreeSeatsView
    {
        /// <summary>
        /// Свойство для получения выбранного места
        /// </summary>
        Seat SelectedSeat { get; }

        /// <summary>
        /// Событие запроса на открытие сессии для выбранного места
        /// </summary>
        event EventHandler OpenSessionRequested;

        /// <summary>
        /// Загрузка списка свободных мест в таблицу
        /// </summary>
        /// <param name="seats">Список свободных мест</param>
        /// <param name="roomType">Тип выбранного зала</param>
        void LoadSeats(List<Seat> seats, string roomType);

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        void ShowError(string message);

        /// <summary>
        /// Закрытие формы с передачей выбранного места
        /// </summary>
        /// <param name="seat">Выбранное место</param>
        void CloseWithOk(Seat seat);
    }
}