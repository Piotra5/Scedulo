using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class ChangeDefaultUserIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DoB",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmployed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsEmployed",
                table: "AspNetUsers");
        }
    }
}
