using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Services
{
    public class BillDetailsService : IBillDetailsService
    {
        private readonly IBillDetailsRepository _billDetailsRepository;

        public BillDetailsService(IBillDetailsRepository billDetailsRepository)
        {
            _billDetailsRepository = billDetailsRepository;
        }

        public async Task<IEnumerable<BillDetails?>> GetAllBillDetailsAsync()
        {
            return await _billDetailsRepository.GetAllBillDetailsAsync();
        }

        public async Task<BillDetails?> GetBillDetailsByIdAsync(int id)
        {
            return await _billDetailsRepository.GetBillDetailsByIdAsync(id);
        }

        public async Task CreateBillDetailsAsync(BillDetails billDetails)
        {
            await _billDetailsRepository.CreateBillDetailsAsync(billDetails);
        }

        public async Task UpdateBillDetailsAsync(BillDetails billDetails)
        {
            await _billDetailsRepository.UpdateBillDetailsAsync(billDetails);
        }

        public async Task SoftDeleteBillDetailsAsync(int id)
        {
            await _billDetailsRepository.SoftDeleteBillDetailsAsync(id);
        }
    }
}
