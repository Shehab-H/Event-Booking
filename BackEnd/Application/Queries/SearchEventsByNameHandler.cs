using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Queries
{
    internal class SearchEventsByNameHandler : IRequestHandler<SearchEventsByNameQuery, ICollection<Event>>
    {
        private readonly IEventRepository _eventRepository;
        public SearchEventsByNameHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<ICollection<Event>> Handle(Queries.SearchEventsByNameQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.SearchByName(request.name);
        }
    }
}
