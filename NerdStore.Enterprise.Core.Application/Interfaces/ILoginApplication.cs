using NerdStore.Enterprise.Core.Application.Dtos;
using NerdStore.Enterprise.Core.Domain.Entities;

namespace NerdStore.Enterprise.Core.Application.Interfaces
{
    public interface ILoginApplication
    {
        Task<Token> Login(LoginDtoUser user);
    }
}
