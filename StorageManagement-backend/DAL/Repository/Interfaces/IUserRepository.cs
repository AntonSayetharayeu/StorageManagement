using DAL.Model;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllAsync();

        public Task<List<User>> GetUsersByRoleAsync(int roleID);

        public Task<User> GetUserByIdAsync(int id);

        public Task<User> GetUserByEmailAndPasswordAsync(string email, string password);

        public Task AddNewUserAsync(User user);

        public Task UpdateUserAsync(User user);

        public Task DeleteUserByIdAsync(int id);
    }
}
