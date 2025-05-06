using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentMonitoring.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutomationDevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateChangeRecords",
                columns: table => new
                {
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    OccurringTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NewState = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateChangeRecords", x => new { x.EquipmentId, x.OccurringTime });
                });

            migrationBuilder.CreateTable(
                name: "HMIs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HMIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HMIs_AutomationDevices_Id",
                        column: x => x.Id,
                        principalTable: "AutomationDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLCs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PLCs_AutomationDevices_Id",
                        column: x => x.Id,
                        principalTable: "AutomationDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutomationDeviceUnit",
                columns: table => new
                {
                    AutomationDevicesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationDeviceUnit", x => new { x.AutomationDevicesId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_AutomationDeviceUnit_AutomationDevices_AutomationDevicesId",
                        column: x => x.AutomationDevicesId,
                        principalTable: "AutomationDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    ActiveOperationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Operations_ActiveOperationId",
                        column: x => x.ActiveOperationId,
                        principalTable: "Operations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Variables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variables_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutomationDeviceUnit_UnitsId",
                table: "AutomationDeviceUnit",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_UnitId",
                table: "Operations",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ActiveOperationId",
                table: "Units",
                column: "ActiveOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Variables_UnitId",
                table: "Variables",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutomationDeviceUnit_Units_UnitsId",
                table: "AutomationDeviceUnit",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Units_UnitId",
                table: "Operations",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Units_UnitId",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "AutomationDeviceUnit");

            migrationBuilder.DropTable(
                name: "HMIs");

            migrationBuilder.DropTable(
                name: "PLCs");

            migrationBuilder.DropTable(
                name: "StateChangeRecords");

            migrationBuilder.DropTable(
                name: "Variables");

            migrationBuilder.DropTable(
                name: "AutomationDevices");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Operations");
        }
    }
}
