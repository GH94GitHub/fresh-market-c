namespace FreshMarket.Exceptions.Postgres
{
    public class UniqueViolationException : Exception
    {
        private readonly object? _obj;
        public UniqueViolationException()
        {
        }

        public UniqueViolationException(object obj, string field)
            : base($"The resource {field} must be unique")
        {
            _obj = obj;
        }

        public object? GetConflictingObject()
        {
            return _obj;
        }
    }
}
