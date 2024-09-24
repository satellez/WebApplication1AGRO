using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services.InterfacesServices
{
    public interface IOffersService
    {
        Task<IEnumerable<Offers?>> GetAllOffersAsync();
        Task<Offers?> GetOffersByIdAsync(int id);
        Task CreateOffersAsync(Offers offers);
        Task UpdateOffersAsync(Offers offers);
        Task SoftDeleteOffersAsync(int id);
    }
}
