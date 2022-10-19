using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Models
{
    [Index("Email", IsUnique = true)]
    public class User
    {
        [Column("id")] 
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("email")]
        public string Email { get; set; }

        public ICollection<Dish> DishPreferences { get; set; }
        public ICollection<Allergy> Allergies { get; set; }
        public Subscription Subscription { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("payment")]
        public Payment? Payment { get; set; }




        public User()
        {
            LastName = "";
            Allergies = new List<Allergy>();
            DishPreferences = new List<Dish>();
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Email)}: {Email}, {nameof(Password)}: {Password}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Subscription)}: {Subscription}, {nameof(DishPreferences)}: {DishPreferences}, {nameof(Address)}: {Address}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(Payment)}: {Payment}, {nameof(Allergies)}: {Allergies}";
        }
    }
}
