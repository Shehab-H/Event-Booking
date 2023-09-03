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
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand,List<IdentityResult>>
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateUserHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task<List<IdentityResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {


            var user = new IdentityUser()
            {
                Email = request.Email,
                UserName = request.name
            };

            var isCreated = await _userManager.CreateAsync(user,request.Password);

            var isAdded = await _userManager.AddToRoleAsync(user, "User");

            return new List<IdentityResult>
            {
                isCreated,
                isAdded
            };

        }
    }
}
