using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using mvcSix.Models;
using mvcSix.Models.ViewModels;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mvcSix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JwtdbContext _jwtdbContext;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger,JwtdbContext jwtdbContext,IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtdbContext = jwtdbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            var isUserExist=_jwtdbContext.Users.FirstOrDefault(x => x.Email == login.Email);
            if (isUserExist != null)
            {
                var isUserValid=_jwtdbContext.Users.FirstOrDefault(x => x.Password == login.Password);
                if (isUserValid != null)
                {
                    var tokenDescripter = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        { new Claim(ClaimTypes.Email, isUserExist.Email),
                            new Claim(ClaimTypes.Role, isUserExist.Role)
                        }),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt").GetSection("Key").Value)),SecurityAlgorithms.HmacSha512Signature),
                        Expires = DateTime.UtcNow.AddDays(1),
                        Issuer= _configuration.GetSection("Jwt").GetSection("Issuer").Value,
                        Audience= _configuration.GetSection("Jwt").GetSection("Audience").Value,

                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescripter);
                    var jwtToken = tokenHandler.WriteToken(token);
                    return Json(new { token=jwtToken,success = true, message = "Logged in" });
                }
                else
                {
                    return Json(new { success = false ,message="wrong password"});
                }
            }
            else
            {
                return Json(new { success=false,message="Email does not exists"});

            }
        }


    }
}