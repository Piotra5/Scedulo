using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class Updated_customers_addresses_and_some_ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSchedules_Employees_EmployeeId",
                table: "EmployeeSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomEquipment_Rooms_RoomId",
                table: "RoomEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReservations_Customer_CustomerId",
                table: "ServiceReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReservations_Employees_EmployeeId",
                table: "ServiceReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReservations_Services_ServiceId",
                table: "ServiceReservations");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReservations_CustomerId",
                table: "ServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReservations_EmployeeId",
                table: "ServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReservations_ServiceId",
                table: "ServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_RoomEquipment_RoomId",
                table: "RoomEquipment");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSchedules_EmployeeId",
                table: "EmployeeSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "ServiceReservations",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "ServiceReservations",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "ServiceReservations",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "ServiceReservations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId1",
                table: "ServiceReservations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId1",
                table: "ServiceReservations",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoomId",
                table: "RoomEquipment",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquimpentId",
                table: "RoomEquipment",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId1",
                table: "RoomEquipment",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeSchedules",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId1",
                table: "EmployeeSchedules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Line1 = table.Column<string>(nullable: true),
                    Line2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Newsleter = table.Column<bool>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_CustomerId1",
                table: "ServiceReservations",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_EmployeeId1",
                table: "ServiceReservations",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_ServiceId1",
                table: "ServiceReservations",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomEquipment_RoomId1",
                table: "RoomEquipment",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_EmployeeId1",
                table: "EmployeeSchedules",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSchedules_Employees_EmployeeId1",
                table: "EmployeeSchedules",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomEquipment_Rooms_RoomId1",
                table: "RoomEquipment",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReservations_Customers_CustomerId1",
                table: "ServiceReservations",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReservations_Employees_EmployeeId1",
                table: "ServiceReservations",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReservations_Services_ServiceId1",
                table: "ServiceReservations",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSchedules_Employees_EmployeeId1",
                table: "EmployeeSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomEquipment_Rooms_RoomId1",
                table: "RoomEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReservations_Customers_CustomerId1",
                table: "ServiceReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReservations_Employees_EmployeeId1",
                table: "ServiceReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReservations_Services_ServiceId1",
                table: "ServiceReservations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReservations_CustomerId1",
                table: "ServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReservations_EmployeeId1",
                table: "ServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReservations_ServiceId1",
                table: "ServiceReservations");

            migrationBuilder.DropIndex(
                name: "IX_RoomEquipment_RoomId1",
                table: "RoomEquipment");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSchedules_EmployeeId1",
                table: "EmployeeSchedules");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "ServiceId1",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "EquimpentId",
                table: "RoomEquipment");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "RoomEquipment");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "EmployeeSchedules");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "ServiceReservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "ServiceReservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "ServiceReservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomId",
                table: "RoomEquipment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "EmployeeSchedules",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Newsleter = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_RoomEquipment_RoomId",
                table: "RoomEquipment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_EmployeeId",
                table: "EmployeeSchedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSchedules_Employees_EmployeeId",
                table: "EmployeeSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomEquipment_Rooms_RoomId",
                table: "RoomEquipment",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReservations_Customer_CustomerId",
                table: "ServiceReservations",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReservations_Employees_EmployeeId",
                table: "ServiceReservations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReservations_Services_ServiceId",
                table: "ServiceReservations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
