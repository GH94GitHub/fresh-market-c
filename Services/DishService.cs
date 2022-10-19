using FreshMarket.Data;
using FreshMarket.Exceptions;
using FreshMarket.Models;

namespace FreshMarket.Services
{
    public class DishService
    {
        private readonly ApplicationDbContext _context;

        public DishService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all dishes as an array
        /// </summary>
        public Dish[] GetAllDishes()
        {
            return _context.dishes.ToArray();
        }

        /// <summary>
        /// Gets a dish by the id
        /// </summary>
        /// <exception cref="NotFoundException{Dish}"></exception>
        public async Task<Dish> GetDish(int id)
        {
            var dish = await _context.dishes.FindAsync(id);

            return dish ?? throw new NotFoundException<Dish>(id);
        } 
    }
}
