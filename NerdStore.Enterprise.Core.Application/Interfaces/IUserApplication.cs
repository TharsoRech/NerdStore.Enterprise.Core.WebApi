using NerdStore.Enterprise.Core.Application.Dtos;
using NerdStore.Enterprise.Core.Domain.Entities;

namespace NerdStore.Enterprise.Core.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<int> AddUser(LoginDtoUser user);

        Task<List<User>> GetUsers();

        Task Delete(int id);

        Task ChangePassword(ChagePasswordDTO chagePassword);
    }
}