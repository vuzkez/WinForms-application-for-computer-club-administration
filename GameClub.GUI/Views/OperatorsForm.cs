using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Entities;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Форма управления операторами.
    /// Позволяет просматривать, добавлять, редактировать и удалять операторов.
    /// </summary>
    public partial class OperatorsForm : Form, IOperatorsView
    {
        /// <summary>
        /// Свойства для чтения данных из полей ввода
        /// </summary>
        public string LoginInput => txtLogin.Text.Trim();
        public string PasswordInput => txtPassword.Text.Trim();
        public string FullNameInput => txtFullName.Text.Trim();

        /// <summary>
        /// Свойство для получения ID выбранного оператора из таблицы
        /// </summary>
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

        /// <summary>
        /// Событие добавления нового оператора
        /// </summary>
        public event EventHandler AddRequested;

        /// <summary>
        /// Событие редактирования выбранного оператора
        /// </summary>
        public event EventHandler EditRequested;

        /// <summary>
        /// Событие удаления выбранного оператора
        /// </summary>
        public event EventHandler DeleteRequested;

        /// <summary>
        /// Событие выбора оператора в таблице
        /// </summary>
        public event EventHandler SelectionChanged;

        /// <summary>
        /// Событие очистки формы
        /// </summary>
        public event EventHandler ClearRequested;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public OperatorsForm()
        {
            InitializeComponent();

            btnAdd.Click += (s, e) => AddRequested?.Invoke(this, EventArgs.Empty);
            btnEdit.Click += (s, e) => EditRequested?.Invoke(this, EventArgs.Empty);
            btnClear.Click += (s, e) => ClearRequested?.Invoke(this, EventArgs.Empty);
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            btnDelete.Click += (s, e) =>
            {
                var selected = SelectedOperatorId;
                if (selected == null)
                {
                    DeleteRequested?.Invoke(this, EventArgs.Empty);
                    return;
                }

                var result = MessageBox.Show(
                    "Удалить выбранного оператора?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    DeleteRequested?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// Загрузка списка операторов в таблицу.
        /// </summary>
        /// <param name="operators">Список операторов</param>
        public void LoadOperators(List<User> operators)
        {
            Cursor = Cursors.Default;
            dgvOperators.Rows.Clear();

            if (operators == null || operators.Count == 0)
            {
                lblSelected.Text = "Нет операторов";
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Enabled = true;
                return;
            }

            foreach (var op in operators)
                dgvOperators.Rows.Add(op.UserId, op.Login ?? "", op.Password ?? "", op.FullName ?? "");

            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;

            dgvOperators.SelectionChanged += (s, e) => SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Заполнение полей ввода данными выбранного оператора
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="fullName">ФИО</param>
        /// <param name="labelText">Текст информационной метки</param>
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

        /// <summary>
        /// Сброс выбранного оператора и очистка информационной метки
        /// </summary>
        public void ClearSelection()
        {
            lblSelected.Text = "Выберите оператора из списка";
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            dgvOperators.ClearSelection();
        }

        /// <summary>
        /// Очистка полей ввода
        /// </summary>
        public void ClearInputFields()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
        }

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Отображение информационного сообщения
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        public void ShowInfo(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}