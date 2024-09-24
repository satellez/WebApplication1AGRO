using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories;

namespace WebApplication1AGRO.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService (IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _usersRepository.GetAllUsersAsync();
        }

        public async Task<Users> GetUsersByIdAsync(int  id)
        {
            return await _usersRepository.GetUsersByIdAsync(id);
        }

        public async Task CreateUsersAsync(Users users)
        {
            await _usersRepository.CreateUsersAsync(users);
        }

        public async Task UpdateUsersAsync(Users users)
        {
            await _usersRepository.UpdateUsersAsync(users);
        }

        public async Task SoftDeleteUsersAsync(int id)
        {
            await _usersRepository.SoftDeleteUsersAsync(id);
        }
    }
}
