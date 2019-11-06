using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class UpdateEmployeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_AdedById",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AdedById",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdedById",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "AddedById",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddedById",
                table: "Employees",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_AddedById",
                table: "Employees",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_AddedById",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AddedById",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "AdedById",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdedById",
                table: "Employees",
                column: "AdedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_AdedById",
                table: "Employees",
                column: "AdedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
