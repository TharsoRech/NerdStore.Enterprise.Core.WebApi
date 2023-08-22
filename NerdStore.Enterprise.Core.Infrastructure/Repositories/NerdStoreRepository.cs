using NerdStore.Enterprise.Core.Domain.Entities;
using NerdStore.Enterprise.Core.Domain.Interfaces;
using NerdStore.Enterprise.Core.Infrastructure.Context.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace NerdStore.Enterprise.Core.Infrastructure.Repositories
{
    public class NerdStoreRepository: INerdStoreRepository
    {
        private readonly IDapperContext _dapperContext;

        public static string addUserCommand = @"insert into [NerdStoreEnterpriseDB].[dbo].[Usuario](Login, Password)
                                                values (@login,@password)";

        public static string getUserCommand = @"SELECT TOP (1) [Password] ,[Login],[Id] from [NerdStoreEnterpriseDB].[dbo].[Usuario]
                                                where Login = @login";
        public NerdStoreRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> AddUser(string login,string password)
        {
            return await _dapperContext.ExecuteAsync(addUserCommand, new { login, password });
        }

        public async Task<User> GetUser(string login)
        {
            var retorno = await _dapperContext.QueryFirstOrDefaultAsync<User>(getUserCommand, new { login });
            return retorno;

        }
    }
}
