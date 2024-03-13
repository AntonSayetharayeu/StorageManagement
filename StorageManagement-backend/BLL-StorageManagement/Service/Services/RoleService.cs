using BLL_StorageManagement.Service.Interfaces;
using DAL.Model;
using DAL.Repository.Interfaces;

namespace BLL_StorageManagement.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetRoleByIdAsync(id);
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _roleRepository.GetRoleByNameAsync(name);
        }

        public async Task AddNewRoleAsync(Role role)
        {
            await _roleRepository.AddNewRoleAsync(role);
        }

        public async Task DeleteRoleByIdAsync(int id)
        {
            await _roleRepository.DeleteRoleByIdAsync(id);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await _roleRepository.UpdateRoleAsync(role);
        }
    }
}
