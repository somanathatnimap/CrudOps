using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web;
using Authentication_using_forms.Models; 

namespace Authentication_using_forms
{
    public class JwtAuthentication
    {
      //  private static readonly string SecretKey = "hgiefhhfduufdg778ygu";
        private static readonly string SecretKey = "hgiefhhfduufdg778ygu1234567890abcdefghijklmno"; 

        public static string CreateJWTToken(string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email)
            };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:44384/",
                audience: "https://localhost:44384/",
                claims: claims,
                expires: DateTime.Now.AddMinutes(20), 
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static ClaimsPrincipal ValidatejwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = key,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero 
            }, out var securityToken);

            var jwt = securityToken as JwtSecurityToken;
            var id = new ClaimsIdentity(jwt.Claims, "jwt", ClaimTypes.Name, ClaimTypes.Role);

            return new ClaimsPrincipal(id);
        }

        public static void AuthenticationRequest(string token)
        {
            var principal = ValidatejwtToken(token);
            HttpContext.Current.User = principal;
            Thread.CurrentPrincipal = principal;
        }
    }
}
