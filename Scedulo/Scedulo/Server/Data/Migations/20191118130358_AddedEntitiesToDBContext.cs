using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class AddedEntitiesToDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionToRoom_EmployeeRoles_EmployeeRoleId",
                table: "PermissionToRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionToRoom_RolePermission_RolePermissionId1",
                table: "PermissionToRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionToRoom_Rooms_RoomId1",
                table: "PermissionToRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionToService_EmployeeRoles_EmployeeRoleId",
                table: "PermissionToService");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionToService_RolePermission_RolePermissionId1",
                table: "PermissionToService");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionToService_Services_ServiceId1",
                table: "PermissionToService");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Employees_EmployeeId1",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_EmployeeRoles_EmployeeRoleId",
                table: "RolePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionToService",
                table: "PermissionToService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionToRoom",
                table: "PermissionToRoom");

            migrationBuilder.RenameTable(
                name: "RolePermission",
                newName: "RolePermissions");

            migrationBuilder.RenameTable(
                name: "PermissionToService",
                newName: "ServicePermissions");

            migrationBuilder.RenameTable(
                name: "PermissionToRoom",
                newName: "RoomPermissions");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermission_EmployeeRoleId",
                table: "RolePermissions",
                newName: "IX_RolePermissions_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermission_EmployeeId1",
                table: "RolePermissions",
                newName: "IX_RolePermissions_EmployeeId1");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionToService_ServiceId1",
                table: "ServicePermissions",
                newName: "IX_ServicePermissions_ServiceId1");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionToService_RolePermissionId1",
                table: "ServicePermissions",
                newName: "IX_ServicePermissions_RolePermissionId1");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionToService_EmployeeRoleId",
                table: "ServicePermissions",
                newName: "IX_ServicePermissions_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionToRoom_RoomId1",
                table: "RoomPermissions",
                newName: "IX_RoomPermissions_RoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionToRoom_RolePermissionId1",
                table: "RoomPermissions",
                newName: "IX_RoomPermissions_RolePermissionId1");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionToRoom_EmployeeRoleId",
                table: "RoomPermissions",
                newName: "IX_RoomPermissions_EmployeeRoleId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiringTime",
                table: "RolePermissions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicePermissions",
                table: "ServicePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPermissions",
                table: "RoomPermissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Employees_EmployeeId1",
                table: "RolePermissions",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_EmployeeRoles_EmployeeRoleId",
                table: "RolePermissions",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPermissions_EmployeeRoles_EmployeeRoleId",
                table: "RoomPermissions",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPermissions_RolePermissions_RolePermissionId1",
                table: "RoomPermissions",
                column: "RolePermissionId1",
                principalTable: "RolePermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPermissions_Rooms_RoomId1",
                table: "RoomPermissions",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePermissions_EmployeeRoles_EmployeeRoleId",
                table: "ServicePermissions",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePermissions_RolePermissions_RolePermissionId1",
                table: "ServicePermissions",
                column: "RolePermissionId1",
                principalTable: "RolePermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePermissions_Services_ServiceId1",
                table: "ServicePermissions",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Employees_EmployeeId1",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_EmployeeRoles_EmployeeRoleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPermissions_EmployeeRoles_EmployeeRoleId",
                table: "RoomPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPermissions_RolePermissions_RolePermissionId1",
                table: "RoomPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPermissions_Rooms_RoomId1",
                table: "RoomPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePermissions_EmployeeRoles_EmployeeRoleId",
                table: "ServicePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePermissions_RolePermissions_RolePermissionId1",
                table: "ServicePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePermissions_Services_ServiceId1",
                table: "ServicePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicePermissions",
                table: "ServicePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomPermissions",
                table: "RoomPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "ExpiringTime",
                table: "RolePermissions");

            migrationBuilder.RenameTable(
                name: "ServicePermissions",
                newName: "PermissionToService");

            migrationBuilder.RenameTable(
                name: "RoomPermissions",
                newName: "PermissionToRoom");

            migrationBuilder.RenameTable(
                name: "RolePermissions",
                newName: "RolePermission");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePermissions_ServiceId1",
                table: "PermissionToService",
                newName: "IX_PermissionToService_ServiceId1");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePermissions_RolePermissionId1",
                table: "PermissionToService",
                newName: "IX_PermissionToService_RolePermissionId1");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePermissions_EmployeeRoleId",
                table: "PermissionToService",
                newName: "IX_PermissionToService_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPermissions_RoomId1",
                table: "PermissionToRoom",
                newName: "IX_PermissionToRoom_RoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPermissions_RolePermissionId1",
                table: "PermissionToRoom",
                newName: "IX_PermissionToRoom_RolePermissionId1");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPermissions_EmployeeRoleId",
                table: "PermissionToRoom",
                newName: "IX_PermissionToRoom_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_EmployeeRoleId",
                table: "RolePermission",
                newName: "IX_RolePermission_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_EmployeeId1",
                table: "RolePermission",
                newName: "IX_RolePermission_EmployeeId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionToService",
                table: "PermissionToService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionToRoom",
                table: "PermissionToRoom",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionToRoom_EmployeeRoles_EmployeeRoleId",
                table: "PermissionToRoom",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionToRoom_RolePermission_RolePermissionId1",
                table: "PermissionToRoom",
                column: "RolePermissionId1",
                principalTable: "RolePermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionToRoom_Rooms_RoomId1",
                table: "PermissionToRoom",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionToService_EmployeeRoles_EmployeeRoleId",
                table: "PermissionToService",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionToService_RolePermission_RolePermissionId1",
                table: "PermissionToService",
                column: "RolePermissionId1",
                principalTable: "RolePermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionToService_Services_ServiceId1",
                table: "PermissionToService",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Employees_EmployeeId1",
                table: "RolePermission",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_EmployeeRoles_EmployeeRoleId",
                table: "RolePermission",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
