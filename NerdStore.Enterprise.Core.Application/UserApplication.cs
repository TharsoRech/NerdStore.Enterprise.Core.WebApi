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

        public async Task AddUser(LoginDtoUser user)
        {
            await _userService.AddUser(user.ToEntity(user));
        }
    }
}
