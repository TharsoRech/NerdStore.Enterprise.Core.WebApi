using NerdStore.Enterprise.Core.Domain.Entities;

namespace NerdStore.Enterprise.Core.Domain.Interfaces
{
    public interface IUserService
    {
        Task AddUser(User user);
    }
}
