using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookingService : IbookingService
    {
        private readonly  IEventRepository _eventRepository;

        public BookingService(IEventRepository eventRepositor)
        {
            _eventRepository = eventRepositor;
        }
        public void Book(int eventInstanceId,string ticketType,uint quantity)
        {
            var reservation = new StandingReservation(ticketType, quantity);


            var instance = _eventRepository.GetStandingInstance(eventInstanceId);

            instance.MakeReservation(reservation);

            _eventRepository.SaveChanges();

        }

        public  void Book(int eventInstanceId, ICollection<int> seatIds)
        {
            var seats = _eventRepository.GetSeats(seatIds);


            var instance = _eventRepository.GetSeatedInstance(eventInstanceId);

            var missingSeatIds = seatIds.Except(seats.Select(s => s.Id));

            if (missingSeatIds.Any())
            {
                throw new Exception($"some of the seats doesn't exist");
            }
            var reservation = new SeatedReservation(seats);


            instance.MakeReservation(reservation);

            _eventRepository.SaveChanges();

        }


    }
}
