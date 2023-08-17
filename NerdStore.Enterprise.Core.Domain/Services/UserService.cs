using Microsoft.Extensions.Logging;
using NerdStore.Enterprise.Core.Domain.Entities;
using NerdStore.Enterprise.Core.Domain.Interfaces;
using NerdStore.Enterprise.Core.Infrastructure.Repositories.Interfaces;

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

        public async Task AddUser(User user)
        {
            try
            {
                await _nerdStoreRepository.AddUser(user.Login, user.Password);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to AddUser ", ex);
                throw;
            }
        }
    }
}
