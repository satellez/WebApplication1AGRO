using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesServices;

namespace WebApplication1AGRO.Services
{
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly IProductDetailsRepository _productDetailsRepository;

        public ProductDetailsService(IProductDetailsRepository productDetailsRepository)
        {
            _productDetailsRepository = productDetailsRepository;
        }

        public async Task<IEnumerable<ProductDetails?>> GetAllProductDetailsAsync()
        {
            return await _productDetailsRepository.GetAllProductDetailsAsync();
        }

        public async Task<ProductDetails?> GetProductDetailsByIdAsync(int id)
        {
            return await _productDetailsRepository.GetProductDetailsByIdAsync(id);
        }

        public async Task CreateProductDetailsAsync(ProductDetails productDetails)
        {
            await _productDetailsRepository.CreateProductDetailsAsync(productDetails);
        }

        public async Task UpdateProductDetailsAsync(ProductDetails productDetails)
        {
            await _productDetailsRepository.UpdateProductDetailsAsync(productDetails);
        }

        public async Task SoftDeleteProductDetailsAsync(int id)
        {
            await _productDetailsRepository.SoftDeleteProductDetailsAsync(id);
        }
    }
}
