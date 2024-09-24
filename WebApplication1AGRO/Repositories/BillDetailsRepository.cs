using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;


namespace WebApplication1AGRO.Repositories
{

    public class BillDetailsRepository : IBillDetailsRepository
    {
        private readonly AgroDbContext _context;

        public BillDetailsRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateBillDetailsAsync(BillDetails billDetails)
        {
            _context.BillDetails.Add(billDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BillDetails>> GetAllBillDetailsAsync()
        {
            return await _context.BillDetails
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<BillDetails?> GetBillDetailsByIdAsync(int id)
        {
            return await _context.BillDetails
                .FirstOrDefaultAsync(s => s.BillDeta_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteBillDetailsAsync(int id)
        {
            var billDetails = await _context.BillDetails.FindAsync(id);
            if (billDetails != null)
            {
                billDetails.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateBillDetailsAsync(BillDetails billDetails)
        {
            _context.BillDetails.Update(billDetails);
            await _context.SaveChangesAsync();
        }
    }
}
