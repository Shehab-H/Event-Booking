using Core.DTO_s;
using MediatR;

namespace Application.Queries
{
    public record SearchEventsByNameQuery(string name) : IRequest<ICollection<SearchEventDto>>;
}
