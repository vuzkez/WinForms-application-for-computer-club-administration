using GameClub.BusinessLogic.ServiceInterfaces;
using GameClub.Domain.Entities;
using GameClub.Domain.Enums;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.DTO;
using GameClub.GUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameClub.GUI.Presenters
{
    /// <summary>
    /// Презентер формы закрытия активной сессии
    /// </summary>
    public class CloseSessionPresenter
    {
        /// <summary>
        /// Поля для хранения сервиса и представления
        /// </summary>
        private readonly ICloseSessionView view;
        private readonly IOperator operatorService;

        /// <summary>
        /// Поля для хранения списка активных мест и словаря, где
        /// Активная сессия - id места
        /// </summary>
        private List<Seat> activeSeats;
        private Dictionary<int, Session> sessionsBySeat;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="view">Отображение</param>
        /// <param name="operatorService">Сервис</param>
        public CloseSessionPresenter(ICloseSessionView view, IOperator operatorService)
        {
            this.view = view;
            this.operatorService = operatorService;

            this.view.SeatSelectionChanged += OnSeatSelectionChanged;
            this.view.ConfirmClose += OnConfirmClose;

            LoadActiveSeatsAsync();
        }

        /// <summary>
        /// Событие для загрузки активных мест и словаря
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
                        var totalHours = (firstSession.EndTime - firstSession.StartTime).TotalHours;
                        string tariffName = firstSession.TariffSetting.Type == TariffType.Day ? "Дневной" : "Ночной";

                        string info =
                            $"Место: #{firstSeat.SeatId} ({firstSeat.SeatRoom})\n" +
                            $"Начало: {firstSession.StartTime:dd.MM.yyyy HH:mm}\n" +
                            $"Конец: {firstSession.EndTime:dd.MM.yyyy HH:mm}\n" +
                            $"Всего часов: {totalHours:F1} ч\n" +
                            $"Осталось: {remaining.Hours}ч {remaining.Minutes}м\n" +
                            $"Тариф: {tariffName}\n" +
                            $"Сумма: {firstSession.TotalAmount:F2} руб";

                        view.UpdateSessionInfo(info);
                        view.SetSessionId(firstSession.SessionId);
                        view.SetSelectedSeatId(firstSeat.SeatId);
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
        /// Событие, которое получает выбранный id места и показывает информацию о сессии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSeatSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int seatId = view.SelectedComboSeatId;
                var seat = activeSeats?.FirstOrDefault(s => s.SeatId == seatId);
                var session = sessionsBySeat?.GetValueOrDefault(seatId);

                if (seat != null && session != null)
                {
                    var remaining = session.EndTime - DateTime.Now;
                    var totalHours = (session.EndTime - session.StartTime).TotalHours;
                    string tariffName = session.TariffSetting.Type == TariffType.Day ? "Дневной" : "Ночной";

                    string info =
                        $"Место: #{seat.SeatId} ({seat.SeatRoom})\n" +
                        $"Начало: {session.StartTime:dd.MM.yyyy HH:mm}\n" +
                        $"Конец: {session.EndTime:dd.MM.yyyy HH:mm}\n" +
                        $"Всего часов: {totalHours:F1} ч\n" +
                        $"Осталось: {remaining.Hours}ч {remaining.Minutes}м\n" +
                        $"Тариф: {tariffName}\n" +
                        $"Сумма: {session.TotalAmount:F2} руб";

                    view.UpdateSessionInfo(info);
                    view.SetSessionId(session.SessionId);
                    view.SetSelectedSeatId(seat.SeatId);
                }
                else
                {
                    view.UpdateSessionInfo("Нет данных о сессии");
                }
            }
            catch
            {
                view.UpdateSessionInfo("Ошибка загрузки данных");
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Закрыть сессию"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConfirmClose(object sender, EventArgs e)
        {
            try
            {
                int seatId = view.SelectedComboSeatId;
                var session = sessionsBySeat?.GetValueOrDefault(seatId);

                if (session == null)
                {
                    view.ShowError("Выберите место.");
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