using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO_s
{
    public record AddEventDto(
         string name,
         string type,
         string descriptionTitle,
         string description
        );
}
