using System.ComponentModel.DataAnnotations.Schema;

namespace FreshMarket.Models
{
    public class Tier
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("level")]
        public TierLevel Level { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("weekly_dish_count")] 
        public DishCount DishCount { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Level)}: {Level}, {nameof(Price)}: {Price}";
        }
    }
}
