using GameClub.Library.Enums;
using LinqToDB.Mapping;

namespace GameClub.Library.Entities
{
    [Table(Name = "TariffSettings")]
    public class TariffSetting
    {
        [Column(Name = "Type", IsPrimaryKey = true)]
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
