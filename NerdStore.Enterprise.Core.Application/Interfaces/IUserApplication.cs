using NerdStore.Enterprise.Core.Application.Dtos;

namespace NerdStore.Enterprise.Core.Application.Interfaces
{
    public interface IUserApplication
    {
        Task AddUser(LoginDtoUser user);
    }
}