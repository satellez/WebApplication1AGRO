using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services
{
    public interface IBillDetailsService
    {
        Task<IEnumerable<BillDetails?>> GetAllBillDetailsAsync();
        Task<BillDetails?> GetBillDetailsByIdAsync(int id);
        Task CreateBillDetailsAsync(BillDetails billDetails);
        Task UpdateBillDetailsAsync(BillDetails billDetails);
        Task SoftDeleteBillDetailsAsync(int id);
    }
}
