using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameClub.Library.ServiceInterfaces;
using GameClub.Library.Entities;
using GameClub.Library.Enums;

namespace GameClub.GUI
{
    public partial class CloseSessionForm : Form
    {
        public int SelectedSeatId { get; private set; }
        public int SessionId { get; private set; }

        private readonly IOperator operatorService;
        private List<Seat> activeSeats;
        private Dictionary<int, Session> sessionsBySeat;
        private Dictionary<int, TariffSetting> tariffSettings;

        public CloseSessionForm(IOperator operatorService)
        {
            InitializeComponent();
            this.operatorService = operatorService;
            LoadActiveSeatsAsync();
        }

        private async void LoadActiveSeatsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var tariffs = await operatorService.GetAllTariffsAsync();
                tariffSettings = tariffs.ToDictionary(t => t.TariffId);

                activeSeats = await operatorService.FindActiveSeatsAsync();

                if (activeSeats == null || activeSeats.Count == 0)
                {
                    cmbActiveSeats.Items.Add("Нет активных сессий");
                    cmbActiveSeats.Enabled = false;
                    btnClose.Enabled = false;
                    lblSessionInfo.Text = "Нет активных сессий для закрытия";
                    lblSessionInfo.ForeColor = Color.Red;
                    return;
                }

                sessionsBySeat = new Dictionary<int, Session>();
                foreach (var seat in activeSeats)
                {
                    var session = await operatorService.GetActiveSessionBySeatIdAsync(seat.SeatId);
                    if (session != null)
                    {
                        sessionsBySeat[seat.SeatId] = session;
                    }
                }

                cmbActiveSeats.DisplayMember = "Text";
                cmbActiveSeats.ValueMember = "Value";

                var items = activeSeats.Select(seat => new
                {
                    Text = $"ПК #{seat.SeatId} — {seat.SeatRoom}",
                    Value = seat.SeatId
                }).ToList();

                cmbActiveSeats.DataSource = items;

                if (items.Count > 0)
                {
                    cmbActiveSeats.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки активных сессий: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClose.Enabled = false;
            }
            finally
            {
                Cursor = Cursors.Default;
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

                var seat = activeSeats?.FirstOrDefault(s => s.SeatId == seatId);
                var session = sessionsBySeat?.GetValueOrDefault(seatId);

                if (seat != null && session != null)
                {
                    UpdateSessionInfo(seat, session);
                    SelectedSeatId = seatId;
                    SessionId = session.SessionId;
                    btnClose.Enabled = true;
                }
                else
                {
                    lblSessionInfo.Text = "Не удалось получить данные сессии";
                    lblSessionInfo.ForeColor = Color.Red;
                    btnClose.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblSessionInfo.Text = "Ошибка при получении данных сессии";
                lblSessionInfo.ForeColor = Color.Red;
                btnClose.Enabled = false;
            }
        }

        private void UpdateSessionInfo(Seat seat, Session session)
        {
            var remaining = session.EndTime - DateTime.Now;
            var totalHours = (session.EndTime - session.StartTime).TotalHours;

            string tariffName = "Неизвестный";
            if (tariffSettings.TryGetValue(session.TariffId, out var tariff))
                tariffName = tariff.Type == TariffType.Day ? "Дневной" : "Ночной";

            lblSessionInfo.Text =
                $"ПК: #{seat.SeatId} ({seat.SeatRoom})\n" +
                $"ID сессии: {session.SessionId}\n" +
                $"Начало: {session.StartTime:dd.MM.yyyy HH:mm}\n" +
                $"Окончание: {session.EndTime:dd.MM.yyyy HH:mm}\n" +
                $"Длительность: {totalHours:F1} ч\n" +
                $"Осталось: {Math.Max(0, remaining.Hours)}ч {Math.Max(0, remaining.Minutes)}мин\n" +
                $"Тариф: {tariffName}\n" +
                $"Сумма к оплате: {session.TotalAmount:F2} руб";

            lblSessionInfo.ForeColor = Color.DarkRed;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionId == 0 || SelectedSeatId == 0)
                {
                    MessageBox.Show("Выберите активную сессию для закрытия.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var session = sessionsBySeat?.GetValueOrDefault(SelectedSeatId);

                string tariffName = "Неизвестный";
                if (tariffSettings.TryGetValue(session.TariffId, out var tariff))
                    tariffName = tariff.Type == TariffType.Day ? "Дневной" : "Ночной";

                var confirmResult = MessageBox.Show(
                    $"Закрыть сессию на ПК #{SelectedSeatId}?\n\n" +
                    $"Начало: {session?.StartTime:dd.MM.yyyy HH:mm}\n" +
                    $"Окончание: {session?.EndTime:dd.MM.yyyy HH:mm}\n" +
                    $"Тариф: {tariffName}\n" +
                    $"Сумма: {session?.TotalAmount:F2} руб",
                    "Подтверждение закрытия",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при закрытии сессии: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}