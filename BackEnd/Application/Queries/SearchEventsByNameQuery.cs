using Core.Entities;
using MediatR;

namespace Application.Queries
{
    public record SearchEventsByNameQuery(string name) : IRequest<ICollection<Event>>;
}
