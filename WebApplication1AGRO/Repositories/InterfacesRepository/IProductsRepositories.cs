using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface IProductsRepositories
    {
        Task<IEnumerable<Products>> GetAllProductsAsync();
        Task<Products?> GetProductsByIdAsync(int id);
        Task CreateProductsAsync(Products products);
        Task UpdateProductsAsync(Products products);
        Task SoftDeleteProductsAsync(int id);
    }
}
