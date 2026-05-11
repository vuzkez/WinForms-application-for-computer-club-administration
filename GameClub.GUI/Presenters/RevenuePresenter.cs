using System;
using GameClub.GUI.ViewInterfaces;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    /// <summary>
    /// Презентер формы отчёта по выручке
    /// </summary>
    public class RevenuePresenter
    {
        /// <summary>
        /// Поля для хранения представления и сервиса администратора
        /// </summary>
        private readonly IRevenueView view;
        private readonly IAdministrator administrationService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="view">Отображение</param>
        /// <param name="administrationService">Сервис администратора</param>
        public RevenuePresenter(IRevenueView view, IAdministrator administrationService)
        {
            this.view = view;
            this.administrationService = administrationService;

            this.view.ShowRevenue += ShowRevenue;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Показать"
        /// Получает выручку за выбранный период и отображает результат
        /// </summary>
        private async void ShowRevenue(object sender, EventArgs e)
        {
            try
            {
                DateTime from = view.From;
                DateTime to = view.To;

                decimal revenue = await administrationService.GetRevenueAsync(from, to);

                view.Revenue = $"{revenue} руб";
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка при получении выручки: {ex.Message}");
            }
        }
    }
}