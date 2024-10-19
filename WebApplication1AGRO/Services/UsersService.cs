using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<Users?>> GetAllUsersAsync()
        {
            return await _usersRepository.GetAllUsersAsync();
        }

        public async Task<Users?> GetUsersByIdAsync(int id)
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

        // Corrección del método: debe retornar el usuario encontrado
        public async Task<Users?> GetUsersByEmailAsync(string email)
        {
            return await _usersRepository.GetUsersByEmailAsync(email); // Asegúrate de retornar el resultado
        }

        // Implementación del login usando BCrypt para validar la contraseña
        public async Task<Users?> LoginAsync(string email, string password)
        {
            // Buscar el usuario por correo electrónico
            var user = await _usersRepository.GetUsersByEmailAsync(email);

            // Verificar si el usuario existe y no está eliminado
            if (user == null || user.IsDeleted)
            {
                return null;
            }

            // Comparar las contraseñas usando BCrypt
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null; // Si las contraseñas no coinciden, retornar null
            }

            return user; // Retornar el usuario si las credenciales son correctas
        }
    }
}
