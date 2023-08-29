using Core.DTO_s;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Queries
{
    internal class SearchEventsByNameHandler : IRequestHandler<SearchEventsByNameQuery, ICollection<SearchEventDto>>
    {
        private readonly IEventRepository _eventRepository;
        public SearchEventsByNameHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<ICollection<SearchEventDto>> Handle(SearchEventsByNameQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.SearchByName(request.name);
        }
    }
}
