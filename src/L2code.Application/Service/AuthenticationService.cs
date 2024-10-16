using L2code.Domain.Interfaces;
using L2code.Domain.Models;
using L2code.Domain.Responses;
using L2code.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace L2code.Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string SecretKey = "secret_key_99_999_9999_999999_99999999";

        public TokenResponse GenerateToken(User user)
        {
            var existingUser = UserStore.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (existingUser == null)
            {
                return new TokenResponse(StatusCodes.Status401Unauthorized);
            }

            var token = GenerateToken(user.Username);
            return new TokenResponse(StatusCodes.Status200OK, token);
        }

        private string GenerateToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}