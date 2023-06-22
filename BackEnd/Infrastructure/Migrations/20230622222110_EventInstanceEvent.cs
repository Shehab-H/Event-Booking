using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventInstanceEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "StandingEventInstances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "SeatedEventInstances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StandingEventInstances_EventId",
                table: "StandingEventInstances",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatedEventInstances_EventId",
                table: "SeatedEventInstances",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatedEventInstances_Events_EventId",
                table: "SeatedEventInstances",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandingEventInstances_Events_EventId",
                table: "StandingEventInstances",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatedEventInstances_Events_EventId",
                table: "SeatedEventInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_StandingEventInstances_Events_EventId",
                table: "StandingEventInstances");

            migrationBuilder.DropIndex(
                name: "IX_StandingEventInstances_EventId",
                table: "StandingEventInstances");

            migrationBuilder.DropIndex(
                name: "IX_SeatedEventInstances_EventId",
                table: "SeatedEventInstances");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "StandingEventInstances");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "SeatedEventInstances");
        }
    }
}
