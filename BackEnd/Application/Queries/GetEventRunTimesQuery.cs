using Core.DTO_s;
using MediatR;

namespace Application.Queries
{
    public record GetEventRunTimesQuery(int eventId, int venueId):IRequest<ICollection<EventRunTimesDto>>;
    
}
