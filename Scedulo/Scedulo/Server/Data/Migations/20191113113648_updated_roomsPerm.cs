using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class updated_roomsPerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoomPermissions_Rooms_RoomId",
                table: "RoleRoomPermissions");

            migrationBuilder.DropIndex(
                name: "IX_RoleRoomPermissions_RoomId",
                table: "RoleRoomPermissions");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "RoleRoomPermissions");

            migrationBuilder.AlterColumn<string>(
                name: "RoomId",
                table: "RoleRoomPermissions",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId1",
                table: "RoleRoomPermissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermissions_RoomId1",
                table: "RoleRoomPermissions",
                column: "RoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoomPermissions_Rooms_RoomId1",
                table: "RoleRoomPermissions",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoomPermissions_Rooms_RoomId1",
                table: "RoleRoomPermissions");

            migrationBuilder.DropIndex(
                name: "IX_RoleRoomPermissions_RoomId1",
                table: "RoleRoomPermissions");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "RoleRoomPermissions");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "RoleRoomPermissions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceId",
                table: "RoleRoomPermissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermissions_RoomId",
                table: "RoleRoomPermissions",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoomPermissions_Rooms_RoomId",
                table: "RoleRoomPermissions",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
