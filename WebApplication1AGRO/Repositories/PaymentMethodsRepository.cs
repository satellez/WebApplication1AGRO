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
            // set IsDeleted as false when creating a new payment method
            paymentMethods.IsDeleted = false;

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
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod != null)
            {
                paymentMethod.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePaymentMethodsAsync(PaymentMethods updatedPaymentMethod)
        {
            var existingPaymentMethod = await _context.PaymentMethods.FindAsync(updatedPaymentMethod.Method_id);
            if (existingPaymentMethod != null)
            {
                // Actualizamos los campos
                existingPaymentMethod.Method_name = updatedPaymentMethod.Method_name;

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"PaymentMethod with ID {updatedPaymentMethod.Method_id} not found.");
            }
        }
    }
}
