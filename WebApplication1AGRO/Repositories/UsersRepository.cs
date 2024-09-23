using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;


namespace WebApplication1AGRO.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AgroDbContext _context;

        public UsersRepository(AgroDbContext context)
        {
            _context = context;
        }

        public Task CreateUsersAsync(Users users)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _context.Users
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Users> GetUsersByIdAsync(int id)
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

        public Task UpdateUsersAsync(Users users)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Users>> IUsersRepository.GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        Task<Users> IUsersRepository.GetUsersByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
