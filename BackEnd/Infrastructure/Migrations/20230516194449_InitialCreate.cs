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
                name: "Venue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventIteration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventIteration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventIteration_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Venue_Seats",
                columns: table => new
                {
                    VenueWithSeatsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue_Seats", x => new { x.VenueWithSeatsId, x.Id });
                    table.ForeignKey(
                        name: "FK_Venue_Seats_Venue_VenueWithSeatsId",
                        column: x => x.VenueWithSeatsId,
                        principalTable: "Venue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventITerationWithoutSeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventITerationWithoutSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventITerationWithoutSeats_EventIteration_Id",
                        column: x => x.Id,
                        principalTable: "EventIteration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventITerationWithoutSeats_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventIterationWithSeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventIterationWithSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventIterationWithSeats_EventIteration_Id",
                        column: x => x.Id,
                        principalTable: "EventIteration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventIterationWithSeats_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventIterationWithSeats_AvailbleSeats",
                columns: table => new
                {
                    EventIterationWithSeatsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventIterationWithSeats_AvailbleSeats", x => new { x.EventIterationWithSeatsId, x.Id });
                    table.ForeignKey(
                        name: "FK_EventIterationWithSeats_AvailbleSeats_EventIterationWithSeats_EventIterationWithSeatsId",
                        column: x => x.EventIterationWithSeatsId,
                        principalTable: "EventIterationWithSeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventIteration_EventId",
                table: "EventIteration",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventITerationWithoutSeats_VenueId",
                table: "EventITerationWithoutSeats",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_EventIterationWithSeats_VenueId",
                table: "EventIterationWithSeats",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventITerationWithoutSeats");

            migrationBuilder.DropTable(
                name: "EventIterationWithSeats_AvailbleSeats");

            migrationBuilder.DropTable(
                name: "Venue_Seats");

            migrationBuilder.DropTable(
                name: "EventIterationWithSeats");

            migrationBuilder.DropTable(
                name: "EventIteration");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "events");
        }
    }
}
