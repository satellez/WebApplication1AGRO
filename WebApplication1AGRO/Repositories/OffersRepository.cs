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
            var productDetails = await _context.ProductDetails
                .Include(pd => pd.Products)
                .ThenInclude(p => p.ProductCategories)
                .Include(pd => pd.Users)
                .ThenInclude(u => u.UserTypes)
                .Include(pd => pd.Users)
                .ThenInclude(u => u.Documents)
                .Include(pd => pd.Collections)
                .FirstOrDefaultAsync(pd => pd.ProdDeta_id == offers.ProdDeta_id);

            if (productDetails == null)
            {
                throw new Exception("Detalles del producto no encontrados.");
            }

            // Set relaciones
            offers.ProductDetails = productDetails;
            offers.IsDeleted = false;

            _context.Offers.Add(offers);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Offers>> GetAllOffersAsync()
        {
            return await _context.Offers
                .Where(o => !o.IsDeleted)
                .Include(o => o.ProductDetails)
                    .ThenInclude(pd => pd.Products)
                        .ThenInclude(p => p.ProductCategories)
                .Include(o => o.ProductDetails)
                    .ThenInclude(pd => pd.Users)
                        .ThenInclude(u => u.UserTypes)
                .Include(o => o.ProductDetails)
                    .ThenInclude(pd => pd.Users)
                        .ThenInclude(u => u.Documents)
                .Include(o => o.ProductDetails)
                    .ThenInclude(pd => pd.Collections)
                .ToListAsync();
        }

        public async Task<Offers?> GetOffersByIdAsync(int id)
        {
            return await _context.Offers
                .Include(o => o.ProductDetails)
                    .ThenInclude(pd => pd.Products)
                        .ThenInclude(p => p.ProductCategories)
                .Include(o => o.ProductDetails)
                    .ThenInclude(pd => pd.Users)
                        .ThenInclude(u => u.UserTypes)
                .Include(o => o.ProductDetails)
                    .ThenInclude(pd => pd.Users)
                        .ThenInclude(u => u.Documents)
                .Include(o => o.ProductDetails)
                    .ThenInclude(pd => pd.Collections)
                .FirstOrDefaultAsync(o => o.Offer_id == id && !o.IsDeleted);
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

        public async Task UpdateOffersAsync(Offers updatedOffers)
        {
            var existingOffers = await _context.Offers.FindAsync(updatedOffers.Offer_id);
            if (existingOffers != null && !existingOffers.IsDeleted)
            {
                var productDetails = await _context.ProductDetails
                    .Include(pd => pd.Products)
                    .FirstOrDefaultAsync(pd => pd.ProdDeta_id == updatedOffers.ProdDeta_id);

                if (productDetails == null)
                {
                    throw new Exception("Detalles del producto no encontrados.");
                }

                // Set relaciones
                existingOffers.ProductDetails = productDetails;

                // Update fields
                existingOffers.QuantityOffer = updatedOffers.QuantityOffer;
                existingOffers.FinalPrice = updatedOffers.FinalPrice;
                existingOffers.StartOffer = updatedOffers.StartOffer;
                existingOffers.EndOffer = updatedOffers.EndOffer;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Oferta con ID {updatedOffers.Offer_id} no encontrada.");
            }
        }
    }
}
