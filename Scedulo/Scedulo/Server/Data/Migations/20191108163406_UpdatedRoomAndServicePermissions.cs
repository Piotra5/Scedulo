using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class UpdatedRoomAndServicePermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropIndex(
                name: "IX_RoleServicePermission_ServiceId",
                table: "RoleServicePermission");

            migrationBuilder.DropIndex(
                name: "IX_RoleServicePermission_ServiceRoleId",
                table: "RoleServicePermission");

            migrationBuilder.DropIndex(
                name: "IX_RoleRoomPermissions_ServiceId",
                table: "RoleRoomPermissions");

            migrationBuilder.DropIndex(
                name: "IX_RoleRoomPermissions_ServiceRoleId",
                table: "RoleRoomPermissions");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceRoleId",
                table: "RoleServicePermission",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "RoleServicePermission",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId1",
                table: "RoleServicePermission",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceRoleId1",
                table: "RoleServicePermission",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceRoleId",
                table: "RoleRoomPermissions",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "RoleRoomPermissions",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "RoleRoomPermissions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceRoleId1",
                table: "RoleRoomPermissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermission_ServiceId1",
                table: "RoleServicePermission",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermission_ServiceRoleId1",
                table: "RoleServicePermission",
                column: "ServiceRoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermissions_RoomId",
                table: "RoleRoomPermissions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermissions_ServiceRoleId1",
                table: "RoleRoomPermissions",
                column: "ServiceRoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoomPermissions_Rooms_RoomId",
                table: "RoleRoomPermissions",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoomPermissions_EmployeeRoles_ServiceRoleId1",
                table: "RoleRoomPermissions",
                column: "ServiceRoleId1",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleServicePermission_Services_ServiceId1",
                table: "RoleServicePermission",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleServicePermission_EmployeeRoles_ServiceRoleId1",
                table: "RoleServicePermission",
                column: "ServiceRoleId1",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoomPermissions_Rooms_RoomId",
                table: "RoleRoomPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoomPermissions_EmployeeRoles_ServiceRoleId1",
                table: "RoleRoomPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleServicePermission_Services_ServiceId1",
                table: "RoleServicePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleServicePermission_EmployeeRoles_ServiceRoleId1",
                table: "RoleServicePermission");

            migrationBuilder.DropIndex(
                name: "IX_RoleServicePermission_ServiceId1",
                table: "RoleServicePermission");

            migrationBuilder.DropIndex(
                name: "IX_RoleServicePermission_ServiceRoleId1",
                table: "RoleServicePermission");

            migrationBuilder.DropIndex(
                name: "IX_RoleRoomPermissions_RoomId",
                table: "RoleRoomPermissions");

            migrationBuilder.DropIndex(
                name: "IX_RoleRoomPermissions_ServiceRoleId1",
                table: "RoleRoomPermissions");

            migrationBuilder.DropColumn(
                name: "ServiceId1",
                table: "RoleServicePermission");

            migrationBuilder.DropColumn(
                name: "ServiceRoleId1",
                table: "RoleServicePermission");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoleRoomPermissions");

            migrationBuilder.DropColumn(
                name: "ServiceRoleId1",
                table: "RoleRoomPermissions");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceRoleId",
                table: "RoleServicePermission",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "RoleServicePermission",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceRoleId",
                table: "RoleRoomPermissions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "RoleRoomPermissions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermission_ServiceId",
                table: "RoleServicePermission",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermission_ServiceRoleId",
                table: "RoleServicePermission",
                column: "ServiceRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermissions_ServiceId",
                table: "RoleRoomPermissions",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermissions_ServiceRoleId",
                table: "RoleRoomPermissions",
                column: "ServiceRoleId");

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
    }
}
