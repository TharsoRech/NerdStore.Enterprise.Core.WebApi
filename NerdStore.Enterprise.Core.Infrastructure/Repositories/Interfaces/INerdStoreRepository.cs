namespace NerdStore.Enterprise.Core.Infrastructure.Repositories.Interfaces
{
    public interface INerdStoreRepository
    {
        Task<int> AddUser(string login, string password);
    }
}
