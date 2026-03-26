using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public class Session
    {
        public int SessionId { get; set; }
        public int SeatId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TariffType Tariff { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
