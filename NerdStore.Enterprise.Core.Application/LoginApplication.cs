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
    public class LoginApplication : ILoginApplication
    {
        private readonly ILoginService _loginService;

        public LoginApplication(ILoginService loginService)
        {
            _loginService= loginService;
        }
        public async Task<Token> Login(LoginDtoUser user)
        {
           return await _loginService.Login(user.ToEntity(user));
        }
    }
}
