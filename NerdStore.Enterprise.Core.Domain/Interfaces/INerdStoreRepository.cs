using NerdStore.Enterprise.Core.Domain.Entities;

namespace NerdStore.Enterprise.Core.Domain.Interfaces
{
    public interface INerdStoreRepository
    {
        Task<int> AddUser(string login, string password);

        Task<User> GetUser(string login);

        Task<List<User>> GetUsers();

        Task<int> DeleteUser(int id);

        Task<int> ChangePassword(int id, string password);
    }
}
