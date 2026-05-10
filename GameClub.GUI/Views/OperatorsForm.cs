using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Entities;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Views
{
    public partial class OperatorsForm : Form, IOperatorsView
    {
        public string LoginInput => txtLogin.Text.Trim();
        public string PasswordInput => txtPassword.Text.Trim();
        public string FullNameInput => txtFullName.Text.Trim();

        public int? SelectedOperatorId
        {
            get
            {
                if (dgvOperators.SelectedRows.Count > 0
                    && dgvOperators.SelectedRows[0].Cells["UserId"].Value != null)
                    return Convert.ToInt32(dgvOperators.SelectedRows[0].Cells["UserId"].Value);
                return null;
            }
        }

        public event EventHandler AddRequested;
        public event EventHandler EditRequested;
        public event EventHandler DeleteRequested;
        public event EventHandler SelectionChanged;
        public event EventHandler ClearRequested;

        public OperatorsForm(IAdministrator adminService)
        {
            InitializeComponent();

            dgvOperators.SelectionChanged += (s, e) => SelectionChanged?.Invoke(this, EventArgs.Empty);
            btnAdd.Click += (s, e) => AddRequested?.Invoke(this, EventArgs.Empty);
            btnEdit.Click += (s, e) => EditRequested?.Invoke(this, EventArgs.Empty);
            btnClear.Click += (s, e) => ClearRequested?.Invoke(this, EventArgs.Empty);
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            btnDelete.Click += (s, e) =>
            {
                var selected = SelectedOperatorId;
                if (selected == null) { DeleteRequested?.Invoke(this, EventArgs.Empty); return; }

                var result = MessageBox.Show(
                    "Удалить выбранного оператора?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    DeleteRequested?.Invoke(this, EventArgs.Empty);
            };
        }

        public void LoadOperators(List<User> operators)
        {
            Cursor = Cursors.Default;
            dgvOperators.Rows.Clear();

            if (operators == null || operators.Count == 0)
            {
                dgvOperators.Rows.Add("", "", "", "Нет операторов");
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                return;
            }

            foreach (var op in operators)
                dgvOperators.Rows.Add(op.UserId, op.Login, op.Password, op.FullName);

            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        public void SetSelectedOperatorInfo(string login, string password, string fullName, string labelText)
        {
            txtLogin.Text = login;
            txtPassword.Text = password;
            txtFullName.Text = fullName;
            lblSelected.Text = labelText;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        public void ClearSelection()
        {
            lblSelected.Text = "";
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            dgvOperators.ClearSelection();
        }

        public void ClearInputFields()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfo(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
