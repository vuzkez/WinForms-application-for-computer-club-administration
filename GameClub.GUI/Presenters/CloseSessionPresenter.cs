using System;
using System.Collections.Generic;
using System.Linq;
using GameClub.GUI.ViewInterfaces;
using GameClub.Library.Entities;
using GameClub.Library.Enums;
using GameClub.Library.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    public class CloseSessionPresenter
    {
        private readonly ICloseSessionView view;
        private readonly IOperator operatorService;

        private List<Seat> activeSeats;
        private Dictionary<int, Session> sessionsBySeat;

        public CloseSessionPresenter(ICloseSessionView view, IOperator operatorService)
        {
            this.view = view;
            this.operatorService = operatorService;

            this.view.SeatSelectionChanged += OnSeatSelectionChanged;
            this.view.ConfirmClose += OnConfirmClose;

            LoadActiveSeatsAsync();
        }

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

                var items = activeSeats.Select(seat => (object)new
                {
                    Text = $"Место #{seat.SeatId} — {seat.SeatRoom}",
                    Value = seat.SeatId
                }).ToList();

                view.LoadActiveSeats(items);
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка загрузки: {ex.Message}");
                view.Close();
            }
        }

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
