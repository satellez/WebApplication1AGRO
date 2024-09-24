using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task<IEnumerable<Contacts?>> GetAllContactsAsync()
        {
            return await _contactsRepository.GetAllContactsAsync();
        }

        public async Task<Contacts?> GetContactsByIdAsync(int id)
        {
            return await _contactsRepository.GetContactsByIdAsync(id);
        }

        public async Task CreateContactsAsync(Contacts contacts)
        {
            await _contactsRepository.CreateContactsAsync(contacts);
        }

        public async Task UpdateContactsAsync(Contacts contacts)
        {
            await _contactsRepository.UpdateContactsAsync(contacts);
        }

        public async Task SoftDeleteContactsAsync(int id)
        {
            await _contactsRepository.SoftDeleteContactsAsync(id);
        }
    }
}
