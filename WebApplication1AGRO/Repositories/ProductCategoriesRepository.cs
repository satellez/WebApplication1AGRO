using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class ProductCategoriesRepository : IProductCategoriesRepositories
    {
        private readonly AgroDbContext _context;

        public ProductCategoriesRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductCategoriesAsync(ProductCategories productCategories)
        {
            _context.ProductCategories.Add(productCategories);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategories>> GetAllProductCategoriesAsync()
        {
            return await _context.ProductCategories
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<ProductCategories?> GetProductCategoriesByIdAsync(int id)
        {
            return await _context.ProductCategories
                .FirstOrDefaultAsync(s => s.Category_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteProductCategoriesAsync(int id)
        {
            var productCategories = await _context.ProductCategories.FindAsync(id);
            if (productCategories != null)
            {
                productCategories.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProductCategoriesAsync(ProductCategories productCategories)
        {
            _context.ProductCategories.Update(productCategories);
            await _context.SaveChangesAsync();
        }
    }
}
