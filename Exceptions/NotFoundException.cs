namespace FreshMarket.Exceptions
{
    public class NotFoundException<T> : Exception
    {

        private readonly T? _obj;
        public NotFoundException() :base($"The {typeof(T).Name} cannot be found")
        {
        }

        public NotFoundException(T? obj) 
            : base($"The {obj.GetType().Name}, cannot be found")
        {
            _obj = obj;
        }

        public NotFoundException(int id)
            : base($"The {typeof(T).Name} with Id: {id} cannot be found")
        {
        }

        public T? GetConflictingObject()
        {
            return _obj;
        }
    }
}
