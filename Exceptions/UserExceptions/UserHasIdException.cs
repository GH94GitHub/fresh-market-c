using FreshMarket.Models;

namespace FreshMarket.Exceptions.UserExceptions
{
    public class UserHasIdException : Exception
    {
        private readonly User? _user;

        public UserHasIdException()
        {
        }

        public UserHasIdException(User conflictingUser)
            : base($"The _user has an id of {conflictingUser.Id}")
        {
            _user = conflictingUser;
        }

        public User? GetConflictingUser()
        {
            return _user;
        }
    }
}
