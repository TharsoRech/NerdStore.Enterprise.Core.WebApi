using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Core.Application.Dtos;
using NerdStore.Enterprise.Core.Application.Interfaces;

namespace NerdStore.Enterprise.Core.WebApi.Controllers
{
    [Authorize("Bearer")]
    public class UserController : BaseController
    {

        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication= userApplication;
        }

        [HttpPost()]
        public async Task<IActionResult> AddUser(LoginDtoUser user)
        {
            await _userApplication.AddUser(user);
            return Ok(user);
        }
    }
}