using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VenuesTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventITerationWithoutSeats_Venue_VenueId",
                table: "EventITerationWithoutSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_EventIterationWithSeats_Venue_VenueId",
                table: "EventIterationWithSeats");

            migrationBuilder.DropTable(
                name: "Venue_Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venue",
                table: "Venue");

            migrationBuilder.RenameTable(
                name: "Venue",
                newName: "Venues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venues",
                table: "Venues",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Venues_Seats",
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
                    table.PrimaryKey("PK_Venues_Seats", x => new { x.VenueWithSeatsId, x.Id });
                    table.ForeignKey(
                        name: "FK_Venues_Seats_Venues_VenueWithSeatsId",
                        column: x => x.VenueWithSeatsId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EventITerationWithoutSeats_Venues_VenueId",
                table: "EventITerationWithoutSeats",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventIterationWithSeats_Venues_VenueId",
                table: "EventIterationWithSeats",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventITerationWithoutSeats_Venues_VenueId",
                table: "EventITerationWithoutSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_EventIterationWithSeats_Venues_VenueId",
                table: "EventIterationWithSeats");

            migrationBuilder.DropTable(
                name: "Venues_Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venues",
                table: "Venues");

            migrationBuilder.RenameTable(
                name: "Venues",
                newName: "Venue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venue",
                table: "Venue",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Venue_Seats",
                columns: table => new
                {
                    VenueWithSeatsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(1)", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_EventITerationWithoutSeats_Venue_VenueId",
                table: "EventITerationWithoutSeats",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventIterationWithSeats_Venue_VenueId",
                table: "EventIterationWithSeats",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
