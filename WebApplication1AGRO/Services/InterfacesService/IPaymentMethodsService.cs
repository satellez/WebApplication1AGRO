using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services.InterfacesRepository
{
    public interface IPaymentMethodsService
    {
        Task<IEnumerable<PaymentMethods?>> GetAllPaymentMethodsAsync();
        Task<PaymentMethods?> GetPaymentMethodsByIdAsync(int id);
        Task CreatePaymentMethodsAsync(PaymentMethods paymentMethods);
        Task UpdatePaymentMethodsAsync(PaymentMethods paymentMethods);
        Task SoftDeletePaymentMethodsAsync(int id);
    }
}
