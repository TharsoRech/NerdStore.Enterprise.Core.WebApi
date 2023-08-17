using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Core.Application.Interfaces;
using NerdStore.Enterprise.Core.Domain.Entities;

namespace NerdStore.Enterprise.Core.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/api/v1/[action]/")]
    public class UserController : BaseController
    {

        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication= userApplication;
        }

        [HttpPost()]
        public async Task<IActionResult> AddUser(User user)
        {
            await _userApplication.AddUser(user);
            return JsonOk(user);
        }
    }
}