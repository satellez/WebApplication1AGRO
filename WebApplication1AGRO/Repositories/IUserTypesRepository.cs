﻿using WebApplication1AGRO.Model;

namespace WebApplication1AGRO.Repositories
{
    public interface IUserTypesRepository
    {
        Task<IEnumerable<UserTypes>> GetAllUserTypesAsync();
        Task<UserTypes> GetUserTypesByIdAsync(int id);
        Task CreateUserTypesAsync(UserTypes userTypes);
        Task UpdateUserTypesAsync(UserTypes userTypes);
        Task SoftDeleteUserTypesAsync(int id); 
    }
}
