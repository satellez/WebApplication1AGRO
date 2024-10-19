using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly AgroDbContext _context;

        public ContactsRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateContactsAsync(Contacts contacts)
        {
            var user = await _context.Users
                .Include(u => u.UserTypes)
                .Include(u => u.Documents)
                .FirstOrDefaultAsync(u => u.User_id == contacts.User_id);

            if (user == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            var dataType = await _context.DataTypes.FindAsync(contacts.DataType_id);
            if (dataType == null)
            {
                throw new Exception("Tipo de dato no encontrado.");
            }

            // Set relations
            contacts.Users = user;
            contacts.DataTypes = dataType;

            // Set IsDeleted as false
            contacts.IsDeleted = false;

            _context.Contacts.Add(contacts);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contacts>> GetAllContactsAsync()
        {
            return await _context.Contacts
                .Where(c => !c.IsDeleted)
                .Include(c => c.Users)
                    .ThenInclude(u => u.UserTypes)
                .Include(c => c.Users)
                    .ThenInclude(u => u.Documents)
                .Include(c => c.DataTypes)
                .ToListAsync();
        }

        public async Task<Contacts?> GetContactsByIdAsync(int id)
        {
            return await _context.Contacts
                .Include(c => c.Users)
                    .ThenInclude(u => u.UserTypes)
                .Include(c => c.Users)
                    .ThenInclude(u => u.Documents)
                .Include(c => c.DataTypes)
                .FirstOrDefaultAsync(c => c.Contact_id == id && !c.IsDeleted);
        }

        public async Task SoftDeleteContactsAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateContactsAsync(Contacts updatedContact)
        {
            var existingContact = await _context.Contacts.FindAsync(updatedContact.Contact_id);
            if (existingContact != null && !existingContact.IsDeleted)
            {
                var user = await _context.Users.FindAsync(updatedContact.User_id);
                if (user == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                var dataType = await _context.DataTypes.FindAsync(updatedContact.DataType_id);
                if (dataType == null)
                {
                    throw new Exception("Tipo de dato no encontrado.");
                }

                // Set relationships
                existingContact.Users = user;
                existingContact.DataTypes = dataType;

                // Update fields
                existingContact.Data = updatedContact.Data;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Contact con ID {updatedContact.Contact_id} no encontrado.");
            }
        }
    }
}
