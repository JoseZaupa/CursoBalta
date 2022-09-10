using Blog.Service;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly TokenService _tokenService;
        public AccountController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost("v1/login")]
        public IActionResult Login()
        {
            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(null);
            return Ok(token);
        }
    }
}