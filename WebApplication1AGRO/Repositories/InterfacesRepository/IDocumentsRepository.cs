using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface IDocumentsRepository
    {
        Task<IEnumerable<Documents>> GetAllDocumentsAsync();
        Task<Documents?> GetDocumentsByIdAsync(int id);
        Task CreateDocumentsAsync(Documents documents);
        Task UpdateDocumentsAsync(Documents documents);
        Task SoftDeleteDocumentsAsync(int id);
    }
}
