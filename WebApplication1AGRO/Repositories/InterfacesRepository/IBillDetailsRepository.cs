using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface IBillDetailsRepository
    {
        Task<IEnumerable<BillDetails>> GetAllBillDetailsAsync();
        Task<BillDetails?> GetBillDetailsByIdAsync(int id);
        Task CreateBillDetailsAsync(BillDetails billDetails);
        Task UpdateBillDetailsAsync(BillDetails billDetails);
        Task SoftDeleteBillDetailsAsync(int id);
    }
}
