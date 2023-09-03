using Application.Dto_s;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record UserLoginCommand
        (
        [Required]
        string email ,
        [Required]
        string password
        ):IRequest<LoginResult>;
}
