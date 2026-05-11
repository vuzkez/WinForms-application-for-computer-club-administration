using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Entities;
using GameClub.Domain.Enums;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    /// <summary>
    /// Главный презентер приложения
    /// Управляет картой мест, поиском, открытием/закрытием сессий,
    /// добавлением часов, выручкой, тарифами и операторами
    /// </summary>
    public class MainPresenter
    {
        /// <summary>
        /// Поля для хранения представления и текущего пользователя
        /// </summary>
        private readonly IMainView view;
        private readonly User user;

        /// <summary>
        /// Поля для хранения сервисов оператора и администратора
        /// </summary>
        private readonly IOperator operatorService;
        private readonly IAdministrator administratorService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="view">Отображение главной формы</param>
        /// <param name="user">Авторизованный пользователь</param>
        /// <param name="operatorService">Сервис оператора</param>
        /// <param name="administratorService">Сервис администратора</param>
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

        /// <summary>
        /// Настройка интерфейса в зависимости от роли пользователя
        /// </summary>
        private void ConfigureUIByRole()
        {
            view.SetTitle($"CyberX - Пользователь: {user.FullName}. Роль: {user.UserRole}.");
            view.ShowAdminButtons(user.UserRole == UserRole.Administrator);
        }

        /// <summary>
        /// Обновление цветов всех мест на карте
        /// </summary>
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

        /// <summary>
        /// Получение цвета места в зависимости от его статуса
        /// </summary>
        /// <param name="seat">Место</param>
        /// <returns>Цвет: зелёный — свободно, жёлтый — истекает, красный — занято, серый — неизвестно</returns>
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

        /// <summary>
        /// Обработчик кнопки поиска свободного места
        /// Выбор зала - список свободных мест - открытие сессии
        /// </summary>
        private async void OnFindFreeSeat(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new Views.FindFreeSeatForm())
                {
                    var p = new FindFreeSeatPresenter(dialog);
                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;

                    string roomType = dialog.Result;
                    var seats = await operatorService.FindFreeSeatsAsync(roomType);

                    using (var freeSeatsForm = new Views.FreeSeatsForm(seats, roomType))
                    {
                        var p2 = new FreeSeatsPresenter(freeSeatsForm, seats, roomType);
                        if (freeSeatsForm.ShowDialog() != DialogResult.OK
                            || freeSeatsForm.SelectedSeat == null)
                            return;

                        int seatId = freeSeatsForm.SelectedSeat.SeatId;

                        using (var openForm = new Views.OpenSessionForm())
                        {
                            openForm.SetPreselectedSeat(seatId);
                            var p3 = new OpenSessionPresenter(openForm, operatorService, administratorService);
                            if (openForm.ShowDialog() == DialogResult.OK)
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

        /// <summary>
        /// Обработчик кнопки закрытия активной сессии
        /// </summary>
        private async void OnCloseSession(object sender, EventArgs e)
        {
            try
            {
                using (var form = new Views.CloseSessionForm())
                {
                    var p = new CloseSessionPresenter(form, operatorService);
                    if (form.ShowDialog() == DialogResult.OK)
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

        /// <summary>
        /// Обработчик кнопки добавления часов к активной сессии
        /// </summary>
        private async void OnAddHours(object sender, EventArgs e)
        {
            try
            {
                using (var form = new Views.AddHoursForm())
                {
                    var p = new AddHoursPresenter(form, operatorService);
                    if (form.ShowDialog() == DialogResult.OK)
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

        /// <summary>
        /// Обработчик кнопки настройки тарифов 
        /// </summary>
        private async void OnAdminPanel(object sender, EventArgs e)
        {
            try
            {
                decimal dayPrice = await administratorService.GetTariffPriceAsync(TariffType.Day);
                decimal nightPrice = await administratorService.GetTariffPriceAsync(TariffType.Night);

                using (var form = new Views.TariffForm())
                {
                    form.SetPrices(dayPrice, nightPrice);
                    var p = new TariffPresenter(form, administratorService);
                    if (form.ShowDialog() == DialogResult.OK)
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

        /// <summary>
        /// Обработчик кнопки управления операторами
        /// </summary>
        private void OnManageOperators(object sender, EventArgs e)
        {
            try
            {
                using (var form = new Views.OperatorsForm())
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

        /// <summary>
        /// Обработчик кнопки просмотра выручки
        /// </summary>
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

        /// <summary>
        /// Обработчик нажатия на кнопку места на карте
        /// Показывает подробную информацию о ПК и активной сессии
        /// </summary>
        /// <param name="seatId">ID выбранного места</param>
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