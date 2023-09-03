
using Application.Dto_s;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Application.Commands
{
    public record CreateUserCommand(
        [Required]
        string name,
        [Required]
        string Email,
        [Required]
        string Password
        ):IRequest<List<IdentityResult>>;
}
