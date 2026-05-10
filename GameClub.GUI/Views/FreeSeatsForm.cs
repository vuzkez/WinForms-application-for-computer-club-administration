using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameClub.Library.Entities;

namespace GameClub.GUI.Views;

public partial class FreeSeatsForm : Form
{
    public Seat SelectedSeat { get; private set; }

    public FreeSeatsForm(List<Seat> freeSeats, string roomType)
    {
        InitializeComponent();
        SelectedSeat = null;

        Text = $"Свободные ПК - {roomType}";
        lblTitle.Text = $"Список свободных ПК в комнате {roomType}";

        LoadSeats(freeSeats);
        ConfigureButtons();
    }

    private void ConfigureButtons()
    {
        btnOpenSession.Visible = true;
        btnCancel.Text = "Отмена";
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
                btnOpenSession.Enabled = false;
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

            btnOpenSession.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке списка ПК: {ex.Message}",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvSeats_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dgvSeats.Rows[e.RowIndex].Cells["SeatId"].Value != null)
        {
            SelectCurrentRow(e.RowIndex);
            OpenSession();
        }
    }

    private void dgvSeats_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvSeats.SelectedRows.Count > 0)
        {
            int seatId = Convert.ToInt32(dgvSeats.SelectedRows[0].Cells["SeatId"].Value);
            string roomType = dgvSeats.SelectedRows[0].Cells["SeatRoom"].Value.ToString();
            lblSelectedSeat.Text = $"Выбран ПК №{seatId} ({roomType})";
        }
        else
        {
            lblSelectedSeat.Text = "Выберите ПК из списка";
        }
    }

    private void SelectCurrentRow(int rowIndex)
    {
        dgvSeats.ClearSelection();
        dgvSeats.Rows[rowIndex].Selected = true;
    }

    private void btnOpenSession_Click(object sender, EventArgs e)
    {
        OpenSession();
    }

    private void OpenSession()
    {
        try
        {
            if (dgvSeats.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите ПК из списка!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int seatId = Convert.ToInt32(dgvSeats.SelectedRows[0].Cells["SeatId"].Value);
            string roomType = dgvSeats.SelectedRows[0].Cells["SeatRoom"].Value.ToString();
            string hardware = dgvSeats.SelectedRows[0].Cells["Hardware"].Value.ToString();
            string devices = dgvSeats.SelectedRows[0].Cells["Devices"].Value.ToString();

            SelectedSeat = new Seat
            {
                SeatId = seatId,
                SeatRoom = roomType,
                Hardware = hardware,
                Devices = devices
            };

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        SelectedSeat = null;
        DialogResult = DialogResult.Cancel;
        Close();
    }
}