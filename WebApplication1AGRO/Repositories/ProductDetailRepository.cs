using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class ProductDetailRepository
    {
        public class ProductDetailsRepository : IProductDetailsRepositories
        {
            private readonly AgroDbContext _context;

            public ProductDetailsRepository(AgroDbContext context)
            {
                _context = context;
            }

            public async Task CreateProductDetailsAsync(ProductDetails productDetails)
            {
                _context.ProductDetails.Add(productDetails);
                await _context.SaveChangesAsync();
            }

            public async Task<IEnumerable<ProductDetails>> GetAllProductDetailsAsync()
            {
                return await _context.ProductDetails
                    .Where(s => !s.IsDeleted)
                    .ToListAsync();
            }

            public async Task<ProductDetails?> GetProductDetailsByIdAsync(int id)
            {
                return await _context.ProductDetails
                    .FirstOrDefaultAsync(s => s.ProdDeta_id == id && !s.IsDeleted);
            }

            public async Task SoftDeleteProductDetailsAsync(int id)
            {
                var productDetails = await _context.ProductDetails.FindAsync(id);
                if (productDetails != null)
                {
                    productDetails.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }
            }

            public async Task UpdateProductDetailsAsync(ProductDetails productDetails)
            {
                _context.ProductDetails.Update(productDetails);
                await _context.SaveChangesAsync();
            }
        }
    }