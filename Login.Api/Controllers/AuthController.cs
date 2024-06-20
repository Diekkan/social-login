using Login.Api.Helpers;
using Login.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Login.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<Response> Register(RegisterDTO dto)
        {
            if(dto.Password != dto.ConfirmPassword)
            {
                return new Response("Passwords must match");
            }

            User user = new(dto);

            try
            {
                var result = await _userManager.CreateAsync(user, dto.Password);

                if (result.Succeeded)
                {
                    return new Response(true);
                }
                else {
                    return new Response("Can't register at the moment");
                }
            }
            catch(Exception e)
            {
                return new Response(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<Response> Login(LoginDTO dto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if(user == null)
                {
                    return new Response("User doesn't exist");
                }

                var result = await _signInManager.UserManager.CheckPasswordAsync(user, dto.Password);
                if (result)
                {
                    var token = TokenHelper.GenerateToken(user, _configuration.GetSection("Jwt")["Key"]);
                    return new Response(new UserDTO(user, token));
                }
                else
                {
                    return new Response("Invalid credentials");
                }
            }
            catch (Exception e)
            {
                return new Response(e.Message);
            }
        }

        public string UserID
        {
            get
            {
                var claim = User.Claims.FirstOrDefault(x => x.Type == "UserID");
                if (claim == null)
                    return "";
                return claim.Value;

            }
        }
    }
}
