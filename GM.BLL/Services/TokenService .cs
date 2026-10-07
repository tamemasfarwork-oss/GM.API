using GM.BLL.Interfaces;
using GM.BLL.Settings;
using GM.DAL.Domin;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwt;
        public TokenService(IOptions<JwtSettings> options) => _jwt = options.Value;

        public (string Token, DateTime ExpiresAt) Create(User user)
        {
            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new("full_name", $"{user.FirstName} {user.LastName}"),
             new("club_id", user.ClubId?.ToString() ?? ""),
             new("club_name", user.Club?.Name ?? ""),

        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(_jwt.ExpireMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            return (new JwtSecurityTokenHandler().WriteToken(token), expires);
        }
    }
}