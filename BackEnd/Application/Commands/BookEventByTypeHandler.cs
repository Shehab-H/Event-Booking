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
    internal class BookEventByTypeHandler : IRequestHandler<BookEventByTypeCommand>
    {
        private readonly IEventInstancesRepository _eventRepository;
        public BookEventByTypeHandler(IEventInstancesRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public  async Task Handle(BookEventByTypeCommand request, CancellationToken cancellationToken)
        {
            var reservation = new StandingReservation(request.ticketType, request.quantity);


            var instance = await _eventRepository.GetStandingInstance(request.eventInstanceId);

            if (instance == null)
                throw new Exception("event was not found");

            instance.MakeReservation(reservation);

            await _eventRepository.SaveChangesAsync();
        }
    }
}
