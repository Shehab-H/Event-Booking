using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Queries
{
    internal class GetEventsByDateRangeHandler : IRequestHandler<GetEventsByDateRangeQuery, ICollection<Event>>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventsByDateRangeHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<ICollection<Event>> Handle(GetEventsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var events = await _eventRepository.GetByDateRange(request.Range);
            if (events == null)
                throw new Exception("no events was found");

            return events;
        }
    }
}
