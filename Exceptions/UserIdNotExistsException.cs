namespace FreshMarket.Exceptions
{
    public class UserIdNotExistsException :Exception
    {
        private readonly int? _userId;
        public UserIdNotExistsException()
        {
        }

        public UserIdNotExistsException(int id) 
            : base($"The user with the Id: {id} does not exist")
        {
            _userId = id;
        }

        public int? GetConflictingUserId()
        {
            return _userId;
        }
    }
}
