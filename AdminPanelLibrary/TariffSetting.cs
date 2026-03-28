using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace AdminPanelLibrary
{
    [Table(Name = "TariffSettings")]
    public class TariffSetting
    {
        [Column(Name = "Type", IsPrimaryKey = true)]
        public TariffType Type { get; set; }

        [Column(Name = "PricePerHour")]
        public decimal PricePerHour { get; set; }
    }
}
