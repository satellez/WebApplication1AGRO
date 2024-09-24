using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class OffersRepository : IOffersRepository
    {
        private readonly AgroDbContext _context;

        public OffersRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateOffersAsync(Offers offers)
        {
            _context.Offers.Add(offers);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Offers>> GetAllOffersAsync()
        {
            return await _context.Offers
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Offers?> GetOffersByIdAsync(int id)
        {
            return await _context.Offers
                .FirstOrDefaultAsync(s => s.Offer_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteOffersAsync(int id)
        {
            var offers = await _context.Offers.FindAsync(id);
            if (offers != null)
            {
                offers.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateOffersAsync(Offers offers)
        {
            _context.Offers.Update(offers);
            await _context.SaveChangesAsync();
        }
    }
}