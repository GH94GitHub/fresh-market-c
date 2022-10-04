using FreshMarket.Dtos;
using Microsoft.AspNetCore.Mvc;
using FreshMarket.Exceptions;
using FreshMarket.Exceptions.Postgres;
using FreshMarket.Models;
using FreshMarket.Services;
using Npgsql;

namespace FreshMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService service)
        {
            _productService = service;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _productService.GetAllProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);
                return Ok(product);
            }
            catch (ProductNotExistsException ex)
            {
                Console.WriteLine(ex);
                return NotFound(ex.Message);
            }
        }

        //PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            try
            {
                return await _productService.UpdateProduct(productDto.ToProduct());
            }
            catch (ProductIdNotExistsException ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex) when(
                ex is PostgresException or UniqueViolationException
            )
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(Product product)
        {
            try
            {
                await _productService.CreateProduct(product);
            }
            catch (ModelCannotHaveIdException ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
            catch (UniqueViolationException uniqueViolation)
            {
                return BadRequest(uniqueViolation.Message);
            }

            return Ok(ProductDto.valueOf(product));
        }

        //// DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (ProductIdNotExistsException ex)
            {
                Console.WriteLine(ex);
                return NotFound(ex.Message);
            }
        }

    }
}
