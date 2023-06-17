using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixedNamingConventions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Venues_VenueWithSeatsId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatedEventInstances_Venues_VenueId",
                table: "SeatedEventInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatedEventInstances_events_EventId",
                table: "SeatedEventInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatSeatedReservation_Seat_SeatsID",
                table: "SeatSeatedReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatSeatedReservation_SeatedReservations_SeatedReservationID",
                table: "SeatSeatedReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_StandingEventInstances_Venues_VenueId",
                table: "StandingEventInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_StandingEventInstances_events_EventId",
                table: "StandingEventInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_standingReservations_StandingEventInstances_StandingEventInstanceId",
                table: "standingReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_standingReservations",
                table: "standingReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_events",
                table: "events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.RenameTable(
                name: "standingReservations",
                newName: "StandingReservations");

            migrationBuilder.RenameTable(
                name: "events",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameIndex(
                name: "IX_standingReservations_StandingEventInstanceId",
                table: "StandingReservations",
                newName: "IX_StandingReservations_StandingEventInstanceId");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "StandingEventInstances",
                newName: "VenueID");

            migrationBuilder.RenameIndex(
                name: "IX_StandingEventInstances_VenueId",
                table: "StandingEventInstances",
                newName: "IX_StandingEventInstances_VenueID");

            migrationBuilder.RenameColumn(
                name: "SeatsID",
                table: "SeatSeatedReservation",
                newName: "SeatsId");

            migrationBuilder.RenameColumn(
                name: "SeatedReservationID",
                table: "SeatSeatedReservation",
                newName: "SeatedReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_SeatSeatedReservation_SeatsID",
                table: "SeatSeatedReservation",
                newName: "IX_SeatSeatedReservation_SeatsId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SeatedReservations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "SeatedEventInstances",
                newName: "VenueID");

            migrationBuilder.RenameIndex(
                name: "IX_SeatedEventInstances_VenueId",
                table: "SeatedEventInstances",
                newName: "IX_SeatedEventInstances_VenueID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Seats",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_VenueWithSeatsId",
                table: "Seats",
                newName: "IX_Seats_VenueWithSeatsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StandingReservations",
                table: "StandingReservations",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatedEventInstances_Events_EventId",
                table: "SeatedEventInstances",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatedEventInstances_Venues_VenueID",
                table: "SeatedEventInstances",
                column: "VenueID",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Venues_VenueWithSeatsId",
                table: "Seats",
                column: "VenueWithSeatsId",
                principalTable: "Venues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatSeatedReservation_SeatedReservations_SeatedReservationId",
                table: "SeatSeatedReservation",
                column: "SeatedReservationId",
                principalTable: "SeatedReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatSeatedReservation_Seats_SeatsId",
                table: "SeatSeatedReservation",
                column: "SeatsId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandingEventInstances_Events_EventId",
                table: "StandingEventInstances",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandingEventInstances_Venues_VenueID",
                table: "StandingEventInstances",
                column: "VenueID",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandingReservations_StandingEventInstances_StandingEventInstanceId",
                table: "StandingReservations",
                column: "StandingEventInstanceId",
                principalTable: "StandingEventInstances",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatedEventInstances_Events_EventId",
                table: "SeatedEventInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatedEventInstances_Venues_VenueID",
                table: "SeatedEventInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Venues_VenueWithSeatsId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatSeatedReservation_SeatedReservations_SeatedReservationId",
                table: "SeatSeatedReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatSeatedReservation_Seats_SeatsId",
                table: "SeatSeatedReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_StandingEventInstances_Events_EventId",
                table: "StandingEventInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_StandingEventInstances_Venues_VenueID",
                table: "StandingEventInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_StandingReservations_StandingEventInstances_StandingEventInstanceId",
                table: "StandingReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StandingReservations",
                table: "StandingReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.RenameTable(
                name: "StandingReservations",
                newName: "standingReservations");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "events");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameIndex(
                name: "IX_StandingReservations_StandingEventInstanceId",
                table: "standingReservations",
                newName: "IX_standingReservations_StandingEventInstanceId");

            migrationBuilder.RenameColumn(
                name: "VenueID",
                table: "StandingEventInstances",
                newName: "VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_StandingEventInstances_VenueID",
                table: "StandingEventInstances",
                newName: "IX_StandingEventInstances_VenueId");

            migrationBuilder.RenameColumn(
                name: "SeatsId",
                table: "SeatSeatedReservation",
                newName: "SeatsID");

            migrationBuilder.RenameColumn(
                name: "SeatedReservationId",
                table: "SeatSeatedReservation",
                newName: "SeatedReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_SeatSeatedReservation_SeatsId",
                table: "SeatSeatedReservation",
                newName: "IX_SeatSeatedReservation_SeatsID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SeatedReservations",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "VenueID",
                table: "SeatedEventInstances",
                newName: "VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_SeatedEventInstances_VenueID",
                table: "SeatedEventInstances",
                newName: "IX_SeatedEventInstances_VenueId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Seat",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_VenueWithSeatsId",
                table: "Seat",
                newName: "IX_Seat_VenueWithSeatsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_standingReservations",
                table: "standingReservations",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_events",
                table: "events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Venues_VenueWithSeatsId",
                table: "Seat",
                column: "VenueWithSeatsId",
                principalTable: "Venues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatedEventInstances_Venues_VenueId",
                table: "SeatedEventInstances",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatedEventInstances_events_EventId",
                table: "SeatedEventInstances",
                column: "EventId",
                principalTable: "events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatSeatedReservation_Seat_SeatsID",
                table: "SeatSeatedReservation",
                column: "SeatsID",
                principalTable: "Seat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatSeatedReservation_SeatedReservations_SeatedReservationID",
                table: "SeatSeatedReservation",
                column: "SeatedReservationID",
                principalTable: "SeatedReservations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandingEventInstances_Venues_VenueId",
                table: "StandingEventInstances",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandingEventInstances_events_EventId",
                table: "StandingEventInstances",
                column: "EventId",
                principalTable: "events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_standingReservations_StandingEventInstances_StandingEventInstanceId",
                table: "standingReservations",
                column: "StandingEventInstanceId",
                principalTable: "StandingEventInstances",
                principalColumn: "Id");
        }
    }
}
