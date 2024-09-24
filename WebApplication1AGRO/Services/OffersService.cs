using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesServices;

namespace WebApplication1AGRO.Services
{
    public class OffersService : IOffersService
    {
        private readonly IOffersRepository _offersRepository;

        public OffersService(IOffersRepository offersRepository)
        {
            _offersRepository = offersRepository;
        }

        public async Task<IEnumerable<Offers?>> GetAllOffersAsync()
        {
            return await _offersRepository.GetAllOffersAsync();
        }

        public async Task<Offers?> GetOffersByIdAsync(int id)
        {
            return await _offersRepository.GetOffersByIdAsync(id);
        }

        public async Task CreateOffersAsync(Offers offers)
        {
            await _offersRepository.CreateOffersAsync(offers);
        }

        public async Task UpdateOffersAsync(Offers offers)
        {
            await _offersRepository.UpdateOffersAsync(offers);
        }

        public async Task SoftDeleteOffersAsync(int id)
        {
            await _offersRepository.SoftDeleteOffersAsync(id);
        }
    }
}
