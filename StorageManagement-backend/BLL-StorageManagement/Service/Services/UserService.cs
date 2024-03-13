using BLL_StorageManagement.Service.Interfaces;
using DAL.Model;
using DAL.Repository.Interfaces;

namespace BLL_StorageManagement.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<List<User>> GetUsersByRoleAsync(int roleID)
        {
            return await _userRepository.GetUsersByRoleAsync(roleID);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task AddNewUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            await _userRepository.DeleteUserByIdAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
