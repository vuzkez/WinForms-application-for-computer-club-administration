using GameClub.Library.ServiceInterfaces;
using GameClub.Library.Entities;
using GameClub.Library.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameClub.GUI.Views;

public partial class AddHoursForm : Form
{
    public int SelectedSeatId { get; private set; }
    public int AdditionalHours { get; private set; }
    public int SessionId { get; private set; }

    private readonly IOperator operatorService;
    private List<Seat> activeSeats;
    private Dictionary<int, Session> sessionsBySeat;

    public AddHoursForm(IOperator operatorService)
    {
        InitializeComponent();
        this.operatorService = operatorService;

        nudHours.Minimum = 1;
        nudHours.Maximum = 24;
        nudHours.Value = 1;

        LoadActiveSeatsAsync();
    }

    private async void LoadActiveSeatsAsync()
    {
        try
        {
            activeSeats = await operatorService.FindActiveSeatsAsync();

            if (activeSeats == null || activeSeats.Count == 0)
            {
                cmbActiveSeats.Items.Add("Нет активных сессий");
                cmbActiveSeats.Enabled = false;
                btnOk.Enabled = false;
                lblSessionInfo.Text = "Нет активных сессий";
                return;
            }

            var sessionsWithDetails = await operatorService.GetActiveSessionsWithDetailsAsync();
            sessionsBySeat = sessionsWithDetails
                .Where(s => s.SeatId > 0)
                .ToDictionary(s => s.SeatId);

            cmbActiveSeats.DisplayMember = "Text";
            cmbActiveSeats.ValueMember = "Value";

            var items = activeSeats.Select(seat => new
            {
                Text = $"ПК #{seat.SeatId} — {seat.SeatRoom}",
                Value = seat.SeatId
            }).ToList();

            cmbActiveSeats.DataSource = items;
            cmbActiveSeats.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки активных сессий: {ex.Message}",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
    }

    private void cmbActiveSeats_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cmbActiveSeats.SelectedItem == null) 
                return;

            dynamic selected = cmbActiveSeats.SelectedItem;
            int seatId = selected.Value;

            var seat = activeSeats.FirstOrDefault(s => s.SeatId == seatId);
            var session = sessionsBySeat?.GetValueOrDefault(seatId);

            if (seat != null && session != null)
            {
                UpdateSessionInfo(seat, session);
            }
        }
        catch
        {
            lblSessionInfo.Text = "Ошибка при получении данных сессии";
            lblSessionInfo.ForeColor = Color.Red;
            SessionId = 0;
            btnOk.Enabled = false;
        }
    }

    private void UpdateSessionInfo(Seat seat, Session session)
    {
        var remaining = session.EndTime - DateTime.Now;

        string tariffName = session.TariffSetting?.Type == TariffType.Day ? "Дневной" : "Ночной";

        lblSessionInfo.Text =
            $"Сессия найдена!\n" +
            $"ПК: #{seat.SeatId} ({seat.SeatRoom})\n" +
            $"Статус: {(seat.Status == SeatStatus.Expiring ? "Скоро освободится" : "Занят")}\n" +
            $"Начало: {session.StartTime:dd.MM.yyyy HH:mm}\n" +
            $"Окончание: {session.EndTime:dd.MM.yyyy HH:mm}\n" +
            $"Осталось: {remaining.Hours}ч {remaining.Minutes}мин\n" +
            $"Тариф: {tariffName}\n" +
            $"Текущая сумма: {session.TotalAmount} руб";

        lblSessionInfo.ForeColor = Color.Green;
        SessionId = session.SessionId;
        SelectedSeatId = seat.SeatId;
        btnOk.Enabled = true;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            if (SessionId == 0)
            {
                MessageBox.Show("Выберите активную сессию.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hours = (int)nudHours.Value;
            var session = sessionsBySeat.GetValueOrDefault(SelectedSeatId);
            var additionalCost = hours * session.TariffSetting.PricePerHour;

            var confirmResult = MessageBox.Show(
                $"Добавить {hours} час(ов) к сессии на ПК #{SelectedSeatId}?\n\n" +
                $"Текущее окончание: {session.EndTime:dd.MM.yyyy HH:mm}\n" +
                $"Новое окончание: {session.EndTime.AddHours(hours):dd.MM.yyyy HH:mm}\n" +
                $"Текущая сумма: {session.TotalAmount} руб\n" +
                $"Будущая сумма: {session.TotalAmount + additionalCost}",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                AdditionalHours = hours;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при добавлении часов: {ex.Message}",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}