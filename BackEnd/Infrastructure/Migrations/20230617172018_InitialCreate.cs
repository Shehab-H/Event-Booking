using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackGroundUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lounge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    VenueWithSeatsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seat_Venues_VenueWithSeatsId",
                        column: x => x.VenueWithSeatsId,
                        principalTable: "Venues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeatedEventInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Span_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Span_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatedEventInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatedEventInstances_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatedEventInstances_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandingEventInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Span_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Span_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    AvailableTicketTypes = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandingEventInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandingEventInstances_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandingEventInstances_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venues_BookedSlots",
                columns: table => new
                {
                    VenueWithSeatsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues_BookedSlots", x => new { x.VenueWithSeatsId, x.Id });
                    table.ForeignKey(
                        name: "FK_Venues_BookedSlots_Venues_VenueWithSeatsId",
                        column: x => x.VenueWithSeatsId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatedReservations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatedEventInstanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatedReservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SeatedReservations_SeatedEventInstances_SeatedEventInstanceId",
                        column: x => x.SeatedEventInstanceId,
                        principalTable: "SeatedEventInstances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "standingReservations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    StandingEventInstanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_standingReservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_standingReservations_StandingEventInstances_StandingEventInstanceId",
                        column: x => x.StandingEventInstanceId,
                        principalTable: "StandingEventInstances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeatSeatedReservation",
                columns: table => new
                {
                    SeatedReservationID = table.Column<int>(type: "int", nullable: false),
                    SeatsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatSeatedReservation", x => new { x.SeatedReservationID, x.SeatsID });
                    table.ForeignKey(
                        name: "FK_SeatSeatedReservation_Seat_SeatsID",
                        column: x => x.SeatsID,
                        principalTable: "Seat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatSeatedReservation_SeatedReservations_SeatedReservationID",
                        column: x => x.SeatedReservationID,
                        principalTable: "SeatedReservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_VenueWithSeatsId",
                table: "Seat",
                column: "VenueWithSeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatedEventInstances_EventId",
                table: "SeatedEventInstances",
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
                name: "IX_SeatSeatedReservation_SeatsID",
                table: "SeatSeatedReservation",
                column: "SeatsID");

            migrationBuilder.CreateIndex(
                name: "IX_StandingEventInstances_EventId",
                table: "StandingEventInstances",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_StandingEventInstances_VenueId",
                table: "StandingEventInstances",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_standingReservations_StandingEventInstanceId",
                table: "standingReservations",
                column: "StandingEventInstanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatSeatedReservation");

            migrationBuilder.DropTable(
                name: "standingReservations");

            migrationBuilder.DropTable(
                name: "Venues_BookedSlots");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "SeatedReservations");

            migrationBuilder.DropTable(
                name: "StandingEventInstances");

            migrationBuilder.DropTable(
                name: "SeatedEventInstances");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "events");
        }
    }
}
