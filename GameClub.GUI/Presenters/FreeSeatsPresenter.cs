using System;
using System.Collections.Generic;
using GameClub.GUI.ViewInterfaces;
using GameClub.Library.Entities;

namespace GameClub.GUI.Presenters
{
    public class FreeSeatsPresenter
    {
        private readonly IFreeSeatsView view;
        private readonly List<Seat> freeSeats;
        private readonly string roomType;

        public FreeSeatsPresenter(IFreeSeatsView view, List<Seat> freeSeats, string roomType)
        {
            this.view = view;
            this.freeSeats = freeSeats;
            this.roomType = roomType;

            this.view.OpenSessionRequested += OnOpenSessionRequested;

            this.view.LoadSeats(freeSeats, roomType);
        }

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
