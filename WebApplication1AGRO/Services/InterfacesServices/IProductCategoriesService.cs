using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services.InterfacesServices
{
    public interface IProductCategoriesService
    {
        Task<IEnumerable<ProductCategories?>> GetAllProductCategoriesAsync();
        Task<ProductCategories?> GetProductCategoriesByIdAsync(int id);
        Task CreateProductCategoriesAsync(ProductCategories productCategories);
        Task UpdateProductCategoriesAsync(ProductCategories productCategories);
        Task SoftDeleteProductCategoriesAsync(int id);
    }
}
