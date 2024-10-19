using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;

namespace WebApplication1AGRO.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AgroDbContext _context;

        public UsersRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateUsersAsync(Users users)
        {
            var userTypes = await _context.UserTypes.FindAsync(users.UserType_id);
            if (userTypes == null)
            {
                throw new Exception("Tipo de usuario no encontrado");
            }

            var documents = await _context.Documents.FindAsync(users.Document_id);
            if (documents == null)
            {
                throw new Exception("Tipo de documento no encontrado");
            }
            // set IsDeleted as false when creating a new user
            users.IsDeleted = false;

            

            // Asignar la persona encontrada
            //user.Peoples = person;

            // Hashear la contraseña antes de guardar el usuario
            users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);

            // Verificar el hash de la contraseña en la consola
            Console.WriteLine("Password Hash: " + users.Password);

            // Agregar el nuevo registro de usuario
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
          return await _context.Users
                .Where(s => !s.IsDeleted)
                .Include(s => s.Documents)
                .Include(s => s.UserTypes)
                .ToListAsync();
        }

        public async Task<Users?> GetUsersByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(s => s.User_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteUsersAsync(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                users.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUsersAsync(Users users)
        {
            var existingUser = await _context.Users.FindAsync(users.User_id);
            if (existingUser != null)
            {
                existingUser.Names = users.Names;
                existingUser.Last_names = users.Last_names;
                existingUser.Email = users.Email;
                existingUser.Document_number = users.Document_number;
                existingUser.Username = users.Username;
                existingUser.Password = users.Password;
                existingUser.Born_date = users.Born_date;
                existingUser.UserType_id = users.UserType_id;
                existingUser.Document_id = users.Document_id;
                existingUser.Modified = users.Modified;
                existingUser.ModifiedBy = users.ModifiedBy;

                await _context.SaveChangesAsync();
            }
        }

        // Implementación de GetUsersByEmailAsync
        public async Task<Users?> GetUsersByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        // Implementación de LoginAsync
        public async Task<Users?> LoginAsync(string email, string password)
        {
            var user = await GetUsersByEmailAsync(email);

            // Verificar si el usuario existe y no está eliminado
            if (user == null || user.IsDeleted)
            {
                return null;
            }

            // Comparar la contraseña usando BCrypt
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null; // Si las contraseñas no coinciden, retornar null
            }

            return user; // Si las credenciales son correctas, retornar el usuario
        }




    }
}
    

