using WebApplication1AGRO.Model;
using WebApplication1AGRO.Repositories;
using WebApplication1AGRO.Repositories.InterfacesRepository;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Services
{
    public class DataTypesService : IDataTypesService
    {
        private readonly IDataTypesRepository _dataTypesRepository;

        public DataTypesService(IDataTypesRepository dataTypesRepository)
        {
            _dataTypesRepository = dataTypesRepository;
        }

        public async Task<IEnumerable<DataTypes?>> GetAllDataTypesAsync()
        {
            return await _dataTypesRepository.GetAllDataTypesAsync();
        }

        public async Task<DataTypes?> GetDataTypesByIdAsync(int id)
        {
            return await _dataTypesRepository.GetDataTypesByIdAsync(id);
        }

        public async Task CreateDataTypesAsync(DataTypes dataTypes)
        {
            await _dataTypesRepository.CreateDataTypesAsync(dataTypes);
        }

        public async Task UpdateDataTypesAsync(DataTypes dataTypes)
        {
            await _dataTypesRepository.UpdateDataTypesAsync(dataTypes);
        }

        public async Task SoftDeleteDataTypesAsync(int id)
        {
            await _dataTypesRepository.SoftDeleteDataTypesAsync(id);
        }
    }
}
