using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;


namespace WebApplication1AGRO.Repositories
{

    public class PaymentMethodsRepository : IPaymentMethodsRepository
    {
        private readonly AgroDbContext _context;

        public PaymentMethodsRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreatePaymentMethodsAsync(PaymentMethods paymentMethods)
        {
            _context.PaymentMethods.Add(paymentMethods);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PaymentMethods>> GetAllPaymentMethodsAsync()
        {
            return await _context.PaymentMethods
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<PaymentMethods?> GetPaymentMethodsByIdAsync(int id)
        {
            return await _context.PaymentMethods
                .FirstOrDefaultAsync(s => s.Method_id == id && !s.IsDeleted);
        }

        public async Task SoftDeletePaymentMethodsAsync(int id)
        {
            var paymentMethods = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethods != null)
            {
                paymentMethods.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePaymentMethodsAsync(PaymentMethods paymentMethods)
        {
            _context.PaymentMethods.Update(paymentMethods);
            await _context.SaveChangesAsync();
        }
    }
}
