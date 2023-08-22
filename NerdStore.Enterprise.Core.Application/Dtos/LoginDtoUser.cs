using NerdStore.Enterprise.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Enterprise.Core.Application.Dtos
{
    public class LoginDtoUser
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public User ToEntity(LoginDtoUser loginDtoUser)
        {
            return new User { Login = loginDtoUser.Login, Password = loginDtoUser.Password };
        }
    }
}
