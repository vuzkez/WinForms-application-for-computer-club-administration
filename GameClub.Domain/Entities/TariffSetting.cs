using GameClub.Domain.Enums;
using LinqToDB.Mapping;

namespace GameClub.Domain.Entities
{
    /// <summary>
    /// Сущность "Тариф"
    /// </summary>
    [Table(Name = "TariffSettings")]
    public class TariffSetting
    {
        /// <summary>
        /// Идентификатор тарифа
        /// </summary>
        [Column(Name = "TariffId", IsPrimaryKey = true, IsIdentity = true)]
        public int TariffId { get; set; }

        /// <summary>
        /// Строковое значение типа тарифа для маппинга в БД
        /// </summary>
        [Column(Name = "Type")]
        public string TypeValue { get; set; }

        /// <summary>
        /// Тип тарифа
        /// </summary>
        public TariffType Type
        {
            get => Enum.Parse<TariffType>(TypeValue);
            set => TypeValue = value.ToString();
        }

        /// <summary>
        /// Цена за час
        /// </summary>
        [Column(Name = "PricePerHour")]
        public decimal PricePerHour { get; set; }
    }
}