using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGreenhouse.WebAPI.Migrations
{
    public partial class AddSensorNodesAndReadingsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorNodes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorNodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConditionsReadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirTemperature = table.Column<int>(type: "int", nullable: false),
                    AirHumidity = table.Column<int>(type: "int", nullable: false),
                    SoilMoisture = table.Column<int>(type: "int", nullable: false),
                    LightIntensity = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SensorNodeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionsReadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionsReadings_SensorNodes_SensorNodeId",
                        column: x => x.SensorNodeId,
                        principalTable: "SensorNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConditionsReadings_SensorNodeId",
                table: "ConditionsReadings",
                column: "SensorNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConditionsReadings");

            migrationBuilder.DropTable(
                name: "SensorNodes");
        }
    }
}
