using LinqToDB.Mapping;

namespace GameClub.Domain.Entities
{
    [Table(Name = "Sessions")]
    public class Session
    {
        [Column(Name = "SessionId", IsPrimaryKey = true, IsIdentity = true)]
        public int SessionId { get; set; }

        [Column(Name = "SeatId")]
        public int SeatId { get; set; }

        [Column(Name = "UserId")]
        public int UserId { get; set; }

        [Column(Name = "TariffId")]
        public int TariffId { get; set; }

        [Column(Name = "StartTime")]
        public DateTime StartTime { get; set; }

        [Column(Name = "EndTime")]
        public DateTime EndTime { get; set; }

        [Column(Name = "TotalAmount")]
        public decimal TotalAmount { get; set; }

        [Association(ThisKey = "SeatId", OtherKey = "SeatId", CanBeNull = false)]
        public Seat Seat { get; set; }
        [Association(ThisKey = "UserId", OtherKey = "UserId", CanBeNull = false)]
        public User User { get; set; }
        [Association(ThisKey = "TariffId", OtherKey = "TariffId", CanBeNull = false)]
        public TariffSetting TariffSetting { get; set; }
    }
}

