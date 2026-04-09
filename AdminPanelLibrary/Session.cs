using LinqToDB.Mapping;

namespace AdminPanelLibrary
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

        [Column(Name = "Tariff")]
        private string TariffValue { get; set; }

        public TariffType Tariff
        {
            get => Enum.Parse<TariffType>(TariffValue);
            set => TariffValue = value.ToString();
        }

        [Column(Name = "StartTime")]
        public DateTime StartTime { get; set; }

        [Column(Name = "EndTime")]
        public DateTime EndTime { get; set; }

        [Column(Name = "TotalAmount")]
        public decimal TotalAmount { get; set; }
    }
}
