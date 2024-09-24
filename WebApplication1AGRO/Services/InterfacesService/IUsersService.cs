using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services.InterfacesRepository
{
    public interface IUsersService
    {
        Task<IEnumerable<Users?>> GetAllUsersAsync();
        Task<Users?> GetUsersByIdAsync(int id);
        Task CreateUsersAsync(Users users);
        Task UpdateUsersAsync(Users users);
        Task SoftDeleteUsersAsync(int id);
    }
}
