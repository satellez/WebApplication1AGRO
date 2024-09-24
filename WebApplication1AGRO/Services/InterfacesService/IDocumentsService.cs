using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services.InterfacesRepository
{
    public interface IDocumentsService
    {
        Task<IEnumerable<Documents?>> GetAllDocumentsAsync();
        Task<Documents?> GetDocumentsByIdAsync(int id);
        Task CreateDocumentsAsync(Documents documents);
        Task UpdateDocumentsAsync(Documents documents);
        Task SoftDeleteDocumentsAsync(int id);
    }
}
