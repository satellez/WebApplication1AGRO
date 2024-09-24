using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesServices;

namespace WebApplication1AGRO.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Products?>> GetAllProductsAsync()
        {
            return await _productsRepository.GetAllProductsAsync();
        }

        public async Task<Products?> GetProductsByIdAsync(int id)
        {
            return await _productsRepository.GetProductsByIdAsync(id);
        }

        public async Task CreateProductsAsync(Products products)
        {
            await _productsRepository.CreateProductsAsync(products);
        }

        public async Task UpdateProductsAsync(Products products)
        {
            await _productsRepository.UpdateProductsAsync(products);
        }

        public async Task SoftDeleteProductsAsync(int id)
        {
            await _productsRepository.SoftDeleteProductsAsync(id);
        }
    }
}

