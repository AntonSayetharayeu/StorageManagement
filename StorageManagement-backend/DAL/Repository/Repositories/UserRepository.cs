using DAL.Model;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _appDbContext.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<List<User>> GetUsersByRoleAsync(int roleID)
        {
            return await _appDbContext.Users.Include(u => u.Role).Where(user => user.RoleID == roleID).ToListAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _appDbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _appDbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(user => user.ID == id);
        }

        public async Task AddNewUserAsync(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            await _appDbContext.Users.Include(u => u.Role).Where(user => user.ID == id).ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _appDbContext.Users.Include(u => u.Role).Where(_user => _user.ID == user.ID)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(_user => _user.Name, user.Name)
                .SetProperty(_user => _user.Email, user.Email)
                .SetProperty(_user => _user.RoleID, user.RoleID)
                .SetProperty(_user => _user.Address, user.Address)
                .SetProperty(_user => _user.Password, user.Password)
                );
            await _appDbContext.SaveChangesAsync();
        }
    }
}
