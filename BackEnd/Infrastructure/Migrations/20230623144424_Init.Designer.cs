﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20230623144424_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackGroundUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Core.Entities.EventInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventsInstances");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Core.Entities.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Row")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("VenueWithSeatsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueWithSeatsId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Core.Entities.SeatedReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("SeatedEventInstanceId")
                        .HasColumnType("int");

                    b.Property<Guid>("SerialNumber")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SeatedEventInstanceId");

                    b.ToTable("SeatedReservations");
                });

            modelBuilder.Entity("Core.Entities.StandingReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SerialNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("StandingEventInstanceId")
                        .HasColumnType("int");

                    b.Property<string>("TicketType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StandingEventInstanceId");

                    b.ToTable("StandingReservations");
                });

            modelBuilder.Entity("Core.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Venues", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SeatSeatedReservation", b =>
                {
                    b.Property<int>("SeatedReservationId")
                        .HasColumnType("int");

                    b.Property<int>("SeatsId")
                        .HasColumnType("int");

                    b.HasKey("SeatedReservationId", "SeatsId");

                    b.HasIndex("SeatsId");

                    b.ToTable("SeatSeatedReservation");
                });

            modelBuilder.Entity("Core.Entities.SeatedEventInstance", b =>
                {
                    b.HasBaseType("Core.Entities.EventInstance");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasIndex("VenueId");

                    b.ToTable("SeatedEventInstances");
                });

            modelBuilder.Entity("Core.Entities.StandingEventInstance", b =>
                {
                    b.HasBaseType("Core.Entities.EventInstance");

                    b.Property<string>("AvailableTicketTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasIndex("VenueId");

                    b.ToTable("StandingEventInstances");
                });

            modelBuilder.Entity("Core.Entities.VenueWithSeats", b =>
                {
                    b.HasBaseType("Core.Entities.Venue");

                    b.Property<string>("Lounge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("VenuesWithSeats", (string)null);
                });

            modelBuilder.Entity("Core.Entities.EventInstance", b =>
                {
                    b.HasOne("Core.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Core.Entities.Seat", b =>
                {
                    b.HasOne("Core.Entities.VenueWithSeats", null)
                        .WithMany("Seats")
                        .HasForeignKey("VenueWithSeatsId");
                });

            modelBuilder.Entity("Core.Entities.SeatedReservation", b =>
                {
                    b.HasOne("Core.Entities.SeatedEventInstance", null)
                        .WithMany("Reservations")
                        .HasForeignKey("SeatedEventInstanceId");
                });

            modelBuilder.Entity("Core.Entities.StandingReservation", b =>
                {
                    b.HasOne("Core.Entities.StandingEventInstance", null)
                        .WithMany("Reservations")
                        .HasForeignKey("StandingEventInstanceId");
                });

            modelBuilder.Entity("Core.Entities.Venue", b =>
                {
                    b.OwnsMany("Core.Entities.TimeRange", "BookedSlots", b1 =>
                        {
                            b1.Property<int>("VenueId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");

                            b1.HasKey("VenueId", "Id");

                            b1.ToTable("Venues_BookedSlots");

                            b1.WithOwner()
                                .HasForeignKey("VenueId");
                        });

                    b.Navigation("BookedSlots");
                });

            modelBuilder.Entity("SeatSeatedReservation", b =>
                {
                    b.HasOne("Core.Entities.SeatedReservation", null)
                        .WithMany()
                        .HasForeignKey("SeatedReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Seat", null)
                        .WithMany()
                        .HasForeignKey("SeatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.SeatedEventInstance", b =>
                {
                    b.HasOne("Core.Entities.EventInstance", null)
                        .WithOne()
                        .HasForeignKey("Core.Entities.SeatedEventInstance", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.VenueWithSeats", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Core.Entities.TimeRange", "Span", b1 =>
                        {
                            b1.Property<int>("SeatedEventInstanceId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");

                            b1.HasKey("SeatedEventInstanceId");

                            b1.ToTable("SeatedEventInstances");

                            b1.WithOwner()
                                .HasForeignKey("SeatedEventInstanceId");
                        });

                    b.Navigation("Span")
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Core.Entities.StandingEventInstance", b =>
                {
                    b.HasOne("Core.Entities.EventInstance", null)
                        .WithOne()
                        .HasForeignKey("Core.Entities.StandingEventInstance", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Core.Entities.TimeRange", "Span", b1 =>
                        {
                            b1.Property<int>("StandingEventInstanceId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");

                            b1.HasKey("StandingEventInstanceId");

                            b1.ToTable("StandingEventInstances");

                            b1.WithOwner()
                                .HasForeignKey("StandingEventInstanceId");
                        });

                    b.Navigation("Span")
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Core.Entities.VenueWithSeats", b =>
                {
                    b.HasOne("Core.Entities.Venue", null)
                        .WithOne()
                        .HasForeignKey("Core.Entities.VenueWithSeats", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.SeatedEventInstance", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Core.Entities.StandingEventInstance", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Core.Entities.VenueWithSeats", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}