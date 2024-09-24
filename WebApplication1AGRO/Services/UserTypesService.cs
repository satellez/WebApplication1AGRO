using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories;

namespace WebApplication1AGRO.Services
{
    public class UserTypesService : IUserTypesService
    {
        private readonly IUserTypesRepository _userTypesRepository;

        public UserTypesService(IUserTypesRepository userTypesRepository)
        {
            _userTypesRepository = userTypesRepository;
        }

        public async Task<IEnumerable<UserTypes>> GetAllUserTypesAsync()
        {
            return await _userTypesRepository.GetAllUserTypesAsync();
        }

        public async Task<UserTypes> GetUserTypesByIdAsync(int id)
        {
            return await _userTypesRepository.GetUserTypesByIdAsync(id);
        }

        public async Task CreateUserTypesAsync(UserTypes userTypes)
        {
            await _userTypesRepository.CreateUserTypesAsync(userTypes);
        }

        public async Task UpdateUserTypesAsync(UserTypes userTypes)
        {
            await _userTypesRepository.UpdateUserTypesAsync(userTypes);
        }

        public async Task SoftDeleteUserTypesAsync(int id)
        {
            await _userTypesRepository.SoftDeleteUserTypesAsync(id);
        }
    }
}
