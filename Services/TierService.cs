using FreshMarket.Data;
using FreshMarket.Models;

namespace FreshMarket.Services
{
    public class TierService
    {
        private readonly ApplicationDbContext _context;

        public TierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tier[] GetAllTiers()
        {
            return _context.tiers.ToArray();
        }
    }
}
