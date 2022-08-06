using Posterr.Domain.Entity;
using Posterr.Domain.Interfaces;
using Posterr.Domain.Interfaces.Services;
using Posterr.Shared.Kernel.Entity;
using Posterr.Shared.Kernel.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using Posterr.Application.SignalR;

namespace Posterr.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public IdentityService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public User Authenticate(string username, string password) =>
            _userRepository.GetByExpression(
                x => x.UserName == username && x.Password == Cryptography.PasswordEncrypt(password)
            )?.FirstOrDefault();

        public TokenJWT GetToken(Guid id, string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Name, username)
                };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
            );

            return new TokenJWT(true, new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
