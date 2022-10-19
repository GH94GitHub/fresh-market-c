using System.ComponentModel.DataAnnotations;
using FreshMarket.Models;

namespace FreshMarket.Dtos
{
    /// <summary>
    /// Contains all fields related to user personal information only
    /// </summary>
    public class PartialUser
    {
        [Required]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Email)}: {Email}, {nameof(Address)}: {Address}, {nameof(PhoneNumber)}: {PhoneNumber}";
        }
    }
}
