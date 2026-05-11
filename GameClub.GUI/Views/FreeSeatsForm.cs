using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Entities;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Форма отображения списка свободных мест в выбранном зале
    /// </summary>
    public partial class FreeSeatsForm : Form, IFreeSeatsView
    {
        /// <summary>
        /// Свойство для получения выбранного места
        /// </summary>
        public Seat SelectedSeat { get; private set; }

        /// <summary>
        /// Событие запроса на открытие сессии для выбранного места
        /// </summary>
        public event EventHandler OpenSessionRequested;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="freeSeats">Список свободных мест</param>
        /// <param name="roomType">Тип выбранного зала</param>
        public FreeSeatsForm(List<Seat> freeSeats, string roomType)
        {
            InitializeComponent();

            btnOpenSession.Click += (s, e) =>
            {
                if (dgvSeats.SelectedRows.Count > 0
                    && dgvSeats.SelectedRows[0].Cells["SeatId"].Value != null)
                {
                    int seatId = Convert.ToInt32(dgvSeats.SelectedRows[0].Cells["SeatId"].Value);
                    string room = dgvSeats.SelectedRows[0].Cells["SeatRoom"].Value.ToString();
                    string hw = dgvSeats.SelectedRows[0].Cells["Hardware"].Value.ToString();
                    string dev = dgvSeats.SelectedRows[0].Cells["Devices"].Value.ToString();
                    SelectedSeat = new Seat { SeatId = seatId, SeatRoom = room, Hardware = hw, Devices = dev };
                }

                OpenSessionRequested?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += (s, e) =>
            {
                SelectedSeat = null;
                DialogResult = DialogResult.Cancel;
                Close();
            };

            dgvSeats.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    btnOpenSession.PerformClick();
            };

            dgvSeats.SelectionChanged += (s, e) =>
            {
                if (dgvSeats.SelectedRows.Count > 0)
                {
                    int seatId = Convert.ToInt32(dgvSeats.SelectedRows[0].Cells["SeatId"].Value);
                    string room = dgvSeats.SelectedRows[0].Cells["SeatRoom"].Value.ToString();
                    lblSelectedSeat.Text = $"Выбрано: {seatId} ({room})";
                }
                else
                {
                    lblSelectedSeat.Text = "";
                }
            };
        }

        /// <summary>
        /// Загрузка списка свободных мест в таблицу
        /// </summary>
        /// <param name="seats">Список свободных мест</param>
        /// <param name="roomType">Тип выбранного зала</param>
        public void LoadSeats(List<Seat> seats, string roomType)
        {
            Text = $"Свободные места - {roomType}";
            lblTitle.Text = $"Зал: {roomType}";

            if (seats == null || seats.Count == 0)
            {
                dgvSeats.Columns.Clear();
                dgvSeats.Columns.Add("Message", "Сообщение");
                dgvSeats.Rows.Add("Нет свободных мест");
                btnOpenSession.Enabled = false;
                return;
            }

            dgvSeats.Columns.Clear();
            dgvSeats.Columns.Add("SeatId", "Номер");
            dgvSeats.Columns.Add("SeatRoom", "Зал");
            dgvSeats.Columns.Add("Hardware", "Железо");
            dgvSeats.Columns.Add("Devices", "Устройства");
            dgvSeats.Columns["SeatId"].Width = 60;
            dgvSeats.Columns["SeatRoom"].Width = 100;

            foreach (var seat in seats)
            {
                dgvSeats.Rows.Add(seat.SeatId, seat.SeatRoom, seat.Hardware ?? "", seat.Devices ?? "");
            }

            btnOpenSession.Enabled = true;
        }

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Закрытие формы с передачей выбранного места
        /// </summary>
        /// <param name="seat">Выбранное место</param>
        public void CloseWithOk(Seat seat)
        {
            SelectedSeat = seat;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}