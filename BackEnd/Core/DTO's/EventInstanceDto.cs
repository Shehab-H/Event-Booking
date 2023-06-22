using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO_s
{
    public record EventInstanceDto(int Id, TimeRange Span, List<string> Lounges);

}
