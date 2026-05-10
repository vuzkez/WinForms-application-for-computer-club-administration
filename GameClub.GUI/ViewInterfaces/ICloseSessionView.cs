using System;
using System.Collections.Generic;
using GameClub.Domain.Entities;

namespace GameClub.GUI.ViewInterfaces
{
    public interface ICloseSessionView
    {
        int SelectedSeatId { get; }
        int SessionId { get; }

        int SelectedComboSeatId { get; }

        event EventHandler ConfirmClose;
        event EventHandler SeatSelectionChanged;

        void LoadActiveSeats(List<object> items);
        void SetNoActiveSeats();
        void UpdateSessionInfo(string text);
        void ShowError(string message);
        void SetSessionId(int sessionId);
        void SetSelectedSeatId(int seatId);
        void CloseWithOk();
        void Close();
    }
}
