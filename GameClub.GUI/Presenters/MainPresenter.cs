using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameClub.GUI.ViewInterfaces;
using GameClub.Library.Entities;
using GameClub.Library.Enums;
using GameClub.Library.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView view;
        private readonly User user;
        private readonly IOperator operatorService;
        private readonly IAdministrator administratorService;

        public MainPresenter(IMainView view, User user, IOperator operatorService, IAdministrator administratorService)
        {
            this.view = view;
            this.user = user;
            this.operatorService = operatorService;
            this.administratorService = administratorService;

            this.view.RefreshRequested += async (s, e) => await RefreshSeatsAsync();
            this.view.FindFreeSeatRequested += OnFindFreeSeat;
            this.view.CloseSessionRequested += OnCloseSession;
            this.view.AddHoursRequested += OnAddHours;
            this.view.RevenueRequested += OnRevenue;
            this.view.AdminPanelRequested += OnAdminPanel;
            this.view.ManageOperatorsRequested += OnManageOperators;
            this.view.SeatButtonClicked += OnSeatButtonClicked;

            ConfigureUIByRole();
            _ = RefreshSeatsAsync();
        }

        private void ConfigureUIByRole()
        {
            view.SetTitle($"CyberX - Пользователь: {user.FullName}. Роль: {user.UserRole}.");
            view.ShowAdminButtons(user.UserRole == UserRole.Administrator);
        }

        private async Task RefreshSeatsAsync()
        {
            try
            {
                var seats = await operatorService.GetAllSeatsWithStatusAsync();
                foreach (var seat in seats)
                {
                    view.SetSeatColor(seat.SeatId, GetColor(seat));
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка обновления: {ex.Message}");
            }
        }

        private Color GetColor(Seat seat)
        {
            switch (seat.Status)
            {
                case SeatStatus.Free:     return Color.Green;
                case SeatStatus.Expiring: return Color.Yellow;
                case SeatStatus.Busy:     return Color.Red;
                default:                  return Color.Gray;
            }
        }

        private async void OnFindFreeSeat(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new Views.FindFreeSeatForm())
                {
                    var p = new FindFreeSeatPresenter(dialog);
                    if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        return;

                    string roomType = dialog.Result;
                    var seats = await operatorService.FindFreeSeatsAsync(roomType);

                    using (var freeSeatsForm = new Views.FreeSeatsForm(seats, roomType))
                    {
                        var p2 = new FreeSeatsPresenter(freeSeatsForm, seats, roomType);
                        if (freeSeatsForm.ShowDialog() != System.Windows.Forms.DialogResult.OK
                            || freeSeatsForm.SelectedSeat == null)
                            return;

                        int seatId = freeSeatsForm.SelectedSeat.SeatId;

                        using (var openForm = new Views.OpenSessionForm(operatorService, administratorService, seatId))
                        {
                            var p3 = new OpenSessionPresenter(openForm, operatorService, administratorService);
                            if (openForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                await operatorService.OpenSessionAsync(
                                    openForm.SelectedSeatId,
                                    user.UserId,
                                    openForm.SelectedTariff,
                                    openForm.StartTime,
                                    openForm.StartTime.AddHours(openForm.Hours)
                                );
                                await RefreshSeatsAsync();
                                view.ShowInfo($"Сессия на месте #{openForm.SelectedSeatId} открыта.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }

        private async void OnCloseSession(object sender, EventArgs e)
        {
            try
            {
                using (var form = new Views.CloseSessionForm(operatorService))
                {
                    var p = new CloseSessionPresenter(form, operatorService);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        await operatorService.CloseSessionAsync(form.SessionId);
                        await RefreshSeatsAsync();
                        view.ShowInfo($"Сессия на месте #{form.SelectedSeatId} закрыта.");
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }

        private async void OnAddHours(object sender, EventArgs e)
        {
            try
            {
                using (var form = new Views.AddHoursForm(operatorService))
                {
                    var p = new AddHoursPresenter(form, operatorService);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        await operatorService.AddHoursAsync(form.SessionId, form.AdditionalHours);
                        await RefreshSeatsAsync();
                        view.ShowInfo($"Добавлено {form.AdditionalHours} ч. к месту #{form.SelectedSeatId}");
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }

        private void OnRevenue(object sender, EventArgs e)
        {
            try
            {
                using (var form = new Views.RevenueForm())
                {
                    var p = new RevenuePresenter(form, administratorService);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }

        private async void OnAdminPanel(object sender, EventArgs e)
        {
            try
            {
                decimal dayPrice = await administratorService.GetTariffPriceAsync(TariffType.Day);
                decimal nightPrice = await administratorService.GetTariffPriceAsync(TariffType.Night);

                using (var form = new Views.TariffForm(administratorService, dayPrice, nightPrice))
                {
                    var p = new TariffPresenter(form, administratorService);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        await RefreshSeatsAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }

        private void OnManageOperators(object sender, EventArgs e)
        {
            try
            {
                using (var form = new Views.OperatorsForm(administratorService))
                {
                    var p = new OperatorsPresenter(form, administratorService);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }

        private async void OnSeatButtonClicked(object sender, int seatId)
        {
            try
            {
                var seats = await operatorService.GetAllSeatsWithStatusAsync();
                var seat = seats.FirstOrDefault(s => s.SeatId == seatId);
                if (seat == null) return;

                var activeSession = await operatorService.GetActiveSessionBySeatIdAsync(seatId);
                string status;
                if (activeSession != null && activeSession.EndTime > DateTime.Now)
                {
                    var remaining = activeSession.EndTime - DateTime.Now;
                    status = $"Занято до {activeSession.EndTime:HH:mm} ({remaining.Hours}ч {remaining.Minutes}м)";
                }
                else
                {
                    status = "Свободно";
                }

                view.ShowInfo(
                    $"Место {seat.SeatId}\n" +
                    $"Зал: {seat.SeatRoom}\n" +
                    $"Железо: {seat.Hardware}\n" +
                    $"Устройства: {seat.Devices}\n" +
                    $"Статус: {status}"
                );
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }
    }
}
