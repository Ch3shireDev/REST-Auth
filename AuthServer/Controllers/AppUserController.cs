using System.Security.Claims;
using System.Threading.Tasks;
using AuthServer.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers
{
    [Route("/")]
    [ApiController]
    public class AppUserController : Controller
    {
        private readonly AppUserContext _context;
        private readonly UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AppUserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            AppUserContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public class UserData
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserData userData)
        {
            var username = userData.username;
            var password = userData.password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new AppUser { UserName = username, PasswordHash = password.ToSha256() };

            var result = await _userManager.CreateAsync(user, password);
            //await _userManager.AddClaimAsync(user, new Claim("userName", user.UserName));
            //await _userManager.AddClaimAsync(user, new Claim("role", "user"));
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok("User registered");
        }
    }
}