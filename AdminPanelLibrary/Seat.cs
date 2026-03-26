using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string SeatRoom {  get; set; }
        public string Hardware { get; set; }
        public string Devices { get; set; }
        public SeatStatus Status { get; set; }
    }
}
