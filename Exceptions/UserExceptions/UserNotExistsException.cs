using FreshMarket.Dtos;
using FreshMarket.Models;

namespace FreshMarket.Exceptions.UserExceptions
{
    public class UserNotExistsException : Exception
    {
        private readonly User? _user;
        public UserNotExistsException() : base($"Cannot find the specified user")
        {
        }

        public UserNotExistsException(UserDto userDto)
            : base($"Cannot find the user with the Id: {userDto.Id}")
        {
        }

        public UserNotExistsException(User user)
            : base($"Cannot find the user with Id: {user.Id}")
        {
            _user = user;
        }

        public User? GetConflictingUser()
        {
            return _user;
        }
    }
}
