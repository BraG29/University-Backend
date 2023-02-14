using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_API_Backend.Helpers;
using University_API_Backend.Models;

namespace University_API_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        private IEnumerable<Usuario> _logins = new List<Usuario>
        {
            new Usuario()
            {
                Id = 1,
                email = "admin@mail.com",
                nombre = "Admin",
                contrasenia = "Admin"
            },
            new Usuario()
            {
                Id = 2,
                email = "pepe@mail.com",
                nombre = "User1",
                contrasenia = "pepe"
            }
        };
        
        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        [HttpPost]
        public IActionResult GetToken(UserLogins usrLogin)
        {
            try
            {
                var Token = new UserTokens();
                var valid = _logins.Any(usr => usr.nombre.Equals(usrLogin.UserName, StringComparison.OrdinalIgnoreCase));
                if (valid)
                {
                    var user = _logins.FirstOrDefault(usr 
                        => usr.nombre.Equals(usrLogin.UserName, StringComparison.OrdinalIgnoreCase));
                    Token = JwtHelpers.GetTokenKey(new UserTokens()
                    {
                        UserName = user.nombre,
                        EmailId = user.email,
                        Id = user.Id,
                        GuidId = new Guid(),



                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Credentials");
                }
                return Ok(Token);
            }catch(Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        //Solo los administradores podrian acceder a esta ruta
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(_logins);
        }
    }
}
