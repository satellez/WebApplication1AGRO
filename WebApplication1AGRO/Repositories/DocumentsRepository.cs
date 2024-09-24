using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;


namespace WebApplication1AGRO.Repositories
{

    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly AgroDbContext _context;

        public DocumentsRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateDocumentsAsync(Documents documents)
        {
            _context.Documents.Add(documents);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Documents>> GetAllDocumentsAsync()
        {
            return await _context.Documents
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Documents?> GetDocumentsByIdAsync(int id)
        {
            return await _context.Documents
                .FirstOrDefaultAsync(s => s.Document_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteDocumentsAsync(int id)
        {
            var documents = await _context.Documents.FindAsync(id);
            if (documents != null)
            {
                documents.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateDocumentsAsync(Documents documents)
        {
            _context.Documents.Update(documents);
            await _context.SaveChangesAsync();
        }
    }
}
