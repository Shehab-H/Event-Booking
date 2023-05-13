using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Event> events { get; set; }
        public DbSet<EventIteration> eventIterations { get; set; }
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventIteration>().OwnsMany(i=>i.AvailableSeats);
            modelBuilder.Entity<Venu>().OwnsMany(i => i.Seats);
        }

    }
}
