using NerdStore.Enterprise.Core.Application.Dtos;
using NerdStore.Enterprise.Core.Application.Interfaces;
using NerdStore.Enterprise.Core.Domain.Entities;
using NerdStore.Enterprise.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Core.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _userService;

        public UserApplication(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<int> AddUser(LoginDtoUser user)
        {
            return await _userService.AddUser(user.ToEntity(user));
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        public async Task Delete(int id)
        {
            await _userService.DeleteUser(id);
        }

        public async Task ChangePassword(ChagePasswordDTO chagePassword)
        {
            await _userService.ChangePassword(chagePassword.Id, chagePassword.Password);
        }
    }
}
