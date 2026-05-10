using System;
using GameClub.Library.Enums;

namespace GameClub.GUI.ViewInterfaces
{
    public interface IOpenSessionView
    {
        // Данные выбранные пользователем
        int SelectedSeatId { get; }
        TariffType SelectedTariff { get; }
        DateTime StartTime { get; }
        int Hours { get; }

        // Входные данные с формы
        string SeatIdText { get; }
        bool IsSeatPreselected { get; }
        bool IsDayTariffSelected { get; }
        bool IsNightTariffSelected { get; }
        string HoursText { get; }

        event EventHandler ConfirmOpen;
        event EventHandler FormLoaded;

        void SetDayTariffLabel(string text);
        void SetNightTariffLabel(string text);
        void SetCurrentDateTime(string text);
        void ShowError(string message);
        void Close();
        void CloseWithOk();
    }
}
