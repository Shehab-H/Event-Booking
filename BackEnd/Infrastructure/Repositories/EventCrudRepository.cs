using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;


namespace Infrastructure.Repositories
{
    public class EventCrudRepository : IEventCrudRepository
    {
        private readonly BookingDbContext _dbContext;
        public EventCrudRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddEventAsync(Event @event)
        {
            ArgumentNullException.ThrowIfNull(nameof(@event));

            var e  = _dbContext.Events.Where(e=>e.Name == @event.Name).FirstOrDefault();
            if( e!=null )
            {
                throw new Exception("event with the same name already exists");
            }

            await _dbContext.Events.AddAsync(@event);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

    }
}
