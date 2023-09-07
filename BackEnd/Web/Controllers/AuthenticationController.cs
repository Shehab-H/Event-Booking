using Application.Commands;
using Application.Dto_s;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web.Config;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly JwtConfig _jwtConfig;
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationController(
            IOptionsMonitor<JwtConfig> optionsMonitor
            , IMediator mediator
            , UserManager<IdentityUser> userManager
            )
        {
            _jwtConfig = optionsMonitor.CurrentValue;
            _mediator = mediator;
            _userManager = userManager;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register( CreateUserCommand command)
        {
            if(ModelState.IsValid)
            {
           
                    var Results = await _mediator.Send(command);

                    if (Results.Any(r=>!r.Succeeded))
                    {
                      return BadRequest(Results.SelectMany(r=>r.Errors).Select(x => x.Description).ToList());
                    }

                return Ok();

            }
            return BadRequest("invalid request payload");
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var login = await _mediator.Send(command);

                    var token = await GenerateJwtToken(login.user);

                    var result = new AuthResult(token, true, new());

                    return Ok(new { login.user.UserName,login.roles, authResult= result});;

                }
                catch(Exception ex)
                {
                    return BadRequest(new AuthResult("", false, new List<string>()
                    {
                        ex.Message
                    }));
                }
            }
            return BadRequest("invalid request payload");
        }

        [HttpGet]
        [Route("[action]/{role}")]
        [Authorize]
        public  IActionResult CheckRole(string role)
        {
            var userHasRole = User.IsInRole(role);
            return Ok(userHasRole);
        }

        private async Task<string> GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHanlder = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var claims = new List<Claim>
                {
                    new Claim("Id",user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
            var roles =  await _userManager.GetRolesAsync(user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenDiscriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                ,
                SecurityAlgorithms.HmacSha256
                
                )
            };

            var token = jwtTokenHanlder.CreateToken(tokenDiscriptor);

            var jwtToken = jwtTokenHanlder.WriteToken(token);

            return jwtToken;
        }



    }
}
