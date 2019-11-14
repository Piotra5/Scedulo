using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class changedReservation_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedTime",
                table: "ServiceReservations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationTime",
                table: "ServiceReservations",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "ServiceReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ServiceTimeInMinutes",
                table: "ServiceReservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "ServiceReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "ServiceTimeInMinutes",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ServiceReservations");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ReservationTime",
                table: "ServiceReservations",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EstimatedTime",
                table: "ServiceReservations",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
