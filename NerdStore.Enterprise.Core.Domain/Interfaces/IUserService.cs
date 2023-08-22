using NerdStore.Enterprise.Core.Domain.Entities;

namespace NerdStore.Enterprise.Core.Domain.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUser(User user);

        Task<List<User>> GetUsers();

        Task ChangePassword(int id, string password);

        Task DeleteUser(int id);
    }
}
