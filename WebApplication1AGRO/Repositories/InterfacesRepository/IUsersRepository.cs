using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users?> GetUsersByIdAsync(int id);
        Task CreateUsersAsync(Users users);
        Task UpdateUsersAsync(Users users);
        Task SoftDeleteUsersAsync(int id);

        // Nuevo método para buscar un usuario por correo electrónico
        Task<Users?> GetUsersByEmailAsync(string email);

        // Método LoginAsync para validar las credenciales
        Task<Users?> LoginAsync(string email, string password);
    }
}
