using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public class TariffSetting
    {
        public TariffType Type {  get; set; }
        public decimal PricePerHour { get; set; }
    }
}
