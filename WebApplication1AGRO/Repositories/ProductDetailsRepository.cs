using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class ProductDetailsRepository : IProductDetailsRepository
    {
        private readonly AgroDbContext _context;

        public ProductDetailsRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductDetailsAsync(ProductDetails productDetails)
        {
            // Validar Product y User antes de crear
            var product = await _context.Products.FindAsync(productDetails.Product_id);
            if (product == null)
            {
                throw new Exception("Producto no encontrado.");
            }

            var user = await _context.Users.FindAsync(productDetails.User_id);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            var collection = await _context.Collections.FindAsync(productDetails.CollectionPoint_id);
            if (collection == null)
            {
                throw new Exception("Punto de recolección no encontrado.");
            }

            // Asignar relaciones
            productDetails.Products = product;
            productDetails.Users = user;
            productDetails.Collections = collection;

            // Establecer IsDeleted como false al crear
            productDetails.IsDeleted = false;

            _context.ProductDetails.Add(productDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDetails>> GetAllProductDetailsAsync()
        {
            return await _context.ProductDetails
                .Where(pd => !pd.IsDeleted)
                .Include(pd => pd.Products)
                    .ThenInclude(p => p.ProductCategories)  // Incluir ProductCategories dentro de Products
                .Include(pd => pd.Users)
                    .ThenInclude(u => u.UserTypes)          // Incluir UserTypes dentro de Users
                .Include(pd => pd.Users)
                    .ThenInclude(u => u.Documents)          // Incluir Documents dentro de Users
                .Include(pd => pd.Collections)
                .ToListAsync();
        }

        public async Task<ProductDetails?> GetProductDetailsByIdAsync(int id)
        {
            return await _context.ProductDetails
                .Include(pd => pd.Products)
                    .ThenInclude(p => p.ProductCategories)  // Incluir ProductCategories dentro de Products
                .Include(pd => pd.Users)
                    .ThenInclude(u => u.UserTypes)          // Incluir UserTypes dentro de Users
                .Include(pd => pd.Users)
                    .ThenInclude(u => u.Documents)          // Incluir Documents dentro de Users
                .Include(pd => pd.Collections)
                .FirstOrDefaultAsync(pd => pd.ProdDeta_id == id && !pd.IsDeleted);
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

        public async Task UpdateProductDetailsAsync(ProductDetails updatedProductDetails)
        {
            var existingProductDetails = await _context.ProductDetails.FindAsync(updatedProductDetails.ProdDeta_id);
            if (existingProductDetails != null)
            {
                // Actualiza los campos
                existingProductDetails.QuantityStock = updatedProductDetails.QuantityStock;
                existingProductDetails.WeigthPoundsPack = updatedProductDetails.WeigthPoundsPack;
                existingProductDetails.StartingPrice = updatedProductDetails.StartingPrice;
                existingProductDetails.MinimunQuantity = updatedProductDetails.MinimunQuantity;
                existingProductDetails.HarvestDate = updatedProductDetails.HarvestDate;
                existingProductDetails.User_id = updatedProductDetails.User_id;
                existingProductDetails.Product_id = updatedProductDetails.Product_id;
                existingProductDetails.CollectionPoint_id = updatedProductDetails.CollectionPoint_id;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"ProductDetails with ID {updatedProductDetails.ProdDeta_id} not found.");
            }
        }
    }
}
