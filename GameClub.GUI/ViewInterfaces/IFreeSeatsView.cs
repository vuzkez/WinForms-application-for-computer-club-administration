using System;
using System.Collections.Generic;
using GameClub.Domain.Entities;

namespace GameClub.GUI.ViewInterfaces
{
    public interface IFreeSeatsView
    {
        Seat SelectedSeat { get; }

        event EventHandler OpenSessionRequested;

        void LoadSeats(List<Seat> seats, string roomType);
        void ShowError(string message);
        void CloseWithOk(Seat seat);
    }
}
