using LinqToDB.Mapping;

namespace GameClub.Domain.Entities
{
    /// <summary>
    /// Сущность "Сессия"
    /// </summary>
    [Table(Name = "Sessions")]
    public class Session
    {
        /// <summary>
        /// Идентификатор сессии
        /// </summary>
        [Column(Name = "SessionId", IsPrimaryKey = true, IsIdentity = true)]
        public int SessionId { get; set; }

        /// <summary>
        /// Идентификатор места
        /// </summary>
        [Column(Name = "SeatId")]
        public int SeatId { get; set; }

        /// <summary>
        /// Идентификатор оператора, открывшего сессию
        /// </summary>
        [Column(Name = "UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор тарифа
        /// </summary>
        [Column(Name = "TariffId")]
        public int TariffId { get; set; }

        /// <summary>
        /// Время начала сессии
        /// </summary>
        [Column(Name = "StartTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Время окончания сессии
        /// </summary>
        [Column(Name = "EndTime")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Итоговая сумма
        /// </summary>
        [Column(Name = "TotalAmount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Связанное место
        /// </summary>
        [Association(ThisKey = "SeatId", OtherKey = "SeatId", CanBeNull = false)]
        public Seat Seat { get; set; }

        /// <summary>
        /// Связанный пользователь
        /// </summary>
        [Association(ThisKey = "UserId", OtherKey = "UserId", CanBeNull = false)]
        public User User { get; set; }

        /// <summary>
        /// Связанный тариф
        /// </summary>
        [Association(ThisKey = "TariffId", OtherKey = "TariffId", CanBeNull = false)]
        public TariffSetting TariffSetting { get; set; }
    }
}