using GameClub.Domain.Enums;
using LinqToDB.Mapping;

namespace GameClub.Domain.Entities
{
    [Table(Name = "TariffSettings")]
    public class TariffSetting
    {
        [Column(Name = "TariffId",IsPrimaryKey = true,IsIdentity = true)]
        public int TariffId { get; set; }
        [Column(Name = "Type")]
        public string TypeValue { get; set; }

        public TariffType Type
        {
            get => Enum.Parse<TariffType>(TypeValue);
            set => TypeValue = value.ToString();
        }

        [Column(Name = "PricePerHour")]
        public decimal PricePerHour { get; set; }
    }
}

