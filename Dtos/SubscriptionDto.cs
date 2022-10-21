using System.ComponentModel.DataAnnotations;

namespace FreshMarket.Dtos
{
    public class SubscriptionDto
    {
        public int Id { get; set; }

        // 1:1 Tier
        [Required]
        public int TierId { get; set; }

        // 1:1 User
        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(ExpirationDate)}: {ExpirationDate}, {nameof(TierId)}: {TierId}, {nameof(UserId)}: {UserId}";
        }
    }
}
