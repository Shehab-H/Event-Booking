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
    internal class BookEventBySeatsHandler : IRequestHandler<BookEventBySeatsCommand>
    {
        private readonly IEventInstancesRepository _repository;
        private readonly ISeatsRepository _seatsRepository;
        public BookEventBySeatsHandler(IEventInstancesRepository repository, ISeatsRepository seatsRepository)
        {
            _repository = repository;
            _seatsRepository = seatsRepository;

        }
        public async Task Handle(BookEventBySeatsCommand request, CancellationToken cancellationToken)
        {
            var seats = await _seatsRepository.GetSeats(request.seatIds);

            var instance = await _repository.GetSeatedInstance(request.eventInstanceId);

            var missingSeatIds = request.seatIds.Except(seats.Select(s => s.Id));

            if (missingSeatIds.Any())
            {
                throw new Exception($"some of the seats doesn't exist");
            }
            var reservation = new SeatedReservation(seats);

            instance.MakeReservation(reservation);

            await _repository.SaveChangesAsync();

        }
    }


}
