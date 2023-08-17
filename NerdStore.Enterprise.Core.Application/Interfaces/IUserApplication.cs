using NerdStore.Enterprise.Core.Domain.Entities;

namespace NerdStore.Enterprise.Core.Application.Interfaces
{
    public interface IUserApplication
    {
        Task AddUser(User user);
    }
}