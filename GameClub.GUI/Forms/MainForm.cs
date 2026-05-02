using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GameClub.Library;
using GameClub.Library.Enums;
using GameClub.Library.Interfaces;
using GameClub.Library.Entities;

namespace GameClub.GUI
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer timer;
        private readonly User user;
        private readonly IOperator operatorService;
        private readonly IAdministrator administratorService;
        private readonly IAuthentication authenticationService;

        public MainForm(User user, IOperator operatorService, IAdministrator administratorService,
            IAuthentication authenticationService)
        {
            this.user = user;
            this.operatorService = operatorService;
            this.administratorService = administratorService;
            this.authenticationService = authenticationService;

            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
            MinimumSize = new Size(1305, 740);
            ConfigureUIByRole();
            _ = UpdateSeatColorsAsync();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 60000;
            timer.Tick += RefreshTimer_Tick;
            timer.Start();
        }

        private void ConfigureUIByRole()
        {
            if (user.UserRole == UserRole.Administrator)
            {
                btnRevenue.Visible = true;
                btnAdminPanel.Visible = true;
                btnManageOperators.Visible = true;
                Text = "CyberX - Администратор";
            }
            else
            {
                btnRevenue.Visible = false;
                btnAdminPanel.Visible = false;
                btnManageOperators.Visible = false;
                Text = "CyberX - Оператор";
            }
        }

        private async Task UpdateSeatColorsAsync()
        {
            try
            {
                var seats = await operatorService.GetAllSeatsWithStatusAsync();

                var seatButtons = new Dictionary<int, Button>()
                {
                    { 1, btnGen1 }, { 2, btnGen2 }, { 3, btnGen3 }, { 4, btnGen4 }, { 5, btnGen5 },
                    { 6, btnGen6 }, { 7, btnGen7 }, { 8, btnGen8 }, { 9, btnGen9 }, { 10, btnGen10 },
                    { 11, btnGen11 }, { 12, btnGen12 }, { 13, btnGen13 }, { 14, btnGen14 }, { 15, btnGen15 },
                    { 16, btnGen16 }, { 17, btnGen17 }, { 18, btnGen18 }, { 19, btnGen19 }, { 20, btnGen20 },
                    { 21, btnGen21 }, { 22, btnGen22 }, { 23, btnGen23 }, { 24, btnGen24 }, { 25, btnGen25 },
                    { 26, btnVip1 }, { 27, btnVip2 }, { 28, btnVip3 }, { 29, btnVip4 }, { 30, btnVip5 },
                    { 31, btnVip6 }, { 32, btnVip7 }, { 33, btnVip8 }, { 34, btnVip9 }, { 35, btnVip10 }
                };

                foreach (var seat in seats)
                {
                    if (seatButtons.TryGetValue(seat.SeatId, out var btn))
                    {
                        btn.BackColor = GetColor(seat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления статусов ПК: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetColor(Seat seat)
        {
            switch (seat.Status)
            {
                case SeatStatus.Free: 
                    return Color.Green;
                case SeatStatus.Expiring: 
                    return Color.Yellow;
                case SeatStatus.Busy: 
                    return Color.Red;
                default: 
                    return Color.Gray;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                timer.Stop();
                timer.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выходе: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await UpdateSeatColorsAsync();
        }

        private void btnInfoUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Пользователь: {user.FullName}.\nРоль: {user.UserRole}.",
                "Информация о пользователе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnFindFreeSeat_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new FindFreeSeatForm())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var seats = await operatorService.FindFreeSeatsAsync(dialog.Result);
                        using (var freeSeatsForm = new FreeSeatsForm(seats, dialog.Result))
                        {
                            if (freeSeatsForm.ShowDialog() == DialogResult.OK && freeSeatsForm.SelectedSeat != null)
                            {
                                using (var openSessionForm = new OpenSessionForm(operatorService, administratorService,
                                    freeSeatsForm.SelectedSeat.SeatId))
                                {
                                    if (openSessionForm.ShowDialog() == DialogResult.OK)
                                    {
                                        await operatorService.OpenSessionAsync(
                                            openSessionForm.SelectedSeatId,
                                            user.UserId,
                                            openSessionForm.SelectedTariff,
                                            openSessionForm.StartTime,
                                            openSessionForm.StartTime.AddHours(openSessionForm.Hours)
                                        );
                                        await UpdateSeatColorsAsync();
                                        MessageBox.Show($"Сессия на ПК #{openSessionForm.SelectedSeatId} успешно открыта!",
                                                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске свободных мест: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnOpenSession_Click(object sender, EventArgs e)
        {
            try
            {
                using (var inputDialog = new OpenSessionForm(operatorService,administratorService))
                {
                    if (inputDialog.ShowDialog() == DialogResult.OK)
                    {
                        await operatorService.OpenSessionAsync(
                            inputDialog.SelectedSeatId,
                            user.UserId,
                            inputDialog.SelectedTariff,
                            inputDialog.StartTime,
                            inputDialog.StartTime.AddHours(inputDialog.Hours)
                        );
                        await UpdateSeatColorsAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия сессии: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnCloseSession_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new CloseSessionForm(operatorService))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await operatorService.CloseSessionAsync(form.SessionId);
                        await UpdateSeatColorsAsync();
                        MessageBox.Show($"Сессия на ПК #{form.SelectedSeatId} успешно закрыта.",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при закрытии сессии: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddHours_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new AddHoursForm(operatorService))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await operatorService.AddHoursAsync(form.SessionId, form.AdditionalHours);
                        await UpdateSeatColorsAsync();

                        MessageBox.Show($"Добавлено {form.AdditionalHours} час(ов) к сессии на ПК #{form.SelectedSeatId}",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении часов: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new RevenueForm(administratorService))
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdminPanel_Click(object sender, EventArgs e)
        {
            try
            {
                var dayPrice = await administratorService.GetTariffPriceAsync(TariffType.Day);
                var nightPrice = await administratorService.GetTariffPriceAsync(TariffType.Night);

                using (var form = new TariffForm(administratorService, dayPrice, nightPrice))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await UpdateSeatColorsAsync();
                        lblStatus.Text = "Тарифы обновлены";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SeatButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button? clickedButton = sender as Button;
                if (clickedButton == null) return;

                var match = Regex.Match(clickedButton.Text, @"\d+");
                if (!match.Success) return;

                int seatId = int.Parse(match.Value);
                var seats = await operatorService.GetAllSeatsWithStatusAsync();
                var seat = seats.FirstOrDefault(s => s.SeatId == seatId);

                if (seat != null)
                {
                    var activeSession = await operatorService.GetActiveSessionBySeatIdAsync(seatId);
                    string status;

                    if (activeSession != null && activeSession.EndTime > DateTime.Now)
                    {
                        var remaining = activeSession.EndTime - DateTime.Now;
                        status = $"Занят до {activeSession.EndTime:HH:mm} (осталось {remaining.Hours}ч {remaining.Minutes}мин)";
                    }
                    else
                    {
                        status = "Свободен";
                    }

                    MessageBox.Show(
                        $"ПК №{seat.SeatId}\n" +
                        $"Тип комнаты: {seat.SeatRoom}\n" +
                        $"Железо: {seat.Hardware}\n" +
                        $"Девайсы: {seat.Devices}\n" +
                        $"Статус: {status}",
                        "Информация о компьютере",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RefreshTimer_Tick(object? sender, EventArgs? e)
        {
            await UpdateSeatColorsAsync();
        }
        private void btnManageOperators_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new OperatorsForm(administratorService))
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}