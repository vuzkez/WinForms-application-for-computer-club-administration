using System;
using GameClub.Domain.Enums;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления формы открытия новой сессии
    /// </summary>
    public interface IOpenSessionView
    {
        /// <summary>
        /// Свойства для получения данных из формы
        /// </summary>
        int SelectedSeatId { get; }
        TariffType SelectedTariff { get; }
        DateTime StartTime { get; }
        int Hours { get; }
        string SeatIdText { get; }
        bool IsSeatPreselected { get; }
        bool IsDayTariffSelected { get; }
        bool IsNightTariffSelected { get; }
        string HoursText { get; }

        /// <summary>
        /// Событие подтверждения открытия сессии
        /// </summary>
        event EventHandler ConfirmOpen;

        /// <summary>
        /// Событие загрузки формы
        /// </summary>
        event EventHandler FormLoaded;

        /// <summary>
        /// Установка текста для дневного тарифа
        /// </summary>
        /// <param name="text">Текст с ценой дневного тарифа</param>
        void SetDayTariffLabel(string text);

        /// <summary>
        /// Установка текста для ночного тарифа
        /// </summary>
        /// <param name="text">Текст с ценой ночного тарифа</param>
        void SetNightTariffLabel(string text);

        /// <summary>
        /// Установка текущей даты и времени
        /// </summary>
        /// <param name="text">Текст с текущей датой и временем</param>
        void SetCurrentDateTime(string text);

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        void ShowError(string message);

        /// <summary>
        /// Закрытие формы
        /// </summary>
        void Close();

        /// <summary>
        /// Закрытие формы с положительным результатом
        /// </summary>
        void CloseWithOk();
    }
}