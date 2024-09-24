using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services.InterfacesRepository
{
    public interface IContactsService
    {
        Task<IEnumerable<Contacts?>> GetAllContactsAsync();
        Task<Contacts?> GetContactsByIdAsync(int id);
        Task CreateContactsAsync(Contacts contacts);
        Task UpdateContactsAsync(Contacts contacts);
        Task SoftDeleteContactsAsync(int id);
    }
}
