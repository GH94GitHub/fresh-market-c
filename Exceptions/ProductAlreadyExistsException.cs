using FreshMarket.Models;

namespace FreshMarket.Exceptions
{
    public class ProductAlreadyExistsException :Exception
    {
        private readonly Product? _product;

        public ProductAlreadyExistsException()
        {
        }

        public ProductAlreadyExistsException(Product product) 
            : base($"The product with Id: {product.Id} already exists")
        {
            _product = product;
        }

        public Product? GetConflictingProduct()
        {
            return _product;
        }
    }
}
