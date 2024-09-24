using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Services
{
    public class PaymentMethodsService : IPaymentMethodsService
    {
        private readonly IPaymentMethodsRepository _paymentMethodsRepository;

        public PaymentMethodsService(IPaymentMethodsRepository paymentMethodsRepository)
        {
            _paymentMethodsRepository = paymentMethodsRepository;
        }

        public async Task<IEnumerable<PaymentMethods?>> GetAllPaymentMethodsAsync()
        {
            return await _paymentMethodsRepository.GetAllPaymentMethodsAsync();
        }

        public async Task<PaymentMethods?> GetPaymentMethodsByIdAsync(int id)
        {
            return await _paymentMethodsRepository.GetPaymentMethodsByIdAsync(id);
        }

        public async Task CreatePaymentMethodsAsync(PaymentMethods paymentMethods)
        {
            await _paymentMethodsRepository.CreatePaymentMethodsAsync(paymentMethods);
        }

        public async Task UpdatePaymentMethodsAsync(PaymentMethods paymentMethods)
        {
            await _paymentMethodsRepository.UpdatePaymentMethodsAsync(paymentMethods);
        }

        public async Task SoftDeletePaymentMethodsAsync(int id)
        {
            await _paymentMethodsRepository.SoftDeletePaymentMethodsAsync(id);
        }
    }
}
