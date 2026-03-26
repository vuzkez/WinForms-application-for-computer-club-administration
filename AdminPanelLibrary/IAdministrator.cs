using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public interface IAdministrator
    {
        decimal GetRevenue();
        void ConfigureTariff(decimal newPrice);
    }
}
