using Core.Entities;
using MediatR;

namespace Application.Queries
{
    public record  GetEventsByDateRangeQuery(
        TimeRange Range
        ) : IRequest<ICollection<Event>>;
   
}
