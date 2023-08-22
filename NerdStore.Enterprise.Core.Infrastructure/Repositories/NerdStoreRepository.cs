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
                                                output Inserted.Id
                                                values (@login,@password)";

        public static string getUserCommand = @"SELECT TOP (1) [Password] ,[Login],[Id] from [NerdStoreEnterpriseDB].[dbo].[Usuario]
                                                where Login = @login";

        public static string getAllUsersCommand = @"SELECT [Password]
                                                            ,[Login]
                                                            ,[Id]
                                                            FROM [NerdStoreEnterpriseDB].[dbo].[Usuario] With(NOLOCK)";

        public static string changePasswordCommand = @"Update [NerdStoreEnterpriseDB].[dbo].[Usuario] set Password = @password where Id = @id";

        public static string deleteUserCOmmand = @"Delete [NerdStoreEnterpriseDB].[dbo].[Usuario] where Id = @id";


        public NerdStoreRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> AddUser(string login,string password)
        {
            return await _dapperContext.QueryFirstOrDefaultAsync<int>(addUserCommand, new { login, password });
        }

        public async Task<User> GetUser(string login)
        {
            return await _dapperContext.QueryFirstOrDefaultAsync<User>(getUserCommand, new { login });

        }

        public async Task<List<User>> GetUsers()
        {   
            var obj = await _dapperContext.QueryFirstOrDefaultAsync<List<User>>(getAllUsersCommand);
            return obj.ToList();
        }

        public async Task<int> DeleteUser(int id)
        {
             return await _dapperContext.ExecuteAsync(deleteUserCOmmand, new { id });

        }

        public async Task<int> ChangePassword(int id,string password)
        {
            return await _dapperContext.ExecuteAsync(changePasswordCommand, new { id , password });

        }
    }
}
