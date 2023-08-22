using Microsoft.Extensions.Logging;
using NerdStore.Enterprise.Core.Domain.Entities;
using NerdStore.Enterprise.Core.Domain.Interfaces;

namespace NerdStore.Enterprise.Core.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly INerdStoreRepository _nerdStoreRepository;
        private readonly ILogger<UserService> _logger;
        public UserService(INerdStoreRepository nerdStoreRepository, ILogger<UserService> logger)
        {
            _logger = logger;
            _nerdStoreRepository = nerdStoreRepository;
        }

        public async Task<int> AddUser(User user)
        {
            try
            {
               return await _nerdStoreRepository.AddUser(user.Login, user.Password);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to AddUser ", ex);
                throw;
            }
        }


        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await _nerdStoreRepository.GetUsers();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to GetUsers ", ex);
                throw;
            }
        }

        public async Task ChangePassword(int id,string password)
        {
            try
            {
                await _nerdStoreRepository.ChangePassword(id, password);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to GetUsers ", ex);
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                await _nerdStoreRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to GetUsers ", ex);
                throw;
            }
        }
    }
}
