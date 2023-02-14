using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using University_API_Backend.Models;

namespace University_API_Backend.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid id)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("id", userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.Now.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))

            };

            if(userAccounts.UserName == "Admin" ) 
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }else if(userAccounts.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));

            }
            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid id)
        {
            id = Guid.NewGuid();
            return GetClaims(userAccounts, id);
        }

        public static UserTokens GetTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var usrToken = new UserTokens();
                if(model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                //Obtener Clave secreta
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuserSingingKey);
                Guid id;

                //Expira en un dia
                DateTime expireTime = DateTime.Now.AddDays(1);

                //Validez del Token
                usrToken.Validity = expireTime.TimeOfDay;

                //GENERAR JWT 
                var jwToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuser,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256
                        )
                    );
                usrToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                usrToken.UserName= model.UserName;
                usrToken.Id = model.Id;
                usrToken.GuidId = id;
                return usrToken;
            }catch(Exception ex)
            {
                throw new Exception("Error generando JWT", ex);
            }
        }
    }
}
