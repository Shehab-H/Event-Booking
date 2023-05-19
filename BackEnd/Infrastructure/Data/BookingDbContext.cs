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
        public DbSet<EventITerationWithoutSeats> EventiterationsWithoutSeats { get; set; }
        public DbSet<EventIterationWithSeats> EventiterationsWithSeats { get; set; }

        public DbSet<Venue> Venues { get; set; }
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venue>().ToTable("Venues");
            modelBuilder.Entity<EventIterationWithSeats>().ToTable("EventIterationWithSeats");
            modelBuilder.Entity<EventITerationWithoutSeats>().ToTable("EventITerationWithoutSeats");
            modelBuilder.Entity<EventIterationWithSeats>().OwnsMany(i => i.AvailbleSeats);
            modelBuilder.Entity<VenueWithSeats>().OwnsMany(i => i.Seats);

        }

    }
}
