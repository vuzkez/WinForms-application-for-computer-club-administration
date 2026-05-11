using System;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Enums;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    /// <summary>
    /// Презентер формы настройки тарифов
    /// </summary>
    public class TariffPresenter
    {
        /// <summary>
        /// Поля для хранения представления и сервиса администратора
        /// </summary>
        private readonly ITariffView view;
        private readonly IAdministrator adminService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="view">Отображение</param>
        /// <param name="adminService">Сервис администратора</param>
        public TariffPresenter(ITariffView view, IAdministrator adminService)
        {
            this.view = view;
            this.adminService = adminService;

            this.view.SaveRequested += OnSaveRequested;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// Проверяет цены и сохраняет новые тарифы в базу данных
        /// </summary>
        private async void OnSaveRequested(object sender, EventArgs e)
        {
            try
            {
                decimal newDayPrice = view.DayPrice;
                decimal newNightPrice = view.NightPrice;

                if (newDayPrice <= 0 || newNightPrice <= 0)
                {
                    view.ShowError("Цены должны быть больше нуля.");
                    return;
                }

                await adminService.ConfigureTariffAsync(TariffType.Day, newDayPrice);
                await adminService.ConfigureTariffAsync(TariffType.Night, newNightPrice);

                view.ShowInfo("Тарифы сохранены!");
                view.CloseWithOk();
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка: {ex.Message}");
            }
        }
    }
}