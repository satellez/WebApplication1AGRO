using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetUsersByIdAsync(int id);
        Task CreateUsersAsync(Users users);
        Task UpdateUsersAsync(Users users);
        Task SoftDeleteUsersAsync(int id);
    }
}
