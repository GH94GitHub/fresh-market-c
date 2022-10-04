namespace FreshMarket.Exceptions
{
    public class ProductIdNotExistsException :Exception
    {
        private readonly int _productId;

        public ProductIdNotExistsException()
        {
        }

        public ProductIdNotExistsException(int id) 
            : base($"Product with the Id: {id} does not exist")
        {
            _productId = id;
        }

        public int GetConflictingProductId()
        {
            return _productId;
        }
    }
}
