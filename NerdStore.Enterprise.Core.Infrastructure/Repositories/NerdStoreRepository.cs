using NerdStore.Enterprise.Core.Infrastructure.Context.Interface;
using NerdStore.Enterprise.Core.Infrastructure.Repositories.Interfaces;

namespace NerdStore.Enterprise.Core.Infrastructure.Repositories
{
    public class NerdStoreRepository: INerdStoreRepository
    {
        private readonly IDapperContext _dapperContext;

        public static string addUserCommand = @"insert into [NerdStoreEnterpriseDB].[dbo].[Usuario](Login, Senha)
                                                values (@login,@password)";
        public NerdStoreRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> AddUser(string login,string password)
        {
            return await _dapperContext.ExecuteAsync(addUserCommand, new { login, password });
        }
    }
}
