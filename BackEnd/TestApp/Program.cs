using Core.Entities;
using Infrastructure.Data;
using System.Net.Http.Headers;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Seat> Seats = new List<Seat>();

            for (int i = 1; i <= 150; i++)
            {
                Seats.Add(new Seat('A', 1));
            }

            VenueWithSeats Venue = new VenueWithSeats("Imax Americana Blaza",Seats);
            try
            {
                Event e = new Event("Guardians Of The Galaxy Vol 3", "Movie", "/images/event.png", "/images/event.png");
                EventIterationWithSeats eventIteration = new EventIterationWithSeats(
                    new VenueWithSeats("Americana Blaza", Seats),
                    DateTime.Now,
                    DateTime.Now
                    );
                eventIteration.Book(new Seat('A', 10));

                foreach(var seat in eventIteration.AvailbleSeats)
                {
                    Console.WriteLine(seat);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            try
            {
            }
            catch(Exception ex) 
            {
            }

        }
    }
}