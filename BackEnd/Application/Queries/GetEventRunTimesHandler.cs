using Core.DTO_s;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Queries
{
    internal sealed class GetEventRunTimesHandler : IRequestHandler<GetEventRunTimesQuery, ICollection<EventRunTimesDto>>
    {
        private readonly IEventInstancesRepository _eventRepository;
        public GetEventRunTimesHandler(IEventInstancesRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<ICollection<EventRunTimesDto>> Handle(GetEventRunTimesQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetTimeSpans(request.venueId, request.eventId);

        }
    }
}
