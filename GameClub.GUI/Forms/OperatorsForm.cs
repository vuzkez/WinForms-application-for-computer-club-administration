using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameClub.Library.Entities;
using GameClub.Library.Enums;
using GameClub.Library.Interfaces;

namespace GameClub.GUI
{
    public partial class OperatorsForm : Form
    {
        private readonly IAdministrator _adminService;
        private List<User> _operators;
        private User _selectedOperator;

        public OperatorsForm(IAdministrator adminService)
        {
            InitializeComponent();
            _adminService = adminService;
            LoadOperatorsAsync();
        }

        private async Task LoadOperatorsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _operators = await _adminService.GetAllOperatorsAsync();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки операторов: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void RefreshGrid()
        {
            dgvOperators.Rows.Clear();

            if (_operators == null || _operators.Count == 0)
            {
                dgvOperators.Rows.Add("", "", "", "Нет операторов");
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                return;
            }

            foreach (var op in _operators)
            {
                dgvOperators.Rows.Add(op.UserId, op.Login, op.Password, op.FullName);
            }

            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            ClearInputFields();
        }

        private void dgvOperators_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOperators.SelectedRows.Count > 0 && dgvOperators.SelectedRows[0].Cells["UserId"].Value != null)
            {
                int userId = Convert.ToInt32(dgvOperators.SelectedRows[0].Cells["UserId"].Value);
                _selectedOperator = _operators?.FirstOrDefault(o => o.UserId == userId);

                if (_selectedOperator != null)
                {
                    txtLogin.Text = _selectedOperator.Login;
                    txtPassword.Text = _selectedOperator.Password; 
                    txtFullName.Text = _selectedOperator.FullName;
                    lblSelected.Text = $"Выбран: {_selectedOperator.FullName} (логин: {_selectedOperator.Login})";
                    btnAdd.Enabled = true;    
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                _selectedOperator = null;
                lblSelected.Text = "Выберите оператора из списка";
                ClearInputFields();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void ClearInputFields()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            dgvOperators.ClearSelection();
            _selectedOperator = null;
            lblSelected.Text = "Выберите оператора из списка";
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string login = txtLogin.Text.Trim();
                string password = txtPassword.Text.Trim();
                string fullName = txtFullName.Text.Trim();

                if (string.IsNullOrEmpty(login))
                {
                    MessageBox.Show("Введите логин!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (login.Length < 3)
                {
                    MessageBox.Show("Логин должен содержать минимум 3 символа!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Введите пароль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password.Length < 3)
                {
                    MessageBox.Show("Пароль должен содержать минимум 3 символа!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(fullName))
                {
                    MessageBox.Show("Введите ФИО оператора!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await _adminService.AddOperatorAsync(login, password, fullName);

                MessageBox.Show($"Оператор {fullName} успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputFields();
                await LoadOperatorsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedOperator == null)
            {
                MessageBox.Show("Выберите оператора для редактирования!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string newLogin = txtLogin.Text.Trim();
                string newPassword = txtPassword.Text.Trim();
                string newFullName = txtFullName.Text.Trim();

                if (string.IsNullOrEmpty(newLogin) || string.IsNullOrEmpty(newFullName))
                {
                    MessageBox.Show("Логин и ФИО не могут быть пустыми!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Если пароль пустой - оставляем старый
                if (string.IsNullOrEmpty(newPassword))
                {
                    newPassword = _selectedOperator.Password;
                }
                else if (newPassword.Length < 3)
                {
                    MessageBox.Show("Новый пароль должен быть минимум 3 символа!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var updatedOperator = new User
                {
                    UserId = _selectedOperator.UserId,
                    Login = newLogin,
                    Password = newPassword,
                    FullName = newFullName,
                    UserRole = UserRole.Operator
                };

                await _adminService.UpdateOperatorAsync(updatedOperator);

                MessageBox.Show($"Оператор {newFullName} успешно обновлён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputFields();
                await LoadOperatorsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedOperator == null)
            {
                MessageBox.Show("Выберите оператора для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Удалить оператора '{_selectedOperator.FullName}'?\n\nЛогин: {_selectedOperator.Login}\nПароль: {_selectedOperator.Password}\n\nЭто действие нельзя отменить!",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _adminService.DeleteOperatorAsync(_selectedOperator.UserId);

                    MessageBox.Show("Оператор успешно удалён!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields();
                    await LoadOperatorsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}