using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface ICollectionsRepository
    {
        Task<IEnumerable<Collections>> GetAllCollectionsAsync();
        Task<Collections?> GetCollectionsByIdAsync(int id);
        Task CreateCollectionsAsync(Collections collections);
        Task UpdateCollectionsAsync(Collections collections);
        Task SoftDeleteCollectionsAsync(int id);
    }
}
