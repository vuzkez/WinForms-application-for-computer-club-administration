using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.DTO;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Форма закрытия активной сессии
    /// </summary>
    public partial class CloseSessionForm : Form, ICloseSessionView
    {
        /// <summary>
        /// Свойства для передачи результатов презентеру
        /// </summary>
        public int SelectedSeatId { get; private set; }
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
        /// Событие подтверждения закрытия сессии
        /// </summary>
        public event EventHandler ConfirmClose;

        /// <summary>
        /// Событие выбора места в выпадающем списке
        /// </summary>
        public event EventHandler SeatSelectionChanged;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CloseSessionForm()
        {
            InitializeComponent();

            cmbActiveSeats.SelectedIndexChanged += (s, e) => SeatSelectionChanged?.Invoke(this, EventArgs.Empty);

            btnClose.Click += (s, e) =>
            {
                var result = MessageBox.Show(
                    $"Закрыть сессию на месте #{SelectedComboSeatId}?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (cmbActiveSeats.SelectedItem is ComboBoxItem item)
                        SelectedSeatId = item.Value;

                    ConfirmClose?.Invoke(this, EventArgs.Empty);
                }
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
        /// <param name="items">Список мест</param>
        public void LoadActiveSeats(List<ComboBoxItem> items)
        {
            Cursor = Cursors.Default;
            cmbActiveSeats.DisplayMember = "Text";
            cmbActiveSeats.ValueMember = "Value";
            cmbActiveSeats.DataSource = items;
            if (items.Count > 0) 
                cmbActiveSeats.SelectedIndex = 0;
        }

        /// <summary>
        /// Установка состояния при отсутствии активных сессий
        /// </summary>
        public void SetNoActiveSeats()
        {
            Cursor = Cursors.Default;
            cmbActiveSeats.DataSource = null;
            cmbActiveSeats.Items.Clear();
            cmbActiveSeats.Items.Add("Нет активных мест");
            cmbActiveSeats.Enabled = false;
            btnClose.Enabled = false;
            lblSessionInfo.Text = "Нет активных сессий";
            lblSessionInfo.ForeColor = Color.Red;
        }

        /// <summary>
        /// Обновление информации о выбранной сессии
        /// </summary>
        /// <param name="text">Текст информации</param>
        public void UpdateSessionInfo(string text)
        {
            lblSessionInfo.Text = text;
            lblSessionInfo.ForeColor = Color.DarkRed;
            btnClose.Enabled = true;
        }

        /// <summary>
        /// Сохранение ID сессии
        /// </summary>
        /// <param name="sessionId">ID сессии</param>
        public void SetSessionId(int sessionId) => SessionId = sessionId;

        /// <summary>
        /// Сохранение ID выбранного места
        /// </summary>
        /// <param name="seatId">ID места</param>
        public void SetSelectedSeatId(int seatId) => SelectedSeatId = seatId;

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