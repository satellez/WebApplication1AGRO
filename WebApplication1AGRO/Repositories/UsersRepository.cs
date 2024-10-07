using Microsoft.EntityFrameworkCore;
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
            // set IsDeleted as false when is creating a new user
            users.IsDeleted = false;

            //SET UserTypes and Documents
            users.UserTypes = userTypes;
            users.Documents = documents;

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
                .Include(s => s.Documents)
                .Include(s => s.UserTypes)
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

        public async Task UpdateUsersAsync(Users updatedUser)
        {
            var existingUser = await _context.Users.FindAsync(updatedUser.User_id);
            if (existingUser != null)
            {
                // Actualizamos los campos
                existingUser.Names = updatedUser.Names;
                existingUser.Last_names = updatedUser.Last_names;
                existingUser.Email = updatedUser.Email;
                existingUser.Document_number = updatedUser.Document_number;
                existingUser.Username = updatedUser.Username;
                existingUser.Password = updatedUser.Password;
                existingUser.Born_date = updatedUser.Born_date;
                existingUser.UserType_id = updatedUser.UserType_id;
                existingUser.Document_id = updatedUser.Document_id;
                existingUser.Modified = updatedUser.Modified;
                existingUser.ModifiedBy = updatedUser.ModifiedBy;

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {updatedUser.User_id} not found.");
            }
        }


    }
}