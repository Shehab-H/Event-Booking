using Application.Dto_s;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    internal class UserLoginHandler : IRequestHandler<UserLoginCommand, LoginResult>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserLoginHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<LoginResult> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);

            if (user == null)
                throw new Exception("email doesn't exist");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.password);

            if (!isPasswordValid)  
               throw new Exception("incorrect password or email");

            var roles = await _userManager.GetRolesAsync(user);

            return new LoginResult(user,roles);

        }
    }
}
