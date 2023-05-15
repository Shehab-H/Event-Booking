using Core.Entities;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Event e = new Event("Guardians Of The Galaxy Vol 3", "Movie", "", "");
            Venu venu = new Venu("Americana Blaza");
            ICollection<Ticket> tickets = new List<Ticket>();
            tickets.Add(new TicketWithSeat(50, 'A', "1"));
            tickets.Add(new TicketWithType(50, "Regular"));
            EventIteration eventIteration = new EventIteration(new DateTime(2023,7,8,9,0,0)
                ,new DateTime(2023,7,8,11,0,0),venu, tickets);

            Ticket t = new TicketWithSeat(50, 'A', "2");
            try
            {
                eventIteration.Book(t);
                foreach (var item in tickets)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
      
        }
    }
}