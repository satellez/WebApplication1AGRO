using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Services
{
    public class BillsService : IBillsService
    {
        private readonly IBillsRepository _billsRepository;

        public BillsService(IBillsRepository billsRepository)
        {
            _billsRepository = billsRepository;
        }

        public async Task<IEnumerable<Bills?>> GetAllBillsAsync()
        {
            return await _billsRepository.GetAllBillsAsync();
        }

        public async Task<Bills?> GetBillsByIdAsync(int id)
        {
            return await _billsRepository.GetBillsByIdAsync(id);
        }

        public async Task CreateBillsAsync(Bills bills)
        {
            await _billsRepository.CreateBillsAsync(bills);
        }

        public async Task UpdateBillsAsync(Bills bills)
        {
            await _billsRepository.UpdateBillsAsync(bills);
        }

        public async Task SoftDeleteBillsAsync(int id)
        {
            await _billsRepository.SoftDeleteBillsAsync(id);
        }
    }
}
