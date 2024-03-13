using DAL.Model;

namespace DAL.Repository.Interfaces
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetAllAsync();

        public Task<Role> GetRoleByIdAsync(int id);

        public Task<Role> GetRoleByNameAsync(string name);

        public Task AddNewRoleAsync(Role role);

        public Task UpdateRoleAsync(Role role);

        public Task DeleteRoleByIdAsync(int id);
    }
}
