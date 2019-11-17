using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class delted_permissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePermissions");

            migrationBuilder.DropTable(
                name: "RoleRoomPermissions");

            migrationBuilder.DropTable(
                name: "RoleServicePermission");

            migrationBuilder.DropTable(
                name: "RoomEquipment");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeRoleId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeRoleId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Equipments",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "EmployeeRoles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_EmployeeRoleId",
                table: "Services",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_EmployeeRoleId",
                table: "Rooms",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_RoomId",
                table: "Equipments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_Employees_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Rooms_RoomId",
                table: "Equipments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_EmployeeRoles_EmployeeRoleId",
                table: "Rooms",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_EmployeeRoles_EmployeeRoleId",
                table: "Services",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRoles_Employees_EmployeeId",
                table: "EmployeeRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Rooms_RoomId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_EmployeeRoles_EmployeeRoleId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_EmployeeRoles_EmployeeRoleId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_EmployeeRoleId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_EmployeeRoleId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_RoomId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles");

            migrationBuilder.DropColumn(
                name: "EmployeeRoleId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "EmployeeRoleId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeRoles");

            migrationBuilder.CreateTable(
                name: "EmployeePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePermissions_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePermissions_EmployeeRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "EmployeeRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleRoomPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceRoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceRoleId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRoomPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleRoomPermissions_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleRoomPermissions_EmployeeRoles_ServiceRoleId1",
                        column: x => x.ServiceRoleId1,
                        principalTable: "EmployeeRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleServicePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceRoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceRoleId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleServicePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleServicePermission_Services_ServiceId1",
                        column: x => x.ServiceId1,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleServicePermission_EmployeeRoles_ServiceRoleId1",
                        column: x => x.ServiceRoleId1,
                        principalTable: "EmployeeRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquimpentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoomId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomEquipment_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomEquipment_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_EmployeeId1",
                table: "EmployeePermissions",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_RoleId1",
                table: "EmployeePermissions",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermissions_RoomId1",
                table: "RoleRoomPermissions",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermissions_ServiceRoleId1",
                table: "RoleRoomPermissions",
                column: "ServiceRoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermission_ServiceId1",
                table: "RoleServicePermission",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermission_ServiceRoleId1",
                table: "RoleServicePermission",
                column: "ServiceRoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomEquipment_EquipmentId",
                table: "RoomEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomEquipment_RoomId1",
                table: "RoomEquipment",
                column: "RoomId1");
        }
    }
}
