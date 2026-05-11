using System;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления формы настройки тарифов
    /// </summary>
    public interface ITariffView
    {
        /// <summary>
        /// Свойства для получения новых цен тарифов
        /// </summary>
        decimal DayPrice { get; }
        decimal NightPrice { get; }

        /// <summary>
        /// Событие сохранения новых тарифов
        /// </summary>
        event EventHandler SaveRequested;

        /// <summary>
        /// Установка текущих цен тарифов при загрузке формы
        /// </summary>
        /// <param name="dayPrice">Цена дневного тарифа</param>
        /// <param name="nightPrice">Цена ночного тарифа</param>
        void SetPrices(decimal dayPrice, decimal nightPrice);

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        void ShowError(string message);

        /// <summary>
        /// Отображение информационного сообщения
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        void ShowInfo(string message);

        /// <summary>
        /// Закрытие формы с положительным результатом
        /// </summary>
        void CloseWithOk();
    }
}