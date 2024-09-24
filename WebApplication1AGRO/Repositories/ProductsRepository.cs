using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AgroDbContext _context;

        public ProductsRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductsAsync(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _context.Products
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Products?> GetProductsByIdAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(s => s.Product_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteProductsAsync(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                products.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProductsAsync(Products products)
        {
            _context.Products.Update(products);
            await _context.SaveChangesAsync();
        }
    }
}