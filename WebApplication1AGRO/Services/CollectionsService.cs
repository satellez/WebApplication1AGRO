using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesServices;

namespace WebApplication1AGRO.Services
{
    public class CollectionsService : ICollectionsService
    {
        private readonly ICollectionsRepository _collectionsRepository;

        public CollectionsService(ICollectionsRepository collectionsRepository)
        {
            _collectionsRepository = collectionsRepository;
        }

        public async Task<IEnumerable<Collections?>> GetAllCollectionsAsync()
        {
            return await _collectionsRepository.GetAllCollectionsAsync();
        }

        public async Task<Collections?> GetCollectionsByIdAsync(int id)
        {
            return await _collectionsRepository.GetCollectionsByIdAsync(id);
        }

        public async Task CreateCollectionsAsync(Collections collections)
        {
            await _collectionsRepository.CreateCollectionsAsync(collections);
        }

        public async Task UpdateCollectionsAsync(Collections collections)
        {
            await _collectionsRepository.UpdateCollectionsAsync(collections);
        }

        public async Task SoftDeleteCollectionsAsync(int id)
        {
            await _collectionsRepository.SoftDeleteCollectionsAsync(id);
        }
    }
}