using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.GUI.ViewInterfaces;
using GameClub.Library.Entities;
using GameClub.Library.ServiceInterfaces;

namespace GameClub.GUI.Presenters
{
    public class RevenuePresenter
    {
        private readonly IRevenueView view;
        private readonly IAdministrator administrationService;

        public RevenuePresenter(IRevenueView view, IAdministrator administrationService)
        {
            this.view = view;
            this.administrationService = administrationService;

            this.view.ShowRevenue += ShowRevenue;
        }

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
