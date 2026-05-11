using System;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления формы отчёта по выручке
    /// </summary>
    public interface IRevenueView
    {
        /// <summary>
        /// Событие запроса на отображение выручки
        /// </summary>
        event EventHandler ShowRevenue;

        /// <summary>
        /// Свойства для получения выбранного периода
        /// </summary>
        DateTime From { get; }
        DateTime To { get; }

        /// <summary>
        /// Свойство для отображения суммы выручки
        /// </summary>
        string Revenue { get; set; }

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        void ShowError(string message);
    }
}