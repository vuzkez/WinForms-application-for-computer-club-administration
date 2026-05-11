using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.DTO;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Форма добавления часов к активной сессии
    /// </summary>
    public partial class AddHoursForm : Form, IAddHoursView
    {
        /// <summary>
        /// Свойства для передачи результатов презентеру
        /// </summary>
        public int SelectedSeatId { get; private set; }
        public int AdditionalHours { get; private set; }
        public int SessionId { get; private set; }

        /// <summary>
        /// Свойство для получения ID выбранного места из выпадающего списка
        /// </summary>
        public int SelectedComboSeatId
        {
            get
            {
                if (cmbActiveSeats.SelectedItem is ComboBoxItem item)
                    return item.Value;
                return 0;
            }
        }

        /// <summary>
        /// Событие подтверждения добавления часов
        /// </summary>
        public event EventHandler ConfirmAddHours;

        /// <summary>
        /// Событие выбора места в выпадающем списке
        /// </summary>
        public event EventHandler SeatSelectionChanged;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public AddHoursForm()
        {
            InitializeComponent();

            nudHours.Minimum = 1;
            nudHours.Maximum = 24;
            nudHours.Value = 1;

            cmbActiveSeats.SelectedIndexChanged += (s, e) => SeatSelectionChanged?.Invoke(this, EventArgs.Empty);

            btnOk.Click += (s, e) =>
            {
                if (cmbActiveSeats.SelectedItem is ComboBoxItem item)
                {
                    SelectedSeatId = item.Value;
                    AdditionalHours = (int)nudHours.Value;
                }
                ConfirmAddHours?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        /// <summary>
        /// Загрузка списка активных мест в выпадающий список
        /// </summary>
        /// <param name="items">Список элементов для отображения</param>
        public void LoadActiveSeats(List<ComboBoxItem> items)
        {
            cmbActiveSeats.DisplayMember = "Text";
            cmbActiveSeats.ValueMember = "Value";
            cmbActiveSeats.DataSource = items;
            cmbActiveSeats.SelectedIndex = 0;
        }

        /// <summary>
        /// Установка состояния при отсутствии активных сессий
        /// </summary>
        public void SetNoActiveSeats()
        {
            cmbActiveSeats.DataSource = null;
            cmbActiveSeats.Items.Clear();
            cmbActiveSeats.Items.Add("Нет активных мест");
            cmbActiveSeats.Enabled = false;
            btnOk.Enabled = false;
            lblSessionInfo.Text = "Нет активных сессий";
        }

        /// <summary>
        /// Обновление информации о выбранной сессии
        /// </summary>
        /// <param name="text">Текст информации</param>
        /// <param name="isValid">Флаг валидности (влияет на цвет текста и доступность кнопки)</param>
        public void UpdateSessionInfo(string text, bool isValid)
        {
            lblSessionInfo.Text = text;
            lblSessionInfo.ForeColor = isValid ? Color.Green : Color.Red;
            btnOk.Enabled = isValid;
        }

        /// <summary>
        /// Сохранение ID выбранной сессии
        /// </summary>
        /// <param name="sessionId">ID сессии</param>
        public void SetSessionId(int sessionId) => SessionId = sessionId;

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Закрытие формы с положительным результатом
        /// </summary>
        public void CloseWithOk()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}