﻿using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Services.InterfacesServices
{
    public interface IColllectionsService
    {
        Task<IEnumerable<Collections?>> GetAllCollectionsAsync();
        Task<Collections?> GetCollectionsByIdAsync(int id);
        Task CreateCollectionsAsync(Collections collections);
        Task UpdateCollectionsAsync(Collections collections);
        Task SoftDeleteCollectionsAsync(int id);
    }
}
