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
            _context.Contacts.Add(contacts);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contacts>> GetAllContactsAsync()
        {
            return await _context.Contacts
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Contacts?> GetContactsByIdAsync(int id)
        {
            return await _context.Contacts
                .FirstOrDefaultAsync(s => s.Contact_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteContactsAsync(int id)
        {
            var contacts = await _context.Contacts.FindAsync(id);
            if (contacts != null)
            {
                contacts.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateContactsAsync(Contacts contacts)
        {
            _context.Contacts.Update(contacts);
            await _context.SaveChangesAsync();
        }
    }
}
