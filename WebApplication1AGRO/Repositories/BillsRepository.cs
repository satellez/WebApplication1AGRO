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
            var users = await _context.Users.FindAsync(bills.User_id);
            if (users == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var paymentMethod = await _context.PaymentMethods.FindAsync(bills.Method_id);
            if (paymentMethod == null)
            {
                throw new Exception("Método de pago no encontrado");
            }

            // set IsDeleted as false when creating a new bill
            bills.IsDeleted = false;

            // SET Users and PaymentMethods
            bills.Users = users;
            bills.PaymentMethods = paymentMethod;

            _context.Bills.Add(bills);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bills>> GetAllBillsAsync()
        {
            return await _context.Bills
                .Where(b => !b.IsDeleted)
                .Include(b => b.Users)
                .Include(b => b.PaymentMethods)
                .ToListAsync();
        }

        public async Task<Bills?> GetBillsByIdAsync(int id)
        {
            return await _context.Bills
                .Include(b => b.Users)
                .Include(b => b.PaymentMethods)
                .FirstOrDefaultAsync(b => b.Bill_id == id && !b.IsDeleted);
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

        public async Task UpdateBillsAsync(Bills updatedBill)
        {
            var existingBill = await _context.Bills.FindAsync(updatedBill.Bill_id);
            if (existingBill != null)
            {
                
                existingBill.Purchase_date = updatedBill.Purchase_date;
                existingBill.User_id = updatedBill.User_id; 
                existingBill.Method_id = updatedBill.Method_id; 

                
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Bill with ID {updatedBill.Bill_id} not found.");
            }
        }
    }
}
