using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;


namespace WebApplication1AGRO.Repositories
{

    public class BillsRepository : IBillsRepository
    {
        private readonly AgroDbContext _context;

        public BillsRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateBillsAsync(Bills bills)
        {
            _context.Bills.Add(bills);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bills>> GetAllBillsAsync()
        {
            return await _context.Bills
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Bills?> GetBillsByIdAsync(int id)
        {
            return await _context.Bills
                .FirstOrDefaultAsync(s => s.Bill_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteBillsAsync(int id)
        {
            var bills = await _context.Bills.FindAsync(id);
            if (bills != null)
            {
                bills.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateBillsAsync(Bills bills)
        {
            _context.Bills.Update(bills);
            await _context.SaveChangesAsync();
        }
    }
}
