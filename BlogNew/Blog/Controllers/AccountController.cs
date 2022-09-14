using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Blog.Controllers
{

    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("v1/accounts/")]
        public async Task<IActionResult> Post(
                [FromBody] RegisterViewModel model,
                [FromServices] BlogDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModels<string>(ModelState.GetErrors()));

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Email.Replace("@", "-").Replace(".", "-")
            };
            var password = PasswordGenerator.Generate(25);
            user.PasswordHash = PasswordHasher.Hash(password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModels<dynamic>(new
                {
                    user = user.Email,
                    password
                }));
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, new ResultViewModels<string>("05x99 - Este email já está cadastrado"));
            }
        }

        [HttpPost("v1/account/login")]
        public async IActionResult Login([FromBody] LoginViewNodel model,
            [FromServices] BlogDataContext context,
            [FromServices] TokenService tokenService)
        {
            if (ModelState.IsValid)
                return BadRequest(new ResultViewModels<string>(ModelState.GetErrors()));

            var user = await context
                .Users
                .AsNoTracking()
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null)
                return StatusCode(401, new ResultViewModels<string>("Usuário ou senha invaválidos"));

            if (!PasswordHasher.Verify(user.PasswordHash, model.Password))
                return StatusCode(401, new ResultViewModels<string>("Usuário ou senha invaválidos"));

            try
            {
                var token = tokenService.GenerateToken(user);
                return Ok(new ResultViewModels<string>(token, null));
            }
            catch
            {
                return StatusCode(500, new ResultViewModels<string>("05x4 - Falha interna no servidor"));
            }
        }

    }
}