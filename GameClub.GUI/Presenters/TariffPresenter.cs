using System;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Enums;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    public class TariffPresenter
    {
        private readonly ITariffView view;
        private readonly IAdministrator adminService;

        public TariffPresenter(ITariffView view, IAdministrator adminService)
        {
            this.view = view;
            this.adminService = adminService;

            this.view.SaveRequested += OnSaveRequested;
        }

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
