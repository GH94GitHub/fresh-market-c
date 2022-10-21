using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace FreshMarket.Models
{
    public class Subscription
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("expiration_date")]
        public DateTime ExpirationDate { get; set; }

        // 1:1 Tier
        [Column("tier_id")]
        [JsonIgnore]
        public int TierId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Tier Tier { get; set; }

        // 1:1 User
        [Column("user_id")]
        [JsonIgnore]
        public int UserId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public User? User { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Tier)}: {Tier}, {nameof(ExpirationDate)}: {ExpirationDate}";
        }
    }
}
