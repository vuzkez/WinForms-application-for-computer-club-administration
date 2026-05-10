using System;

namespace GameClub.GUI.ViewInterfaces
{
    public interface IFindFreeSeatView
    {
        string Result { get; }

        event EventHandler ConfirmSelection;

        void ShowError(string message);
        void CloseWithOk();
    }
}
