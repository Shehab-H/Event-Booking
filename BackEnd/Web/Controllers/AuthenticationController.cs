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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMediator _mediator;
        public AuthenticationController(UserManager<IdentityUser> userManager
            ,IOptionsMonitor<JwtConfig> optionsMonitor
            , IMediator mediator
            )
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _mediator = mediator;
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

                var user = new IdentityUser()
                {
                    Email = command.Email,
                };
                var token = GenerateJwtToken(user);

                var result = new AuthResult(token, true, new());

                return Ok(result);

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

                    var token = GenerateJwtToken(login.user);

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
        [Route("[action]")]
        [Authorize]
        public  IActionResult GetUserCredentials()
        {
            var roles =  User.Claims.Select(s=>s.Value).ToList();
            return Ok(roles);
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHanlder = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDiscriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id",user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                }),

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
