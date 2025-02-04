using Furni.BusinessLayer.Abstract;
using Furni.DtoLayer.Dtos.TokenDtos;
using Furni.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Furni.BusinessLayer.Concrete
{
    public class TokenManager : ITokenService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtSettingsDto _jwtSettings;

        public TokenManager(UserManager<AppUser> userManager, IOptions<JwtSettingsDto> jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;

            if (string.IsNullOrEmpty(_jwtSettings.Key) || string.IsNullOrEmpty(_jwtSettings.Issuer) || string.IsNullOrEmpty(_jwtSettings.Audience))
            {
                throw new ArgumentNullException("JWT ayarları eksik veya hatalı.");
            }
        }

        public async Task<string> GenerateToken(AppUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles == null || userRoles.Count == 0)
            {
                userRoles = new List<string> { "User" };
            }
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var role in userRoles)
            {
                if (string.IsNullOrEmpty(role))
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Token oluşturuyoruz
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(_jwtSettings.Expires),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
