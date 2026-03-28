using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace AdminPanelLibrary
{
    [Table(Name = "Seats")]
    public class Seat
    {
        [Column(Name = "SeatId", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SeatId { get; set; }

        [Column(Name = "SeatRoom")]
        public string SeatRoom { get; set; }

        [Column(Name = "Hardware")]
        public string Hardware { get; set; }

        [Column(Name = "Devices")]
        public string Devices { get; set; }

        [Column(Name = "Status")]
        public SeatStatus Status { get; set; }
    }
}
