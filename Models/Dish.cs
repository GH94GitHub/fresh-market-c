using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace FreshMarket.Models
{
    public class Dish
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<Allergy> Allergies { get; set; }

        [JsonIgnore]
        public ICollection<User> UsersWhoPreferred { get; set; }

        [Column("calorie_amount")]
        public int CalorieAmount { get; set; }

        [Column("imgUrl")]
        public string ImgUrl { get; set; }

        public Dish()
        {
            Allergies = new List<Allergy>();
            UsersWhoPreferred = new List<User>();
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(Allergies)}: {Allergies}, {nameof(CalorieAmount)}: {CalorieAmount}, {nameof(ImgUrl)}: {ImgUrl}";
        }
    }
}
