using System;
using System.Collections.Generic;
using System.Linq;
using GameClub.GUI.ViewInterfaces;
using GameClub.Library.Entities;
using GameClub.Library.Enums;
using GameClub.Library.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    public class OperatorsPresenter
    {
        private readonly IOperatorsView view;
        private readonly IAdministrator adminService;

        private List<User> operators;
        private User selectedOperator;

        public OperatorsPresenter(IOperatorsView view, IAdministrator adminService)
        {
            this.view = view;
            this.adminService = adminService;

            this.view.AddRequested += OnAddRequested;
            this.view.EditRequested += OnEditRequested;
            this.view.DeleteRequested += OnDeleteRequested;
            this.view.SelectionChanged += OnSelectionChanged;
            this.view.ClearRequested += OnClearRequested;

            LoadOperatorsAsync();
        }

        private async void LoadOperatorsAsync()
        {
            try
            {
                operators = await adminService.GetAllOperatorsAsync();
                view.LoadOperators(operators);
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            int? userId = view.SelectedOperatorId;
            selectedOperator = operators?.FirstOrDefault(o => o.UserId == userId);

            if (selectedOperator != null)
            {
                view.SetSelectedOperatorInfo(
                    selectedOperator.Login,
                    selectedOperator.Password,
                    selectedOperator.FullName,
                    $"Выбран: {selectedOperator.FullName} (логин: {selectedOperator.Login})"
                );
            }
            else
            {
                selectedOperator = null;
                view.ClearSelection();
            }
        }

        private void OnClearRequested(object sender, EventArgs e)
        {
            selectedOperator = null;
            view.ClearInputFields();
            view.ClearSelection();
        }

        private async void OnAddRequested(object sender, EventArgs e)
        {
            try
            {
                string login = view.LoginInput;
                string password = view.PasswordInput;
                string fullName = view.FullNameInput;

                if (string.IsNullOrEmpty(login))
                {
                    view.ShowError("Введите логин!");
                    return;
                }
                if (login.Length < 3)
                {
                    view.ShowError("Логин слишком короткий!");
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    view.ShowError("Введите пароль!");
                    return;
                }
                if (password.Length < 3)
                {
                    view.ShowError("Пароль слишком короткий!");
                    return;
                }
                if (string.IsNullOrEmpty(fullName))
                {
                    view.ShowError("Введите ФИО!");
                    return;
                }

                await adminService.AddOperatorAsync(login, password, fullName);
                view.ShowInfo($"Оператор {fullName} добавлен!");
                view.ClearInputFields();
                LoadOperatorsAsync();
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }

        private async void OnEditRequested(object sender, EventArgs e)
        {
            if (selectedOperator == null)
            {
                view.ShowError("Выберите оператора!");
                return;
            }

            try
            {
                string newLogin = view.LoginInput;
                string newPassword = view.PasswordInput;
                string newFullName = view.FullNameInput;

                if (string.IsNullOrEmpty(newLogin) || string.IsNullOrEmpty(newFullName))
                {
                    view.ShowError("Заполните обязательные поля!");
                    return;
                }

                if (string.IsNullOrEmpty(newPassword))
                {
                    newPassword = selectedOperator.Password;
                }
                else if (newPassword.Length < 3)
                {
                    view.ShowError("Пароль слишком короткий!");
                    return;
                }

                var updatedOperator = new User
                {
                    UserId = selectedOperator.UserId,
                    Login = newLogin,
                    Password = newPassword,
                    FullName = newFullName,
                    UserRole = UserRole.Operator
                };

                await adminService.UpdateOperatorAsync(updatedOperator);
                view.ShowInfo($"Оператор {newFullName} обновлён!");
                view.ClearInputFields();
                LoadOperatorsAsync();
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }

        private async void OnDeleteRequested(object sender, EventArgs e)
        {
            if (selectedOperator == null)
            {
                view.ShowError("Выберите оператора!");
                return;
            }
            try
            {
                await adminService.DeleteOperatorAsync(selectedOperator.UserId);
                view.ShowInfo("Оператор удалён!");
                view.ClearInputFields();
                LoadOperatorsAsync();
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }
    }
}
