using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class ProductCategoriesRepository : IProductCategoriesRepository
    {
        private readonly AgroDbContext _context;

        public ProductCategoriesRepository(AgroDbContext context)
        {
            _context = context;
        }

        // Crear una nueva categoría de producto
        public async Task CreateProductCategoriesAsync(ProductCategories productCategories)
        {
            productCategories.IsDeleted = false;
            _context.ProductCategories.Add(productCategories);
            await _context.SaveChangesAsync();
        }

        // Obtener todas las categorías de producto que no están eliminadas
        public async Task<IEnumerable<ProductCategories>> GetAllProductCategoriesAsync()
        {
            return await _context.ProductCategories
                .Where(pc => !pc.IsDeleted)
                .ToListAsync();
        }

        // Obtener una categoría de producto por ID si no está eliminada
        public async Task<ProductCategories?> GetProductCategoriesByIdAsync(int id)
        {
            return await _context.ProductCategories
                .FirstOrDefaultAsync(pc => pc.Category_id == id && !pc.IsDeleted);
        }

        // Eliminar lógicamente una categoría de producto
        public async Task SoftDeleteProductCategoriesAsync(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory != null)
            {
                productCategory.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        // Actualizar una categoría de producto existente
        public async Task UpdateProductCategoriesAsync(ProductCategories updatedProductCategories)
        {
            var existingCategory = await _context.ProductCategories.FindAsync(updatedProductCategories.Category_id);
            if (existingCategory != null)
            {
                existingCategory.Category_name = updatedProductCategories.Category_name;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"ProductCategory with ID {updatedProductCategories.Category_id} not found.");
            }
        }
    }
}
