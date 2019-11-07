using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class AddedIdsToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePermissions_Employees_EmployeeId",
                table: "EmployeePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePermissions_EmployeeRoles_RoleId",
                table: "EmployeePermissions");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePermissions_EmployeeId",
                table: "EmployeePermissions");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePermissions_RoleId",
                table: "EmployeePermissions");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "EmployeePermissions",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeePermissions",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId1",
                table: "EmployeePermissions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "EmployeePermissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_EmployeeId1",
                table: "EmployeePermissions",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_RoleId1",
                table: "EmployeePermissions",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePermissions_Employees_EmployeeId1",
                table: "EmployeePermissions",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePermissions_EmployeeRoles_RoleId1",
                table: "EmployeePermissions",
                column: "RoleId1",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePermissions_Employees_EmployeeId1",
                table: "EmployeePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePermissions_EmployeeRoles_RoleId1",
                table: "EmployeePermissions");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePermissions_EmployeeId1",
                table: "EmployeePermissions");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePermissions_RoleId1",
                table: "EmployeePermissions");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "EmployeePermissions");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "EmployeePermissions");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "EmployeePermissions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "EmployeePermissions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_EmployeeId",
                table: "EmployeePermissions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_RoleId",
                table: "EmployeePermissions",
                column: "RoleId");

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
        }
    }
}
