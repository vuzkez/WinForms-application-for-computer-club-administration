using System;
using GameClub.GUI.ViewInterfaces;

namespace GameClub.GUI.Presenters
{
    /// <summary>
    /// Презентер формы выбора типа зала для поиска свободных мест
    /// </summary>
    public class FindFreeSeatPresenter
    {
        /// <summary>
        /// Поле для хранения представления
        /// </summary>
        private readonly IFindFreeSeatView view;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="view">Отображение</param>
        public FindFreeSeatPresenter(IFindFreeSeatView view)
        {
            this.view = view;
            this.view.ConfirmSelection += OnConfirmSelection;
        }

        /// <summary>
        /// Обработчик нажатия кнопки подтверждения выбора типа зала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConfirmSelection(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(view.Result))
            {
                view.ShowError("Выберите тип зала!");
                return;
            }

            view.CloseWithOk();
        }
    }
}