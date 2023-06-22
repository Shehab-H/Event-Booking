using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<StandingEventInstance> StandingEventInstances { get; set; }
        public DbSet<SeatedEventInstance> SeatedEventInstances { get; set; }

        public DbSet<Venue> Venues { get; set;}
        public DbSet<VenueWithSeats> VenuesWithSeats { get; set; }

        public DbSet<Seat> Seats { get; set;}

        public DbSet<SeatedReservation> SeatedReservations { get; set; }

        public DbSet<StandingReservation> StandingReservations { get; set; }
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventInstance>(i =>
            {
                i.UseTpcMappingStrategy();
                i.HasOne(i => i.Event).WithMany();

            });

            modelBuilder.Entity<SeatedEventInstance>().Ignore(e => e.AllReservedSeats);

            modelBuilder.Entity<VenueWithSeats>().HasMany(v => v.Seats).WithOne();

            modelBuilder.Entity<Venue>().OwnsMany(v => v.BookedSlots);

            modelBuilder.Entity<SeatedReservation>().HasMany(s => s.Seats).WithMany();

            modelBuilder.Entity<StandingEventInstance>().
                Property(e => e.AvailableTicketTypes).
                HasConversion(
                a => JsonConvert.SerializeObject(a),
                json => JsonConvert.DeserializeObject<Dictionary<string, uint>>(json)).
                HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Venue>().ToTable("Venues");

            modelBuilder.Entity<VenueWithSeats>().ToTable("VenuesWithSeats");


            modelBuilder.Entity<SeatedEventInstance>(e =>
            {
                e.HasMany(h => h.Reservations).WithOne();
                e.OwnsOne(e => e.Span);
                e.HasOne(h => h.Venue).WithMany()
                .HasForeignKey(h => h.VenueId);
            });

            modelBuilder.Entity<StandingEventInstance>(e =>
            {
                e.HasMany(h => h.Reservations).WithOne();
                e.OwnsOne(e => e.Span);
                e.HasOne(h => h.Venue).WithMany()
                .HasForeignKey(h => h.VenueId);
            });

        }

    }
}
