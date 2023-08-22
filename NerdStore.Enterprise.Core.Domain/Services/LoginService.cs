using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NerdStore.Enterprise.Core.Domain.Entities;
using NerdStore.Enterprise.Core.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace NerdStore.Enterprise.Core.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly INerdStoreRepository _nerdStoreRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IOptions<TokenConfigurations> _configuration;
        public LoginService(INerdStoreRepository nerdStoreRepository, ILogger<UserService> logger, IOptions<TokenConfigurations> settings)
        {
            _logger = logger;
            _nerdStoreRepository = nerdStoreRepository;
            _configuration = settings;
        }
        public async Task<Token> Login(User user)
        {
            try
            {
                var login = await _nerdStoreRepository.GetUser(user.Login);
                if (login?.Login != null && login?.Password != null)
                {
                    if(user.Password == login.Password)
                        return GenerateToken();

                }

                return null;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error to Logging ", ex);
                throw;
            }
        }

        private Token GenerateToken()
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.Value.SecretJwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                                   issuer: _configuration.Value.Issuer,
                                   audience: _configuration.Value.Audience,
                                   expires: DateTime.Now.AddDays(1),
                                   signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token
            {
                AccessToken = jwt,
                Authenticated = true,
                Created = DateTime.Now.ToString(),
                Expiration = DateTime.Now.AddDays(1).ToString(),
            };
        }
    }
}
