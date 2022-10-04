using FreshMarket.Data;
using FreshMarket.Exceptions;
using FreshMarket.Exceptions.Postgres;
using FreshMarket.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FreshMarket.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all products as an array
        /// </summary>
        public async Task<Product[]> GetAllProducts()
        {
            return await _context.products.ToArrayAsync();
        }

        /// <summary>
        /// Retrieves a product by the id
        /// </summary>
        /// <exception cref="ProductNotExistsException"></exception>
        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            return product ?? throw new ProductNotExistsException(new() {Id = id});
        }

        /// <summary>
        /// Replaces entire resource
        /// </summary>
        /// <exception cref="ProductIdNotExistsException"></exception>
        /// <exception cref="UniqueViolationException"></exception>
        /// <exception cref="PostgresException"></exception>
        /// <exception cref="DbUpdateException"></exception>
        public async Task<Product> UpdateProduct(Product product)
        {
            var p = await _context.products.FindAsync(product.Id);
            if (p == null)
                throw new ProductIdNotExistsException(product.Id);

            try
            {
                _context.Entry(p).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException is PostgresException postgresException)
                    postgresException.HandleException<Product>();
                else
                {
                    Console.WriteLine(dbUpdateException);
                    throw dbUpdateException;
                }
            }

            return product;
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <exception cref="ModelCannotHaveIdException"></exception>
        /// <exception cref="PostgresException"></exception>
        /// <exception cref="UniqueViolationException"></exception>
        public async Task<Product> CreateProduct(Product product)
        {
            if (product.Id != 0)
                throw new ModelCannotHaveIdException(product);

            try
            {
                await _context.products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException is PostgresException postgresException)
                    postgresException.HandleException<Product>();
                else
                    throw dbUpdateException;

            }
            return product;
        }

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <exception cref="ProductIdNotExistsException"></exception>
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
                throw new ProductIdNotExistsException(id);

            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
