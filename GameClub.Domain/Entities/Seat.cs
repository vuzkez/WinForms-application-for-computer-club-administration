using GameClub.Domain.Enums;
using LinqToDB.Mapping;

namespace GameClub.Domain.Entities
{
    /// <summary>
    /// Сущность "Место"
    /// </summary>
    [Table(Name = "Seats")]
    public class Seat
    {
        /// <summary>
        /// Идентификатор места
        /// </summary>
        [Column(Name = "SeatId", IsPrimaryKey = true, IsIdentity = true)]
        public int SeatId { get; set; }

        /// <summary>
        /// Тип зала
        /// </summary>
        [Column(Name = "SeatRoom")]
        public string SeatRoom { get; set; }

        /// <summary>
        /// Характеристики железа
        /// </summary>
        [Column(Name = "Hardware")]
        public string Hardware { get; set; }

        /// <summary>
        /// Периферийные устройства
        /// </summary>
        [Column(Name = "Devices")]
        public string Devices { get; set; }

        /// <summary>
        /// Значение статуса для маппинга в БД
        /// </summary>
        [Column(Name = "Status")]
        public int StatusValue { get; set; }

        /// <summary>
        /// Статус места
        /// </summary>
        public SeatStatus Status
        {
            get => (SeatStatus)StatusValue;
            set => StatusValue = (int)value;
        }
    }
}