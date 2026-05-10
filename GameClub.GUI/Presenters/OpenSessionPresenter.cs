using System;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Enums;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    public class OpenSessionPresenter
    {
        private readonly IOpenSessionView view;
        private readonly IOperator operatorService;
        private readonly IAdministrator adminService;

        public OpenSessionPresenter(IOpenSessionView view, IOperator operatorService, IAdministrator adminService)
        {
            this.view = view;
            this.operatorService = operatorService;
            this.adminService = adminService;

            this.view.FormLoaded += OnFormLoaded;
            this.view.ConfirmOpen += OnConfirmOpen;
        }

        private async void OnFormLoaded(object sender, EventArgs e)
        {
            try
            {
                decimal dayPrice = await adminService.GetTariffPriceAsync(TariffType.Day);
                decimal nightPrice = await adminService.GetTariffPriceAsync(TariffType.Night);

                view.SetDayTariffLabel($"Дневной ({dayPrice} руб/ч)");
                view.SetNightTariffLabel($"Ночной ({nightPrice} руб/ч)");
                view.SetCurrentDateTime(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка загрузки тарифов: {ex.Message}");
                view.Close();
            }
        }

        private async void OnConfirmOpen(object sender, EventArgs e)
        {
            try
            {
                int seatId;

                if (view.IsSeatPreselected)
                {
                    seatId = view.SelectedSeatId;
                }
                else
                {
                    if (!int.TryParse(view.SeatIdText, out seatId) || seatId <= 0 || seatId > 35)
                    {
                        view.ShowError("Введите корректный номер места (1-35)");
                        return;
                    }
                }

                if (!view.IsDayTariffSelected && !view.IsNightTariffSelected)
                {
                    view.ShowError("Выберите тариф!");
                    return;
                }

                if (!int.TryParse(view.HoursText, out int hours) || hours <= 0)
                {
                    view.ShowError("Введите количество часов (>0)");
                    return;
                }

                var seats = await operatorService.GetAllSeatsWithStatusAsync();
                var seat = System.Linq.Enumerable.FirstOrDefault(seats, s => s.SeatId == seatId);

                if (seat == null)
                {
                    view.ShowError($"Место #{seatId} не найдено!");
                    return;
                }

                var activeSession = await operatorService.GetActiveSessionBySeatIdAsync(seatId);
                if (activeSession != null)
                {
                    view.ShowError($"Место #{seatId} уже занято до {activeSession.EndTime:HH:mm}");
                    return;
                }

                view.CloseWithOk();
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }
    }
}
