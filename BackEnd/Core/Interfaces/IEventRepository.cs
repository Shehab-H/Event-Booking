using Core.DTO_s;
using Core.Entities;


namespace Core.Interfaces
{
    public interface IEventRepository
    {
        public Event GetEvent(int id);

        public Task<ICollection<Event>> GetTrendingEvents(int take=10);
        public Task<ICollection<Event>> GetByDateRange(TimeRange Range);

        public Reservation GetReservation(Guid serialNumer);
        public int SaveChanges();

        public ICollection<SeatedVenueNamesDto> GetVenueNames(int eventId);

        public Task<ICollection<SearchEventDto>> SearchByName(string name);

    }
}
