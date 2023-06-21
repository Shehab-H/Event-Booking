using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventInstance<SeatedReservation>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Span_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Span_End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInstance<SeatedReservation>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventInstance<StandingReservation>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Span_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Span_End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInstance<StandingReservation>", x => x.Id);
                });

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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
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
                name: "SeatedReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventInstanceSeatedReservationId = table.Column<int>(name: "EventInstance<SeatedReservation>Id", type: "int", nullable: true),
                    SerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatedReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatedReservations_EventInstance<SeatedReservation>_EventInstance<SeatedReservation>Id",
                        column: x => x.EventInstanceSeatedReservationId,
                        principalTable: "EventInstance<SeatedReservation>",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StandingReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    EventInstanceStandingReservationId = table.Column<int>(name: "EventInstance<StandingReservation>Id", type: "int", nullable: true),
                    SerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandingReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandingReservations_EventInstance<StandingReservation>_EventInstance<StandingReservation>Id",
                        column: x => x.EventInstanceStandingReservationId,
                        principalTable: "EventInstance<StandingReservation>",
                        principalColumn: "Id");
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
                        name: "FK_StandingEventInstances_EventInstance<StandingReservation>_Id",
                        column: x => x.Id,
                        principalTable: "EventInstance<StandingReservation>",
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
                        name: "FK_SeatedEventInstances_EventInstance<SeatedReservation>_Id",
                        column: x => x.Id,
                        principalTable: "EventInstance<SeatedReservation>",
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
                name: "VenuesWithSeats_BookedSlots",
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
                    table.PrimaryKey("PK_VenuesWithSeats_BookedSlots", x => new { x.VenueWithSeatsId, x.Id });
                    table.ForeignKey(
                        name: "FK_VenuesWithSeats_BookedSlots_VenuesWithSeats_VenueWithSeatsId",
                        column: x => x.VenueWithSeatsId,
                        principalTable: "VenuesWithSeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatSeatedReservation",
                columns: table => new
                {
                    SeatedReservationId = table.Column<int>(type: "int", nullable: false),
                    SeatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatSeatedReservation", x => new { x.SeatedReservationId, x.SeatsId });
                    table.ForeignKey(
                        name: "FK_SeatSeatedReservation_SeatedReservations_SeatedReservationId",
                        column: x => x.SeatedReservationId,
                        principalTable: "SeatedReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatSeatedReservation_Seats_SeatsId",
                        column: x => x.SeatsId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatedEventInstances_VenueId",
                table: "SeatedEventInstances",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatedReservations_EventInstance<SeatedReservation>Id",
                table: "SeatedReservations",
                column: "EventInstance<SeatedReservation>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_VenueWithSeatsId",
                table: "Seats",
                column: "VenueWithSeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatSeatedReservation_SeatsId",
                table: "SeatSeatedReservation",
                column: "SeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_StandingEventInstances_VenueId",
                table: "StandingEventInstances",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_StandingReservations_EventInstance<StandingReservation>Id",
                table: "StandingReservations",
                column: "EventInstance<StandingReservation>Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "SeatedEventInstances");

            migrationBuilder.DropTable(
                name: "SeatSeatedReservation");

            migrationBuilder.DropTable(
                name: "StandingEventInstances");

            migrationBuilder.DropTable(
                name: "StandingReservations");

            migrationBuilder.DropTable(
                name: "VenuesWithSeats_BookedSlots");

            migrationBuilder.DropTable(
                name: "SeatedReservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "EventInstance<StandingReservation>");

            migrationBuilder.DropTable(
                name: "EventInstance<SeatedReservation>");

            migrationBuilder.DropTable(
                name: "VenuesWithSeats");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
