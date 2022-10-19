using System.ComponentModel.DataAnnotations;
using FreshMarket.Models;
using Newtonsoft.Json;

namespace FreshMarket.Dtos
{
    /// <summary>
    /// Contains all of the fields of <see cref="User"/> except for the password field.
    /// </summary>
    public class UserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Dish> DishPreferences { get; set; }

        public ICollection<Allergy> Allergies { get; set; }

        [Required]
        public Subscription Subscription { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public Payment Payment { get; set; }



        public UserDto()
        {
            FirstName = "";
            LastName = "";
        }

        /// <summary>
        /// Instantiates a UserDto from a User object
        /// </summary>
        public static UserDto valueOf(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Payment = user.Payment,
                PhoneNumber = user.PhoneNumber,
                Subscription = user.Subscription
            };
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Email)}: {Email}, {nameof(Subscription)}: {Subscription}, {nameof(Address)}: {Address}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(Payment)}: {Payment}";
        }
    }
}
