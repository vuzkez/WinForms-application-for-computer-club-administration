using System;
using System.Collections.Generic;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Entities;

namespace GameClub.GUI.Presenters
{
    /// <summary>
    /// Презентер формы отображения свободных мест в выбранном зале
    /// </summary>
    public class FreeSeatsPresenter
    {
        /// <summary>
        /// Поле для хранения представления
        /// </summary>
        private readonly IFreeSeatsView view;

        /// <summary>
        /// Поля для хранения списка свободных мест и типа зала
        /// </summary>
        private readonly List<Seat> freeSeats;
        private readonly string roomType;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="view">Отображение</param>
        /// <param name="freeSeats">Список свободных мест</param>
        /// <param name="roomType">Тип выбранного зала</param>
        public FreeSeatsPresenter(IFreeSeatsView view, List<Seat> freeSeats, string roomType)
        {
            this.view = view;
            this.freeSeats = freeSeats;
            this.roomType = roomType;

            this.view.OpenSessionRequested += OnOpenSessionRequested;

            this.view.LoadSeats(freeSeats, roomType);
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Открыть сессию" для выбранного места
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenSessionRequested(object sender, EventArgs e)
        {
            if (view.SelectedSeat == null)
            {
                view.ShowError("Выберите место!");
                return;
            }

            view.CloseWithOk(view.SelectedSeat);
        }
    }
}