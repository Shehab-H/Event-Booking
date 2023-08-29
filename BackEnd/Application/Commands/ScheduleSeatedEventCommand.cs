using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record ScheduleSeatedEventCommand(
        int eventId 
        , DateTime start 
        , DateTime end 
        , int venueId
        ) : IRequest;
}
