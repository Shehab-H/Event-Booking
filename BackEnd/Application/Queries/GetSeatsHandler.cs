using Core.DTO_s;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    internal sealed class GetSeatsHandler : IRequestHandler<GetSeatsQuery, SeatsDto>
    {
        private readonly IEventInstancesRepository _repository;

        public GetSeatsHandler(IEventInstancesRepository repository)
        {
            _repository = repository;
        }
        public async Task<SeatsDto> Handle(GetSeatsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetEventInstanceSeats(request.eventInstanceId);
        }
    }
}
