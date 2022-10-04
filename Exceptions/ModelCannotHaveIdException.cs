namespace FreshMarket.Exceptions
{
    public class ModelCannotHaveIdException :Exception
    {
        private readonly object? _object;

        public ModelCannotHaveIdException()
        {
        }

        public ModelCannotHaveIdException(object obj) 
            : base($"{obj.GetType().ToString().Split('.').Last()} cannot have an Id")
        {
            _object = obj;
        }

        public object? GetConflictingObject()
        {
            return _object;
        }
    }
}
