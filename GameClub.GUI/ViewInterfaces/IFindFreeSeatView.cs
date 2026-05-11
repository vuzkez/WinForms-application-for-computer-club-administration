using System;

namespace GameClub.GUI.ViewInterfaces
{
    /// <summary>
    /// Интерфейс представления формы выбора типа зала для поиска свободных мест
    /// </summary>
    public interface IFindFreeSeatView
    {
        /// <summary>
        /// Свойство для получения выбранного типа зала General / Vip
        /// </summary>
        string Result { get; }

        /// <summary>
        /// Событие подтверждения выбора типа зала
        /// </summary>
        event EventHandler ConfirmSelection;

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        void ShowError(string message);

        /// <summary>
        /// Закрытие формы с положительным результатом
        /// </summary>
        void CloseWithOk();
    }
}