using FreshMarket.Data;
using FreshMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Get(int userId)
        {
            return await _context.users
                .Where(u => u.Id == userId)
                .Include(u => u.Allergies)
                .Include(u => u.DishPreferences).ThenInclude(d => d.Allergies)
                .Include(u => u.Payment)
                .Include(u => u.Subscription.Tier)
                .FirstOrDefaultAsync();
        }
    }
}
