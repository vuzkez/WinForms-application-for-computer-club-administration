using System;
using System.Collections.Generic;
using GameClub.Library.Entities;

namespace GameClub.GUI.ViewInterfaces
{
    public interface IAddHoursView
    {
        int SelectedSeatId { get; }
        int AdditionalHours { get; }
        int SessionId { get; }

        int SelectedComboSeatId { get; }
        int NudHoursValue { get; }

        event EventHandler ConfirmAddHours;
        event EventHandler SeatSelectionChanged;

        void LoadActiveSeats(List<object> items);
        void SetNoActiveSeats();
        void SetSessionId(int sessionId);
        void UpdateSessionInfo(string text, bool isValid);
        void ShowError(string message);
        void CloseWithOk();
        void Close();
    }
}
