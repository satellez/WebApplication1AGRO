using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services.InterfacesRepository
{
    public interface IDataTypesService
    {
        Task<IEnumerable<DataTypes?>> GetAllDataTypesAsync();
        Task<DataTypes?> GetDataTypesByIdAsync(int id);
        Task CreateDataTypesAsync(DataTypes dataTypes);
        Task UpdateDataTypesAsync(DataTypes dataTypes);
        Task SoftDeleteDataTypesAsync(int id);
    }
}
