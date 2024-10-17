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
            dataTypes.IsDeleted = false;
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

        
        public async Task UpdateDataTypesAsync(DataTypes updatedDataTypes)
        {
            var existingDataType = await _context.DataTypes.FindAsync(updatedDataTypes.DataType_id);
            if (existingDataType != null)
            {
                existingDataType.DataType_name = updatedDataTypes.DataType_name;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"DataType with ID {updatedDataTypes.DataType_id} not found.");
            }
        }
    }
}
