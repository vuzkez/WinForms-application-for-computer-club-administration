using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LinqToDB;
using AdminPanelLibrary;
using AdminPanelLibrary.Enums;
using AdminPanelLibrary.Interfaces;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.RepositoryInterfaces;

namespace AdminPanelComputerClub
{
    public partial class MainForm : Form
    {
        private readonly User user;
        private readonly IOperator operatorService;
        private readonly IAdministrator administratorService;
        private readonly IAuthentication authenticationService;
        private readonly ISeatRepository seatRepository;
        private readonly ISessionRepository sessionRepository;
        private readonly ITariffSettingRepository tariffRepository;

        public MainForm(User user, IOperator operatorService, IAdministrator administratorService, 
            IAuthentication authenticationService,ISeatRepository seatRepository,ISessionRepository sessionRepository, 
            ITariffSettingRepository tariffRepository)
        {
            this.user = user;
            this.operatorService = operatorService;
            this.administratorService = administratorService;
            this.authenticationService = authenticationService;
            this.seatRepository = seatRepository;
            this.sessionRepository = sessionRepository;
            this.tariffRepository = tariffRepository;
            AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
            MinimumSize = new Size(1305, 740);
            ConfigureUIByRole();
            UpdateSeatColors();
        }

        private void ConfigureUIByRole()
        {
            if (user.UserRole == UserRole.Administrator)
            {
                btnRevenue.Visible = true;
                btnAdminPanel.Visible = true;
                Text = "GameClub - Администратор";
            }
            else
            {
                btnRevenue.Visible = false;
                btnAdminPanel.Visible = false;
                Text = "GameClub - Оператор";
            }
        }

        private void UpdateSeatColors()
        {
            try
            {
                var seats = operatorService.GetAllSeatsWithStatus();

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
                authenticationService.Logout(user.UserId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при выходе из формы:\n{ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateSeatColors();
        }

        private void btnInfoUser_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Пользователь: {user.FullName}.\nРоль: {user.UserRole}.",
                    "Информация по пользователю",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFindFreeSeat_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new FindFreeSeatForm())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var seats = operatorService.FindFreeSeat(dialog.Result);

                        using (var showFreeSeat = new FreeSeatsForm(seats, dialog.Result))
                        {
                            showFreeSeat.ShowDialog();
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

        private void btnOpenSession_Click(object sender, EventArgs e)
        {
            try
            {
                using (var inputDialog = new OpenSessionForm(seatRepository, tariffRepository, sessionRepository))
                {
                    if (inputDialog.ShowDialog() == DialogResult.OK)
                    {
                        operatorService.OpenSession(inputDialog.SelectedSeatId, user.UserId, inputDialog.SelectedTariff, inputDialog.StartTime,
                        inputDialog.StartTime.AddHours(inputDialog.Hours));
                        UpdateSeatColors();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия сессии: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseSession_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new InputDialog("Введите номер ПК для закрытия сессии:", "Закрытие сессии"))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!int.TryParse(dialog.Result, out int seatId))
                        {
                            MessageBox.Show("Введите корректный номер ПК (целое число).", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (seatId < 1 || seatId > 35)
                        {
                            MessageBox.Show($"ПК #{seatId} не существует. Доступны номера 1-35.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var activeSession = operatorService.GetActiveSessionBySeatId(seatId);

                        if (activeSession == null)
                        {
                            MessageBox.Show($"На ПК #{seatId} нет активной сессии.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var confirmResult = MessageBox.Show(
                            $"Закрыть сессию на ПК #{seatId}?\n\n" +
                            $"Начало: {activeSession.StartTime:dd.MM.yyyy HH:mm}\n" +
                            $"Окончание: {activeSession.EndTime:dd.MM.yyyy HH:mm}\n" +
                            $"Тариф: {(activeSession.Tariff == TariffType.Day ? "Дневной" : "Ночной")}\n" +
                            $"Сумма: {activeSession.TotalAmount} руб",
                            "Подтверждение закрытия",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (confirmResult == DialogResult.Yes)
                        {
                            operatorService.CloseSession(activeSession.SessionId);
                            UpdateSeatColors();

                            MessageBox.Show($"Сессия на ПК #{seatId} успешно закрыта.", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при закрытии сессии: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddHours_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new AddHoursForm(operatorService))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        operatorService.AddHours(form.SessionId, form.AdditionalHours);
                        UpdateSeatColors();

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
                MessageBox.Show($"Ошибка при открытии формы выручки: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            try
            {
                decimal dayPrice = administratorService.GetTariffPrice(TariffType.Day);
                decimal nightPrice = administratorService.GetTariffPrice(TariffType.Night);

                using (var form = new TariffForm(administratorService, dayPrice, nightPrice))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        UpdateSeatColors();
                        lblStatus.Text = "Тарифы обновлены";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии панели администратора: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button? clickedButton = sender as Button;
                if (clickedButton == null)
                    return;

                string text = clickedButton.Text;
                int seatId = 0;

                var match = Regex.Match(text, @"\d+");
                if (match.Success)
                {
                    seatId = int.Parse(match.Value);
                }

                if (seatId == 0)
                    return;

                var seats = operatorService.GetAllSeatsWithStatus();

                var seat = seats.FirstOrDefault(s => s.SeatId == seatId);
                if (seat != null)
                {
                    var activeSession = operatorService.GetActiveSessionBySeatId(seatId);
                    string status = "";

                    if (activeSession != null)
                    {
                        var remaining = activeSession.EndTime - DateTime.Now;
                        status = activeSession.EndTime > DateTime.Now
                            ? $"Занят до {activeSession.EndTime:HH:mm} (осталось {remaining.Hours}ч {remaining.Minutes}мин)"
                            : "Свободен";
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
                MessageBox.Show($"Ошибка при получении информации о ПК: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}