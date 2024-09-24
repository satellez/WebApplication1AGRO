using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesServices;

namespace WebApplication1AGRO.Services
{
    public class ProductCategoriesService : IProductCategoriesService
    {
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public ProductCategoriesService(IProductCategoriesRepository productCategoriesRepository)
        {
            _productCategoriesRepository = productCategoriesRepository;
        }

        public async Task<IEnumerable<ProductCategories?>> GetAllProductCategoriesAsync()
        {
            return await _productCategoriesRepository.GetAllProductCategoriesAsync();
        }

        public async Task<ProductCategories?> GetProductCategoriesByIdAsync(int id)
        {
            return await _productCategoriesRepository.GetProductCategoriesByIdAsync(id);
        }

        public async Task CreateProductCategoriesAsync(ProductCategories productCategories)
        {
            await _productCategoriesRepository.CreateProductCategoriesAsync(productCategories);
        }

        public async Task UpdateProductCategoriesAsync(ProductCategories productCategories)
        {
            await _productCategoriesRepository.UpdateProductCategoriesAsync(productCategories);
        }

        public async Task SoftDeleteProductCategoriesAsync(int id)
        {
            await _productCategoriesRepository.SoftDeleteProductCategoriesAsync(id);
        }
    }
}
