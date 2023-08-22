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
            return Ok(await _userApplication.AddUser(user));
        }

        [HttpPut()]
        public async Task ChangePassword(ChagePasswordDTO chagePasswordDTO)
        {
            await _userApplication.ChangePassword(chagePasswordDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userApplication.GetUsers());
        }

        [HttpDelete()]
        public async Task DeleteUser(int id)
        {
           await _userApplication.Delete(id);
        }
    }
}