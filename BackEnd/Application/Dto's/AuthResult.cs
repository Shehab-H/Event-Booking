using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s
{
    public record AuthResult(
       string token,
       bool result,
       List<string> Errors
       );

}
