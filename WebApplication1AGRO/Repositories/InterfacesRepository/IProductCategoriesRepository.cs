using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface IProductCategoriesRepository
    {
        Task<IEnumerable<ProductCategories>> GetAllProductCategoriesAsync();
        Task<ProductCategories?> GetProductCategoriesByIdAsync(int id);
        Task CreateProductCategoriesAsync(ProductCategories productCategories);
        Task UpdateProductCategoriesAsync(ProductCategories productCategories);
        Task SoftDeleteProductCategoriesAsync(int id);
    }
}
