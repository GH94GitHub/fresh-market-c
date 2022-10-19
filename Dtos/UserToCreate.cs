using FreshMarket.Models;
using Microsoft.Build.Framework;

namespace FreshMarket.Dtos
{
    public class UserToCreate
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Subscription? Subscription { get; set; }

        public List<Dish>? DishPreferences { get; set; }

        [Required]
        public string Address { get; set; }

        public string? PhoneNumber { get; set; }

        public List<Allergy>? Allergies { get; set; }

        public bool? SubscriptionActive { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Password)}: {Password}, {nameof(Email)}: {Email}, {nameof(Subscription)}: {Subscription}, {nameof(DishPreferences)}: {DishPreferences}, {nameof(Address)}: {Address}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(Allergies)}: {Allergies}, {nameof(SubscriptionActive)}: {SubscriptionActive}";
        }
    }
}
