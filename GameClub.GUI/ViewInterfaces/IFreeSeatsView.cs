using System;
using System.Collections.Generic;
using GameClub.Library.Entities;

namespace GameClub.GUI.ViewInterfaces
{
    public interface IFreeSeatsView
    {
        // Выбранное место после закрытия формы
        Seat SelectedSeat { get; }

        event EventHandler OpenSessionRequested;

        void LoadSeats(List<Seat> seats, string roomType);
        void ShowError(string message);
        void CloseWithOk(Seat seat);
    }
}
