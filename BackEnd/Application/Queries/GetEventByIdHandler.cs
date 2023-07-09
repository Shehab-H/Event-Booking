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
    internal class GetEventByIdHandler : IRequestHandler<GetEventByIdQuery,Event>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByIdHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_eventRepository.GetEvent(request.eventId));
        }
    }
}
