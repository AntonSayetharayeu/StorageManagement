using DAL.Model;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _appDbContext;

        public RoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _appDbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _appDbContext.Roles.FirstOrDefaultAsync(role => role.ID == id);
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _appDbContext.Roles.FirstOrDefaultAsync(role => role.Name == name);
        }

        public async Task AddNewRoleAsync(Role role)
        {
            await _appDbContext.Roles.AddAsync(role);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleByIdAsync(int id)
        {
            await _appDbContext.Roles.Where(role => role.ID == id).ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await _appDbContext.Roles.Where(_role => _role.ID == role.ID)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(_role => _role.Name, role.Name)
                );
            await _appDbContext.SaveChangesAsync();
        }
    }
}
