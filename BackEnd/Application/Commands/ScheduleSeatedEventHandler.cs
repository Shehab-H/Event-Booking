using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    internal class ScheduleSeatedEventHandler : IRequestHandler<ScheduleSeatedEventCommand>
    {
        private IEventRepository _eventRepository;

        private ISeatedVenueRepository _seatedVenueRepository;
            
        private ISeatedInstanceRepository _seatedInstanceRepository;

        public ScheduleSeatedEventHandler(
            IEventRepository eventRepository,
            ISeatedVenueRepository seatedVenueRepository,
            ISeatedInstanceRepository seatedInstanceRepository
            )
        {
            _eventRepository = eventRepository;
            _seatedVenueRepository= seatedVenueRepository;
            _seatedInstanceRepository = seatedInstanceRepository;
        }
        public async Task Handle(ScheduleSeatedEventCommand request, CancellationToken cancellationToken)
        {

            // hint : change this bullshit to unit of work later please :D 

            var venue = await _seatedVenueRepository.Get(request.venueId);

            venue.BookSlot(new TimeRange(request.start, request.end));

            _eventRepository.GetEvent(request.eventId);

            var eventInstance = new SeatedEventInstance(
                request.venueId
                , new TimeRange(request.start, request.end)
                , request.eventId
                );

            await _seatedInstanceRepository.AddSeatedInstance(eventInstance);

            await _seatedVenueRepository.SaveChangesAsync();

            await _seatedInstanceRepository.SaveChangesAsync();

        }
    }
}
