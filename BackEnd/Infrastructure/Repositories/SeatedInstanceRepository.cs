using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SeatedInstanceRepository : ISeatedInstanceRepository
    {
        private readonly BookingDbContext _dbContext;
        public SeatedInstanceRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddSeatedInstance(SeatedEventInstance seatedEventInstance)
        {
            ArgumentNullException.ThrowIfNull(seatedEventInstance);

            await _dbContext.AddAsync(seatedEventInstance);
        }
        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
