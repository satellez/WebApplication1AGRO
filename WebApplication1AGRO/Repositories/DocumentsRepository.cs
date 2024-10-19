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
            // Se establece IsDeleted como false al crear un nuevo documento
            documents.IsDeleted = false;

            _context.Documents.Add(documents);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Documents>> GetAllDocumentsAsync()
        {
            return await _context.Documents
                .Where(d => !d.IsDeleted)
                .ToListAsync();
        }

        public async Task<Documents?> GetDocumentsByIdAsync(int id)
        {
            return await _context.Documents
                .FirstOrDefaultAsync(d => d.Document_id == id && !d.IsDeleted);
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

        public async Task UpdateDocumentsAsync(Documents updatedDocuments)
        {
            var existingDocuments = await _context.Documents.FindAsync(updatedDocuments.Document_id);
            if (existingDocuments != null)
            {
                // Actualizamos los campos
                existingDocuments.Document_name = updatedDocuments.Document_name;

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Document with ID {updatedDocuments.Document_id} not found.");
            }
        }
    }
}
