using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class BigUpdateOfTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePermission_Employees_EmployeeId",
                table: "EmployeePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePermission_EmployeeRole_RoleId",
                table: "EmployeePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoomPermission_Service_ServiceId",
                table: "RoleRoomPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoomPermission_EmployeeRole_ServiceRoleId",
                table: "RoleRoomPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleServicePermission_Service_ServiceId",
                table: "RoleServicePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleServicePermission_EmployeeRole_ServiceRoleId",
                table: "RoleServicePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleRoomPermission",
                table: "RoleRoomPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePermission",
                table: "EmployeePermission");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "RoleRoomPermission",
                newName: "RoleRoomPermissions");

            migrationBuilder.RenameTable(
                name: "EmployeeRole",
                newName: "EmployeeRoles");

            migrationBuilder.RenameTable(
                name: "EmployeePermission",
                newName: "EmployeePermissions");

            migrationBuilder.RenameIndex(
                name: "IX_RoleRoomPermission_ServiceRoleId",
                table: "RoleRoomPermissions",
                newName: "IX_RoleRoomPermissions_ServiceRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleRoomPermission_ServiceId",
                table: "RoleRoomPermissions",
                newName: "IX_RoleRoomPermissions_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePermission_RoleId",
                table: "EmployeePermissions",
                newName: "IX_EmployeePermissions_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePermission_EmployeeId",
                table: "EmployeePermissions",
                newName: "IX_EmployeePermissions_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleRoomPermissions",
                table: "RoleRoomPermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRoles",
                table: "EmployeeRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePermissions",
                table: "EmployeePermissions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Newsleter = table.Column<bool>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    StartTime = table.Column<DateTimeOffset>(nullable: false),
                    FinishTime = table.Column<DateTimeOffset>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Present = table.Column<bool>(nullable: false),
                    AbsenceReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSchedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: true),
                    ServiceId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    ReservationTime = table.Column<DateTimeOffset>(nullable: false),
                    EstimatedTime = table.Column<DateTimeOffset>(nullable: false),
                    Done = table.Column<bool>(nullable: true),
                    AbsenceReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReservations_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceReservations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceReservations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: true),
                    EquipmentId = table.Column<Guid>(nullable: true)
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
                        name: "FK_RoomEquipment_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_EmployeeId",
                table: "EmployeeSchedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomEquipment_EquipmentId",
                table: "RoomEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomEquipment_RoomId",
                table: "RoomEquipment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_CustomerId",
                table: "ServiceReservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_EmployeeId",
                table: "ServiceReservations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_ServiceId",
                table: "ServiceReservations",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePermissions_Employees_EmployeeId",
                table: "EmployeePermissions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePermissions_EmployeeRoles_RoleId",
                table: "EmployeePermissions",
                column: "RoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoomPermissions_Services_ServiceId",
                table: "RoleRoomPermissions",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoomPermissions_EmployeeRoles_ServiceRoleId",
                table: "RoleRoomPermissions",
                column: "ServiceRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleServicePermission_Services_ServiceId",
                table: "RoleServicePermission",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleServicePermission_EmployeeRoles_ServiceRoleId",
                table: "RoleServicePermission",
                column: "ServiceRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePermissions_Employees_EmployeeId",
                table: "EmployeePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePermissions_EmployeeRoles_RoleId",
                table: "EmployeePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoomPermissions_Services_ServiceId",
                table: "RoleRoomPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoomPermissions_EmployeeRoles_ServiceRoleId",
                table: "RoleRoomPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleServicePermission_Services_ServiceId",
                table: "RoleServicePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleServicePermission_EmployeeRoles_ServiceRoleId",
                table: "RoleServicePermission");

            migrationBuilder.DropTable(
                name: "EmployeeSchedules");

            migrationBuilder.DropTable(
                name: "RoomEquipment");

            migrationBuilder.DropTable(
                name: "ServiceReservations");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleRoomPermissions",
                table: "RoleRoomPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRoles",
                table: "EmployeeRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePermissions",
                table: "EmployeePermissions");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "RoleRoomPermissions",
                newName: "RoleRoomPermission");

            migrationBuilder.RenameTable(
                name: "EmployeeRoles",
                newName: "EmployeeRole");

            migrationBuilder.RenameTable(
                name: "EmployeePermissions",
                newName: "EmployeePermission");

            migrationBuilder.RenameIndex(
                name: "IX_RoleRoomPermissions_ServiceRoleId",
                table: "RoleRoomPermission",
                newName: "IX_RoleRoomPermission_ServiceRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleRoomPermissions_ServiceId",
                table: "RoleRoomPermission",
                newName: "IX_RoleRoomPermission_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePermissions_RoleId",
                table: "EmployeePermission",
                newName: "IX_EmployeePermission_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePermissions_EmployeeId",
                table: "EmployeePermission",
                newName: "IX_EmployeePermission_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleRoomPermission",
                table: "RoleRoomPermission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePermission",
                table: "EmployeePermission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePermission_Employees_EmployeeId",
                table: "EmployeePermission",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePermission_EmployeeRole_RoleId",
                table: "EmployeePermission",
                column: "RoleId",
                principalTable: "EmployeeRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoomPermission_Service_ServiceId",
                table: "RoleRoomPermission",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoomPermission_EmployeeRole_ServiceRoleId",
                table: "RoleRoomPermission",
                column: "ServiceRoleId",
                principalTable: "EmployeeRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleServicePermission_Service_ServiceId",
                table: "RoleServicePermission",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleServicePermission_EmployeeRole_ServiceRoleId",
                table: "RoleServicePermission",
                column: "ServiceRoleId",
                principalTable: "EmployeeRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
