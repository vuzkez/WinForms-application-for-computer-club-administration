using System;
using System.Collections.Generic;
using GameClub.Domain.Entities;

namespace GameClub.GUI.ViewInterfaces
{
    public interface IOperatorsView
    {
        string LoginInput { get; }
        string PasswordInput { get; }
        string FullNameInput { get; }
        int? SelectedOperatorId { get; }

        event EventHandler AddRequested;
        event EventHandler EditRequested;
        event EventHandler DeleteRequested;
        event EventHandler SelectionChanged;
        event EventHandler ClearRequested;

        void LoadOperators(List<User> operators);
        void SetSelectedOperatorInfo(string login, string password, string fullName, string labelText);
        void ClearSelection();
        void ClearInputFields();
        void ShowError(string message);
        void ShowInfo(string message);
    }
}
