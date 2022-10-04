using FreshMarket.Models;

namespace FreshMarket.Exceptions
{
    public class ProductNotExistsException : Exception
    {

        private readonly Product? _product;

        public ProductNotExistsException()
        {
        }

        public ProductNotExistsException(Product product) 
            : base($"Cannot find the product with Id: {product.Id}")
        {
            _product = product;
        }

        public Product? GetConflictingProduct()
        {
            return _product;
        }
    }
}
