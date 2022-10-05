namespace FreshMarket.Exceptions.Postgres
{
    public class UniqueViolationException : Exception
    {
        private readonly Type? _type;
        public UniqueViolationException()
        {
        }

        public UniqueViolationException(Type type, string field)
            : base($"The {type.Name} '{field}' must be unique")
        {
            _type = type;
        }
    }
}
