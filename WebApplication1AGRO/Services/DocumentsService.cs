using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IDocumentsRepository _documentsRepository;

        public DocumentsService(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }

        public async Task<IEnumerable<Documents?>> GetAllDocumentsAsync()
        {
            return await _documentsRepository.GetAllDocumentsAsync();
        }

        public async Task<Documents?> GetDocumentsByIdAsync(int id)
        {
            return await _documentsRepository.GetDocumentsByIdAsync(id);
        }

        public async Task CreateDocumentsAsync(Documents documents)
        {
            await _documentsRepository.CreateDocumentsAsync(documents);
        }

        public async Task UpdateDocumentsAsync(Documents documents)
        {
            await _documentsRepository.UpdateDocumentsAsync(documents);
        }

        public async Task SoftDeleteDocumentsAsync(int id)
        {
            await _documentsRepository.SoftDeleteDocumentsAsync(id);
        }
    }
}
