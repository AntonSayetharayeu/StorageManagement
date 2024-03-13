using DAL.Model;

namespace BLL_StorageManagement.Service.Interfaces
{
    public interface IRoleService
    {
        public Task<List<Role>> GetAllAsync();

        public Task<Role> GetRoleByIdAsync(int id);

        public Task<Role> GetRoleByNameAsync(string name);

        public Task AddNewRoleAsync(Role role);

        public Task UpdateRoleAsync(Role role);

        public Task DeleteRoleByIdAsync(int id);
    }
}
