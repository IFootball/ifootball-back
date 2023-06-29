using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IFootball.WebApi.Security
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(LoginUserResponse user)
        {
            var token_handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenSettings.SecretKey);
            var token_descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.User.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.User.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(TokenSettings.ExpiresInHours),
                SigningCredentials = new SigningCredentials( 
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };
            var token = token_handler.CreateToken(token_descriptor);

            return token_handler.WriteToken(token);
        }

    }
}
