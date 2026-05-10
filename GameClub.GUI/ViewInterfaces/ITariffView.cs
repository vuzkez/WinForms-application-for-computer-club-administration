using System;

namespace GameClub.GUI.ViewInterfaces
{
    public interface ITariffView
    {
        decimal DayPrice { get; }
        decimal NightPrice { get; }

        event EventHandler SaveRequested;

        void SetPrices(decimal dayPrice, decimal nightPrice);
        void ShowError(string message);
        void ShowInfo(string message);
        void CloseWithOk();
    }
}
