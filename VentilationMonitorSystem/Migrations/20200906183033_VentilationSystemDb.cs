using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VentilationMonitorSystem.Migrations
{
    public partial class VentilationSystemDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: false),
                    VentilationCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    UnitId = table.Column<Guid>(nullable: false),
                    UnitName = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "VentilationDetail",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(nullable: false),
                    LongWall = table.Column<int>(nullable: false),
                    Taligate = table.Column<int>(nullable: false),
                    MG13 = table.Column<int>(nullable: false),
                    MG14 = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentilationDetail", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_VentilationDetail_units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentilationDetail_UnitId",
                table: "VentilationDetail",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "VentilationDetail");

            migrationBuilder.DropTable(
                name: "units");
        }
    }
}
