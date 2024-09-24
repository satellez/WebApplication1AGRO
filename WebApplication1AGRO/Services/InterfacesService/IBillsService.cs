using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services.InterfacesRepository
{
    public interface IBillsService
    {
        Task<IEnumerable<Bills?>> GetAllBillsAsync();
        Task<Bills?> GetBillsByIdAsync(int id);
        Task CreateBillsAsync(Bills bills);
        Task UpdateBillsAsync(Bills bills);
        Task SoftDeleteBillsAsync(int id);
    }
}
