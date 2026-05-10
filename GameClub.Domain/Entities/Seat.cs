using GameClub.Domain.Enums;
using LinqToDB.Mapping;

namespace GameClub.Domain.Entities
{
    [Table(Name = "Seats")]
    public class Seat
    {
        [Column(Name = "SeatId", IsPrimaryKey = true, IsIdentity = true)]
        public int SeatId { get; set; }

        [Column(Name = "SeatRoom")]
        public string SeatRoom { get; set; }

        [Column(Name = "Hardware")]
        public string Hardware { get; set; }

        [Column(Name = "Devices")]
        public string Devices { get; set; }

        [Column(Name = "Status")]
        public int StatusValue { get; set; }

        public SeatStatus Status
        {
            get => (SeatStatus)StatusValue;
            set => StatusValue = (int)value;
        }
    }
}

