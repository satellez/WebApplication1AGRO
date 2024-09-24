using Microsoft.EntityFrameworkCore;
using WebApplication1AGRO.Context;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories.InterfacesRepository;


namespace WebApplication1AGRO.Repositories
{

    public class DataTypesRepository : IDataTypesRepository
    {
        private readonly AgroDbContext _context;

        public DataTypesRepository(AgroDbContext context)
        {
            _context = context;
        }

        public async Task CreateDataTypesAsync(DataTypes dataTypes)
        {
            _context.DataTypes.Add(dataTypes);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataTypes>> GetAllDataTypesAsync()
        {
            return await _context.DataTypes
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<DataTypes?> GetDataTypesByIdAsync(int id)
        {
            return await _context.DataTypes
                .FirstOrDefaultAsync(s => s.DataType_id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteDataTypesAsync(int id)
        {
            var dataTypes = await _context.DataTypes.FindAsync(id);
            if (dataTypes != null)
            {
                dataTypes.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateDataTypesAsync(DataTypes dataTypes)
        {
            _context.DataTypes.Update(dataTypes);
            await _context.SaveChangesAsync();
        }
    }
}
