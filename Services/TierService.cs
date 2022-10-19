using FreshMarket.Data;
using FreshMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Services
{
    public class TierService
    {
        private readonly ApplicationDbContext _context;

        public TierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Tier>> GetAllTiers()
        {
            return await _context.tiers.ToListAsync();
        }
    }
}
