using GameClub.BusinessLogic.ServiceInterfaces;
using GameClub.Domain.Entities;
using GameClub.Domain.Enums;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameClub.GUI.Presenters
{
    /// <summary>
    /// Презентер формы добавления часов
    /// </summary>
    public class AddHoursPresenter
    {
        /// <summary>
        /// Поля для хранения сервиса и представления
        /// </summary>
        private readonly IAddHoursView view;
        private readonly IOperator operatorService;

        /// <summary>
        /// Поля для хранения списка активных мест и словарь, где
        /// Активная сессия - id места
        /// </summary>
        private List<Seat> activeSeats;
        private Dictionary<int, Session> sessionsBySeat;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="view">Отображение</param>
        /// <param name="operatorService">Сервис</param>
        public AddHoursPresenter(IAddHoursView view, IOperator operatorService)
        {
            this.view = view;
            this.operatorService = operatorService;

            this.view.SeatSelectionChanged += OnSeatSelectionChanged;
            this.view.ConfirmAddHours += OnConfirmAddHours;

            LoadActiveSeatsAsync();
        }

        /// <summary>
        /// Событие для загрузки свободных мест и словаря
        /// </summary>
        private async void LoadActiveSeatsAsync()
        {
            try
            {
                activeSeats = await operatorService.FindActiveSeatsAsync();

                if (activeSeats == null || activeSeats.Count == 0)
                {
                    view.SetNoActiveSeats();
                    return;
                }

                var sessionsWithDetails = await operatorService.GetActiveSessionsWithDetailsAsync();
                sessionsBySeat = sessionsWithDetails
                    .Where(s => s.SeatId > 0)
                    .ToDictionary(s => s.SeatId);

                var items = activeSeats.Select(seat => new ComboBoxItem
                {
                    Text = $"Место #{seat.SeatId} — {seat.SeatRoom}",
                    Value = seat.SeatId
                }).ToList();

                view.LoadActiveSeats(items);

               if (activeSeats.Count > 0 && sessionsBySeat.Count > 0)
                {
                    var firstSeat = activeSeats[0];
                    var firstSession = sessionsBySeat.GetValueOrDefault(firstSeat.SeatId);
                    if (firstSession != null)
                    {
                        var remaining = firstSession.EndTime - DateTime.Now;
                        string tariffName = firstSession.TariffSetting?.Type == TariffType.Day ? "Дневной" : "Ночной";

                        string info =
                            $"Активная сессия!\n" +
                            $"Место: #{firstSeat.SeatId} ({firstSeat.SeatRoom})\n" +
                            $"Статус: {(firstSeat.Status == SeatStatus.Expiring ? "Скоро истекает" : "Активен")}\n" +
                            $"Начало: {firstSession.StartTime:dd.MM.yyyy HH:mm}\n" +
                            $"Конец: {firstSession.EndTime:dd.MM.yyyy HH:mm}\n" +
                            $"Осталось: {remaining.Hours}ч {remaining.Minutes}м\n" +
                            $"Тариф: {tariffName}\n" +
                            $"Сумма: {firstSession.TotalAmount} руб";

                        view.UpdateSessionInfo(info, true);
                        view.SetSessionId(firstSession.SessionId);
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка загрузки: {ex.Message}");
                view.Close();
            }
        }

        /// <summary>
        /// Событие, которое получает выбранный id места и показывает информацию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSeatSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int seatId = view.SelectedComboSeatId;
                var seat = activeSeats.FirstOrDefault(s => s.SeatId == seatId);
                var session = sessionsBySeat.GetValueOrDefault(seatId);

                if (seat != null && session != null)
                {
                    var remaining = session.EndTime - DateTime.Now;
                    string tariffName = session.TariffSetting?.Type == TariffType.Day ? "Дневной" : "Ночной";

                    string info =
                        $"Активная сессия!\n" +
                        $"Место: #{seat.SeatId} ({seat.SeatRoom})\n" +
                        $"Статус: {(seat.Status == SeatStatus.Expiring ? "Скоро истекает" : "Активен")}\n" +
                        $"Начало: {session.StartTime:dd.MM.yyyy HH:mm}\n" +
                        $"Конец: {session.EndTime:dd.MM.yyyy HH:mm}\n" +
                        $"Осталось: {remaining.Hours}ч {remaining.Minutes}м\n" +
                        $"Тариф: {tariffName}\n" +
                        $"Сумма: {session.TotalAmount} руб";

                    view.UpdateSessionInfo(info, true);
                    view.SetSessionId(session.SessionId);
                }
                else
                {
                    view.UpdateSessionInfo("Нет данных о сессии", false);
                    view.SetSessionId(0);
                }
            }
            catch
            {
                view.UpdateSessionInfo("Ошибка загрузки данных", false);
                view.SetSessionId(0);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить часы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConfirmAddHours(object sender, EventArgs e)
        {
            try
            {
                if (view.SessionId == 0)
                {
                    view.ShowError("Выберите активную сессию.");
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
