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
            Allergies = new HashSet<Allergy>();
            DishPreferences = new HashSet<Dish>();
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Email)}: {Email}, {nameof(Password)}: {Password}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Subscription)}: {Subscription}, {nameof(DishPreferences)}: {DishPreferences}, {nameof(Address)}: {Address}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(Payment)}: {Payment}, {nameof(Allergies)}: {Allergies}";
        }

        public bool AddDishPreference(Dish dish)
        {
            var beforeCount = this.DishPreferences.Count;
            this.DishPreferences.Add(dish);

            return beforeCount != this.DishPreferences.Count;
        }
        public bool RemoveDishPreference(int dishId)
        {
            var beforeCount = this.DishPreferences.Count;
            for(var i = 0; i < this.DishPreferences.Count; i++)
            {
                if (this.DishPreferences.ElementAt(i).Id != dishId) continue;
                this.DishPreferences.Remove(this.DishPreferences.ElementAt(i));
                break;
            }

            return beforeCount != this.DishPreferences.Count;
        }

        protected bool Equals(User other)
        {
            return Id == other.Id && FirstName == other.FirstName && LastName == other.LastName && Password == other.Password && Email == other.Email && DishPreferences.Equals(other.DishPreferences) && Allergies.Equals(other.Allergies) && Subscription.Equals(other.Subscription) && Address == other.Address && PhoneNumber == other.PhoneNumber && Equals(Payment, other.Payment);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add(Password);
            hashCode.Add(Email);
            hashCode.Add(DishPreferences);
            hashCode.Add(Allergies);
            hashCode.Add(Subscription);
            hashCode.Add(Address);
            hashCode.Add(PhoneNumber);
            hashCode.Add(Payment);
            return hashCode.ToHashCode();
        }
    }
}
