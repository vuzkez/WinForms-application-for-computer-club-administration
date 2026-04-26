using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameClub.Library.Entities;

namespace GameClub.GUI
{
    public partial class FreeSeatsForm : Form
    {
        public FreeSeatsForm(List<Seat> freeSeats, string roomType)
        {
            InitializeComponent();

            Text = $"Свободные ПК - {roomType}";
            lblTitle.Text = $"Список свободных ПК в комнате {roomType}";

            LoadSeats(freeSeats);
        }

        private void LoadSeats(List<Seat> freeSeats)
        {
            try
            {
                if (freeSeats == null || freeSeats.Count == 0)
                {
                    dgvSeats.Columns.Clear();
                    dgvSeats.Columns.Add("Message", "Информация");
                    dgvSeats.Rows.Add("Нет свободных компьютеров");
                    return;
                }

                dgvSeats.Columns.Clear();
                dgvSeats.Columns.Add("SeatId", "№ ПК");
                dgvSeats.Columns.Add("SeatRoom", "Тип комнаты");
                dgvSeats.Columns.Add("Hardware", "Железо");
                dgvSeats.Columns.Add("Devices", "Девайсы");

                dgvSeats.Columns["SeatId"].Width = 60;
                dgvSeats.Columns["SeatRoom"].Width = 100;

                foreach (var seat in freeSeats)
                {
                    dgvSeats.Rows.Add(
                        seat.SeatId,
                        seat.SeatRoom,
                        seat.Hardware ?? "—",
                        seat.Devices ?? "—"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка ПК: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}