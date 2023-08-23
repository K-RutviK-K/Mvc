using jwtApi.Dtos;
using jwtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtdbContext _dbContext;
        //public AuthController(JwtdbContext jwtdbContext)
        //{
        //    _dbContext = jwtdbContext;
        //}

        IConfiguration configuration;
        public AuthController(IConfiguration configuration, JwtdbContext jwtdbContext)
        {
            this.configuration = configuration;
            _dbContext = jwtdbContext;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth([FromBody] LoginReq body)
        {

            User user = _dbContext.Users.Where(x => x.Email.ToLower() == body.email.ToLower()).FirstOrDefault();
                if (user!=null)
                {
                    if (user.Password==body.password)
                    {
                        var issuer = configuration["Jwt:Issuer"];
                        var audience = configuration["Jwt:Audience"];
                        var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                        var signingCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha512Signature
                        );

                        var subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Role, user.Role)
                        });

                        var expires = DateTime.UtcNow.AddDays(1);

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = subject,
                            Expires = expires,
                            Issuer = issuer,
                            Audience = audience,
                            SigningCredentials = signingCredentials
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var jwtToken = tokenHandler.WriteToken(token);
                 
                        return Ok(new Response(new { token = jwtToken }, true, "Successfull", 201));
                    }
                    return Unauthorized(new Response(null, false, "Wrong Password", 401));
                }
            return NotFound(new Response(null, false, "Email Not Found", 404));
        }
    }
}
