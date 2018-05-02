using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DatabaseService.Migrations
{
    public partial class Update_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpeedVector",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    X = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false),
                    Z = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeedVector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorldLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    X = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false),
                    Z = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rabbits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: true),
                    SpeedId = table.Column<Guid>(nullable: true),
                    currentVelocity = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rabbits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rabbits_WorldLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "WorldLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rabbits_SpeedVector_SpeedId",
                        column: x => x.SpeedId,
                        principalTable: "SpeedVector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trees_WorldLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "WorldLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rabbits_LocationId",
                table: "Rabbits",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rabbits_SpeedId",
                table: "Rabbits",
                column: "SpeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_LocationId",
                table: "Trees",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rabbits");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "SpeedVector");

            migrationBuilder.DropTable(
                name: "WorldLocation");
        }
    }
}
