using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class CollectionsRepository : ICollectionsRepository
    {
        private readonly AgroDbContext _context;

        public CollectionsRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateCollectionsAsync(Collections collections)
        {
            // Aseguramos que IsDeleted es false al crear un nuevo punto de recolección
            collections.IsDeleted = false;

            _context.Collections.Add(collections);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Collections>> GetAllCollectionsAsync()
        {
            return await _context.Collections
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Collections> GetCollectionsByIdAsync(int id)
        {
            return await _context.Collections
                .FirstOrDefaultAsync(s => s.CollectionPoint_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteCollectionsAsync(int id)
        {
            var collections = await _context.Collections.FindAsync(id);
            if (collections != null)
            {
                collections.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCollectionsAsync(Collections collections)
        {
            var existingCollections = await _context.Collections.FindAsync(collections.CollectionPoint_id);
            if (existingCollections != null)
            {
                // Actualizamos los campos
                existingCollections.PointName = collections.PointName;
                existingCollections.Address = collections.Address;

                // Guardamos los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Collections with ID {collections.CollectionPoint_id} not found.");
            }
        }
    }
}
