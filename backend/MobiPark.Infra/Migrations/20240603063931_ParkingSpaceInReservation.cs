using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobiPark.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ParkingSpaceInReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingSpaceNumber",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ParkingSpaceNumber",
                table: "Reservations",
                column: "ParkingSpaceNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ParkingSpaces_ParkingSpaceNumber",
                table: "Reservations",
                column: "ParkingSpaceNumber",
                principalTable: "ParkingSpaces",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ParkingSpaces_ParkingSpaceNumber",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ParkingSpaceNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ParkingSpaceNumber",
                table: "Reservations");
        }
    }
}
