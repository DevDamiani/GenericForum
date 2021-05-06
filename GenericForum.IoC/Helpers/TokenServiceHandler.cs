using GenericForum.Model.Entity;
using GenericForum.Model.Interfaces.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GenericForum.API.Helper
{
    public class TokenHelperHandler : ITokenHelper
    {

        private string _securityKey { get; }

        public TokenHelperHandler()
        {
            _securityKey = "bd9f61f4-65e4-4de5-9f27-69be0c2b222e";
        }

        public string GenerateToken(ClientEntity client)
        {

            var dir = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, client.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, client.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "ForumGeneric.WebApp",
                audience: "Postman",
                claims: dir,
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public ClientEntity DecodeToken(string tokenString)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            tokenString = tokenString.Replace("Bearer ", "");

            var token = jwtHandler.ReadJwtToken(tokenString);

            return new ClientEntity()
            {
                ID = Int32.Parse(token.Claims.First(c => c.Type == JwtRegisteredClaimNames.NameId).Value)
            };
        }

    }
}
