using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackGroundUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventsInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Span_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Span_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsInstances_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venues_BookedSlots",
                columns: table => new
                {
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues_BookedSlots", x => new { x.VenueId, x.Id });
                    table.ForeignKey(
                        name: "FK_Venues_BookedSlots_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenuesWithSeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Lounge = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenuesWithSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenuesWithSeats_Venues_Id",
                        column: x => x.Id,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandingEventInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    AvailableTicketTypes = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandingEventInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandingEventInstances_EventsInstances_Id",
                        column: x => x.Id,
                        principalTable: "EventsInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandingEventInstances_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatedEventInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatedEventInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatedEventInstances_EventsInstances_Id",
                        column: x => x.Id,
                        principalTable: "EventsInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatedEventInstances_VenuesWithSeats_VenueId",
                        column: x => x.VenueId,
                        principalTable: "VenuesWithSeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    VenueWithSeatsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_VenuesWithSeats_VenueWithSeatsId",
                        column: x => x.VenueWithSeatsId,
                        principalTable: "VenuesWithSeats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StandingReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TicketType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    StandingEventInstanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandingReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandingReservations_Reservations_Id",
                        column: x => x.Id,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandingReservations_StandingEventInstances_StandingEventInstanceId",
                        column: x => x.StandingEventInstanceId,
                        principalTable: "StandingEventInstances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeatedReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SeatedEventInstanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatedReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatedReservations_Reservations_Id",
                        column: x => x.Id,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatedReservations_SeatedEventInstances_SeatedEventInstanceId",
                        column: x => x.SeatedEventInstanceId,
                        principalTable: "SeatedEventInstances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeatSeatedReservation",
                columns: table => new
                {
                    BookedSeatsId = table.Column<int>(type: "int", nullable: false),
                    SeatedReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatSeatedReservation", x => new { x.BookedSeatsId, x.SeatedReservationId });
                    table.ForeignKey(
                        name: "FK_SeatSeatedReservation_SeatedReservations_SeatedReservationId",
                        column: x => x.SeatedReservationId,
                        principalTable: "SeatedReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatSeatedReservation_Seats_BookedSeatsId",
                        column: x => x.BookedSeatsId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsInstances_EventId",
                table: "EventsInstances",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatedEventInstances_VenueId",
                table: "SeatedEventInstances",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatedReservations_SeatedEventInstanceId",
                table: "SeatedReservations",
                column: "SeatedEventInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_VenueWithSeatsId",
                table: "Seats",
                column: "VenueWithSeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatSeatedReservation_SeatedReservationId",
                table: "SeatSeatedReservation",
                column: "SeatedReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_StandingEventInstances_VenueId",
                table: "StandingEventInstances",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_StandingReservations_StandingEventInstanceId",
                table: "StandingReservations",
                column: "StandingEventInstanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatSeatedReservation");

            migrationBuilder.DropTable(
                name: "StandingReservations");

            migrationBuilder.DropTable(
                name: "Venues_BookedSlots");

            migrationBuilder.DropTable(
                name: "SeatedReservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "StandingEventInstances");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "SeatedEventInstances");

            migrationBuilder.DropTable(
                name: "EventsInstances");

            migrationBuilder.DropTable(
                name: "VenuesWithSeats");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
