using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface IPaymentMethodsRepository
    {
        Task<IEnumerable<PaymentMethods>> GetAllPaymentMethodsAsync();
        Task<PaymentMethods?> GetPaymentMethodsByIdAsync(int id);
        Task CreatePaymentMethodsAsync(PaymentMethods paymentMethods);
        Task UpdatePaymentMethodsAsync(PaymentMethods paymentMethods);
        Task SoftDeletePaymentMethodsAsync(int id);
    }
}
