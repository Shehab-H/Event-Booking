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
    public class GetTrendingEventsHandler : IRequestHandler<GetTrendingEventsQuery, ICollection<Event>>
    {
        private readonly IEventRepository _eventRepository;

        public GetTrendingEventsHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<ICollection<Event>> Handle(GetTrendingEventsQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetTrendingEvents();
        }
    }
}
