using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class AddedEntitiesToDBContextU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "ServicePermissions",
                newName: "ServicePermission");

            migrationBuilder.RenameTable(
                name: "RoomPermissions",
                newName: "RoomPermission");

            migrationBuilder.RenameTable(
                name: "RolePermissions",
                newName: "RolePermission");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePermissions_ServiceId1",
                table: "ServicePermission",
                newName: "IX_ServicePermission_ServiceId1");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePermissions_RolePermissionId1",
                table: "ServicePermission",
                newName: "IX_ServicePermission_RolePermissionId1");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePermissions_EmployeeRoleId",
                table: "ServicePermission",
                newName: "IX_ServicePermission_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPermissions_RoomId1",
                table: "RoomPermission",
                newName: "IX_RoomPermission_RoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPermissions_RolePermissionId1",
                table: "RoomPermission",
                newName: "IX_RoomPermission_RolePermissionId1");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPermissions_EmployeeRoleId",
                table: "RoomPermission",
                newName: "IX_RoomPermission_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_EmployeeRoleId",
                table: "RolePermission",
                newName: "IX_RolePermission_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_EmployeeId1",
                table: "RolePermission",
                newName: "IX_RolePermission_EmployeeId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicePermission",
                table: "ServicePermission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPermission",
                table: "RoomPermission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPermission_EmployeeRoles_EmployeeRoleId",
                table: "RoomPermission",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPermission_RolePermission_RolePermissionId1",
                table: "RoomPermission",
                column: "RolePermissionId1",
                principalTable: "RolePermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPermission_Rooms_RoomId1",
                table: "RoomPermission",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePermission_EmployeeRoles_EmployeeRoleId",
                table: "ServicePermission",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePermission_RolePermission_RolePermissionId1",
                table: "ServicePermission",
                column: "RolePermissionId1",
                principalTable: "RolePermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePermission_Services_ServiceId1",
                table: "ServicePermission",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Employees_EmployeeId1",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_EmployeeRoles_EmployeeRoleId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPermission_EmployeeRoles_EmployeeRoleId",
                table: "RoomPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPermission_RolePermission_RolePermissionId1",
                table: "RoomPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPermission_Rooms_RoomId1",
                table: "RoomPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePermission_EmployeeRoles_EmployeeRoleId",
                table: "ServicePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePermission_RolePermission_RolePermissionId1",
                table: "ServicePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePermission_Services_ServiceId1",
                table: "ServicePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicePermission",
                table: "ServicePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomPermission",
                table: "RoomPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission");

            migrationBuilder.RenameTable(
                name: "ServicePermission",
                newName: "ServicePermissions");

            migrationBuilder.RenameTable(
                name: "RoomPermission",
                newName: "RoomPermissions");

            migrationBuilder.RenameTable(
                name: "RolePermission",
                newName: "RolePermissions");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePermission_ServiceId1",
                table: "ServicePermissions",
                newName: "IX_ServicePermissions_ServiceId1");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePermission_RolePermissionId1",
                table: "ServicePermissions",
                newName: "IX_ServicePermissions_RolePermissionId1");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePermission_EmployeeRoleId",
                table: "ServicePermissions",
                newName: "IX_ServicePermissions_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPermission_RoomId1",
                table: "RoomPermissions",
                newName: "IX_RoomPermissions_RoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPermission_RolePermissionId1",
                table: "RoomPermissions",
                newName: "IX_RoomPermissions_RolePermissionId1");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPermission_EmployeeRoleId",
                table: "RoomPermissions",
                newName: "IX_RoomPermissions_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermission_EmployeeRoleId",
                table: "RolePermissions",
                newName: "IX_RolePermissions_EmployeeRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermission_EmployeeId1",
                table: "RolePermissions",
                newName: "IX_RolePermissions_EmployeeId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicePermissions",
                table: "ServicePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPermissions",
                table: "RoomPermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions",
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
    }
}
