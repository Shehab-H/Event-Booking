using Core.DTO_s;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public record GetVenuesQuery(
         int eventId
        ) : IRequest<ICollection<SeatedVenueNamesDto>>;
}
