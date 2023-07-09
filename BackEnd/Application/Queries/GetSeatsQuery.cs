using Core.DTO_s;
using MediatR;

namespace Application.Queries
{
    public record  GetSeatsQuery(int eventInstanceId) : IRequest<SeatsDto>;
}
