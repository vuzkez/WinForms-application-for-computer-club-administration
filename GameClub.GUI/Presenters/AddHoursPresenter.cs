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
    public class AddHoursPresenter
    {
        private readonly IAddHoursView view;
        private readonly IOperator operatorService;

        private List<Seat> activeSeats;
        private Dictionary<int, Session> sessionsBySeat;

        public AddHoursPresenter(IAddHoursView view, IOperator operatorService)
        {
            this.view = view;
            this.operatorService = operatorService;

            this.view.SeatSelectionChanged += OnSeatSelectionChanged;
            this.view.ConfirmAddHours += OnConfirmAddHours;

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
