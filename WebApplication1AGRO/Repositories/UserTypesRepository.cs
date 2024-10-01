using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;


namespace WebApplication1AGRO.Repositories
{

    public class UserTypesRepository : IUserTypesRepository
    {
        private readonly AgroDbContext _context;

        public UserTypesRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserTypesAsync(UserTypes userTypes)
        {
            _context.UserTypes.Add(userTypes);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserTypes>> GetAllUserTypesAsync()
        {
            return await _context.UserTypes
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<UserTypes?> GetUserTypesByIdAsync(int id)
        {
            return await _context.UserTypes
                .FirstOrDefaultAsync(s => s.UserType_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteUserTypesAsync(int id)
        {
            var userTypes = await _context.UserTypes.FindAsync(id);
            if (userTypes != null)
            {
                userTypes.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserTypesAsync(UserTypes userTypes)
        {
            _context.UserTypes.Update(userTypes);
            await _context.SaveChangesAsync();
        }
    }
}