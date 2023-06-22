using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
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

        public BookingService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public  void Book(int eventInstanceId,string ticketType,uint quantity)
        {
            var instance = _eventRepository.GetStandingInstance(eventInstanceId);


            instance.MakeReservation(new StandingReservation(ticketType, quantity));

        }

        public void Book(int eventInstanceId, ICollection<int> seatIds)
        {
            var seats = _eventRepository.GetSeats(seatIds);


            var instance = _eventRepository.GetSeatedInstance(eventInstanceId);

            var missingSeatIds = seatIds.Except(seats.Select(s => s.Id));

            if (missingSeatIds.Any())
            {
                throw new Exception($"some of the seats doesn't exist");
            }

            instance.MakeReservation(new SeatedReservation(seats));

            _eventRepository.SaveChanges();
        }


    }
}
