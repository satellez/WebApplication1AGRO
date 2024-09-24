using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface IOffersRepository
    {
        Task<IEnumerable<Offers>> GetAllOffersAsync();
        Task<Offers?> GetOffersByIdAsync(int id);
        Task CreateOffersAsync(Offers offers);
        Task UpdateOffersAsync(Offers offers);
        Task SoftDeleteOffersAsync(int id);
    }
}
