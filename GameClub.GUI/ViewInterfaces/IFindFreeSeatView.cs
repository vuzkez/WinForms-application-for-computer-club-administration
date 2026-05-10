using System;

namespace GameClub.GUI.ViewInterfaces
{
    public interface IFindFreeSeatView
    {
        // Выбранный тип комнаты: "General" или "Vip"
        string Result { get; }

        event EventHandler ConfirmSelection;

        void ShowError(string message);
        void CloseWithOk();
    }
}
