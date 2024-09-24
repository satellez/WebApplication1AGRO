using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories.InterfacesRepository
{
    public interface IDataTypesRepository
    {
        Task<IEnumerable<DataTypes>> GetAllDataTypesAsync();
        Task<DataTypes?> GetDataTypesByIdAsync(int id);
        Task CreateDataTypesAsync(DataTypes dataTypes);
        Task UpdateDataTypesAsync(DataTypes dataTypes);
        Task SoftDeleteDataTypesAsync(int id);
    }
}
