using System;
using System.Linq;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Enums;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    /// <summary>
    /// Презентер формы открытия новой сессии
    /// </summary>
    public class OpenSessionPresenter
    {
        /// <summary>
        /// Поля для хранения представления и сервисов
        /// </summary>
        private readonly IOpenSessionView view;
        private readonly IOperator operatorService;
        private readonly IAdministrator adminService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="view">Отображение</param>
        /// <param name="operatorService">Сервис оператора</param>
        /// <param name="adminService">Сервис администратора</param>
        public OpenSessionPresenter(IOpenSessionView view, IOperator operatorService, IAdministrator adminService)
        {
            this.view = view;
            this.operatorService = operatorService;
            this.adminService = adminService;

            this.view.FormLoaded += OnFormLoaded;
            this.view.ConfirmOpen += OnConfirmOpen;
        }

        /// <summary>
        /// Событие загрузки формы
        /// Загружает цены дневного и ночного тарифов и отображает их
        /// </summary>
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

        /// <summary>
        /// Обработчик нажатия кнопки "Открыть сессию".
        /// Проверяет номер места, выбранный тариф, количество часов
        /// и отсутствие активной сессии на выбранном месте
        /// </summary>
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
                var seat = seats.FirstOrDefault(s => s.SeatId == seatId);

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