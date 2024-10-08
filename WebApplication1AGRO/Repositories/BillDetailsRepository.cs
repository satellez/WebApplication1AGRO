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
            var products = await _context.Products.FindAsync(billDetails.Product_id);
            if (products == null)
            {
                throw new Exception("Product not found");
            }

            var bills = await _context.Bills.FindAsync(billDetails.Bill_id);
            if (bills == null)
            {
                throw new Exception("Bill not found");
            }

            // Set IsDeleted as false when creating a new BillDetail
            billDetails.IsDeleted = false;

            // Set Products and Bills
            billDetails.Products = products;
            billDetails.Bills = bills;

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

        public async Task UpdateBillDetailsAsync(BillDetails updatedBillDetails)
        {
            var existingBillDetails = await _context.BillDetails.FindAsync(updatedBillDetails.BillDeta_id);
            if (existingBillDetails != null && !existingBillDetails.IsDeleted)
            {
                // Update fields
                existingBillDetails.Bill_id = updatedBillDetails.Bill_id;
                existingBillDetails.Product_id = updatedBillDetails.Product_id;

                // Save changes
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"BillDetails with ID {updatedBillDetails.BillDeta_id} not found.");
            }
        }
    }
}
