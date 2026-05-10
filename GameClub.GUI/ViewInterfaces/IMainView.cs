using System;
using System.Collections.Generic;
using System.Drawing;
using GameClub.Domain.Entities;

namespace GameClub.GUI.ViewInterfaces
{
    public interface IMainView
    {
        event EventHandler RefreshRequested;
        event EventHandler FindFreeSeatRequested;
        event EventHandler CloseSessionRequested;
        event EventHandler AddHoursRequested;
        event EventHandler RevenueRequested;
        event EventHandler AdminPanelRequested;
        event EventHandler ManageOperatorsRequested;

        event EventHandler<int> SeatButtonClicked;

        void SetTitle(string title);
        void ShowAdminButtons(bool visible);
        void SetSeatColor(int seatId, Color color);
        void ShowError(string message);
        void ShowInfo(string message);
    }
}
