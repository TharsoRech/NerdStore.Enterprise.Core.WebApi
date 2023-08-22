using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Core.Application.Dtos;
using NerdStore.Enterprise.Core.Application.Interfaces;
using NerdStore.Enterprise.Core.Domain.Entities;

namespace NerdStore.Enterprise.Core.WebApi.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        private readonly ILoginApplication _loginApplication;

        public LoginController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginDtoUser user)
        {
            return Ok(await _loginApplication.Login(user));
        }
    }
}
