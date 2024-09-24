using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface IProductDetailsRepository
    {
        Task<IEnumerable<ProductDetails>> GetAllProductDetailsAsync();
        Task<ProductDetails?> GetProductDetailsByIdAsync(int id);
        Task CreateProductDetailsAsync(ProductDetails productDetails);
        Task UpdateProductDetailsAsync(ProductDetails productDetails);
        Task SoftDeleteProductDetailsAsync(int id);
    }
}
