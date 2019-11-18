using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class UpdatedEntitiesWithJoiningEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "EmployeeRoleId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "EmployeeRoleId",
                table: "Rooms");

            migrationBuilder.AddColumn<string>(
                name: "RoomId",
                table: "ServiceReservations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId1",
                table: "ServiceReservations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "EmployeeRoles",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmployeeId1 = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    EmployeeRoleId = table.Column<Guid>(nullable: true),
                    EmplyoeeRoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_EmployeeRoles_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionToRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RolePermissionId1 = table.Column<Guid>(nullable: true),
                    RolePermissionId = table.Column<string>(nullable: true),
                    RoomId1 = table.Column<Guid>(nullable: true),
                    RoomId = table.Column<string>(nullable: true),
                    EmployeeRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionToRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionToRoom_EmployeeRoles_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionToRoom_RolePermission_RolePermissionId1",
                        column: x => x.RolePermissionId1,
                        principalTable: "RolePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionToRoom_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionToService",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RolePermissionId1 = table.Column<Guid>(nullable: true),
                    RolePermissionId = table.Column<string>(nullable: true),
                    ServiceId1 = table.Column<Guid>(nullable: true),
                    ServiceId = table.Column<string>(nullable: true),
                    EmployeeRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionToService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionToService_EmployeeRoles_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionToService_RolePermission_RolePermissionId1",
                        column: x => x.RolePermissionId1,
                        principalTable: "RolePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionToService_Services_ServiceId1",
                        column: x => x.ServiceId1,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_RoomId1",
                table: "ServiceReservations",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_RoomId",
                table: "EmployeeRoles",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionToRoom_EmployeeRoleId",
                table: "PermissionToRoom",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionToRoom_RolePermissionId1",
                table: "PermissionToRoom",
                column: "RolePermissionId1");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionToRoom_RoomId1",
                table: "PermissionToRoom",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionToService_EmployeeRoleId",
                table: "PermissionToService",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionToService_RolePermissionId1",
                table: "PermissionToService",
                column: "RolePermissionId1");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionToService_ServiceId1",
                table: "PermissionToService",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_EmployeeId1",
                table: "RolePermission",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_EmployeeRoleId",
                table: "RolePermission",
                column: "EmployeeRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_Rooms_RoomId",
                table: "EmployeeRoles",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReservations_Rooms_RoomId1",
                table: "ServiceReservations",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRoles_Rooms_RoomId",
                table: "EmployeeRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReservations_Rooms_RoomId1",
                table: "ServiceReservations");

            migrationBuilder.DropTable(
                name: "PermissionToRoom");

            migrationBuilder.DropTable(
                name: "PermissionToService");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReservations_RoomId1",
                table: "ServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRoles_RoomId",
                table: "EmployeeRoles");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "EmployeeRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeRoleId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeRoleId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_EmployeeRoleId",
                table: "Services",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_EmployeeRoleId",
                table: "Rooms",
                column: "EmployeeRoleId");

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
    }
}
