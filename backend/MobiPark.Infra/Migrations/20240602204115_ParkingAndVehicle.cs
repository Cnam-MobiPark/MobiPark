using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobiPark.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ParkingAndVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingSpaces",
                columns: table => new
                {
                    Number = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpaces", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Plate = table.Column<string>(type: "TEXT", nullable: false),
                    PlateType = table.Column<int>(type: "INTEGER", nullable: false),
                    Maker = table.Column<string>(type: "TEXT", nullable: false),
                    BatteryCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentBatteryCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    EngineType = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Plate);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpaces");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
