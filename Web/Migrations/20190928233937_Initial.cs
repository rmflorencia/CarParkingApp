using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingLot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ParkingLotCode = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    InitialNumberOfFloors = table.Column<int>(nullable: false),
                    InitialNumberOfSpotsPerFloor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingFloor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ParkingLotId = table.Column<int>(nullable: false),
                    NumberOfSpots = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingFloor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingFloor_ParkingLot_ParkingLotId",
                        column: x => x.ParkingLotId,
                        principalTable: "ParkingLot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ParkingSpotCode = table.Column<string>(nullable: true),
                    ParkingFloorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpot_ParkingFloor_ParkingFloorId",
                        column: x => x.ParkingFloorId,
                        principalTable: "ParkingFloor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Owner = table.Column<string>(nullable: false),
                    ParkingSpotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.LicensePlate);
                    table.UniqueConstraint("AK_Vehicle_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_ParkingSpot_ParkingSpotId",
                        column: x => x.ParkingSpotId,
                        principalTable: "ParkingSpot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingFloor_ParkingLotId",
                table: "ParkingFloor",
                column: "ParkingLotId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpot_ParkingFloorId",
                table: "ParkingSpot",
                column: "ParkingFloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ParkingSpotId",
                table: "Vehicle",
                column: "ParkingSpotId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "ParkingSpot");

            migrationBuilder.DropTable(
                name: "ParkingFloor");

            migrationBuilder.DropTable(
                name: "ParkingLot");
        }
    }
}
