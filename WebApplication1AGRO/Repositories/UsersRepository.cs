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
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _context.Users
                .Where(s => !s.IsDeleted)
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
            _context.Users.Update(users);
            await _context.SaveChangesAsync();
        }
    }
}
