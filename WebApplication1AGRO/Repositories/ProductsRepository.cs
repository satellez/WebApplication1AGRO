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

        // Crear un nuevo producto con validación de categoría
        public async Task CreateProductsAsync(Products product)
        {
            // Validación de la categoría
            var category = await _context.ProductCategories.FindAsync(product.Category_id);
            if (category == null)
            {
                throw new Exception("Categoría no encontrada.");
            }

            // Asignar la categoría al producto
            product.ProductCategories = category;

            // Establecer IsDeleted como false al crear
            product.IsDeleted = false;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        // Obtener todos los productos no eliminados con sus categorías
        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProductCategories)
                .ToListAsync();
        }

        // Obtener un producto por su ID
        public async Task<Products?> GetProductsByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductCategories)
                .FirstOrDefaultAsync(p => p.Product_id == id && !p.IsDeleted);
        }

        // Eliminación lógica (soft delete) del producto
        public async Task SoftDeleteProductsAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        // Actualización de un producto existente
        public async Task UpdateProductsAsync(Products updatedProduct)
        {
            var existingProduct = await _context.Products.FindAsync(updatedProduct.Product_id);
            if (existingProduct != null)
            {
                // Actualización de campos
                existingProduct.Product_name = updatedProduct.Product_name;
                existingProduct.Category_id = updatedProduct.Category_id;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {updatedProduct.Product_id} not found.");
            }
        }
    }
}
