using NerdStore.Enterprise.Core.Domain.Entities;

namespace NerdStore.Enterprise.Core.Domain.Interfaces
{
    public interface ILoginService
    {
        Task<Token> Login(User user);
    }
}
