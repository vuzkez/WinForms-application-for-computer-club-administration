using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace AdminPanelLibrary
{
    [Table(Name = "Sessions")]
    public class Session
    {
        [Column(Name = "SessionId", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SessionId { get; set; }

        [Column(Name = "SeatId")]
        public int SeatId { get; set; }

        [Column(Name = "UserId")]
        public int UserId { get; set; }

        [Column(Name = "Tariff")]
        public TariffType Tariff { get; set; }

        [Column(Name = "StartTime")]
        public DateTime StartTime { get; set; }

        [Column(Name = "EndTime")]
        public DateTime EndTime { get; set; }

        [Column(Name = "TotalAmount")]
        public decimal TotalAmount { get; set; }
    }
}
