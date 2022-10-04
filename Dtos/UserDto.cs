using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FreshMarket.Models;

namespace FreshMarket.Dtos
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Column("age")]
        [Range(1, 150)]
        public int Age { get; set; }

        public UserDto()
        {
            Username = "";
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
                Age = user.Age,
                Username = user.Username
            };
        }

        public User ToUser()
        {
            return new User()
            {
                Id = this.Id,
                Username = this.Username,
                Password = "",
                FirstName = this.FirstName,
                LastName = this.LastName,
                Age = this.Age
            };
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Username)}: {Username}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Age)}: {Age}";
        }

    }
}
