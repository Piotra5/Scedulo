using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scedulo.Server.Data.Migations
{
    public partial class AddedEmployeesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeightInCM",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    EmploymentDate = table.Column<DateTimeOffset>(nullable: false),
                    ContractEndDate = table.Column<DateTimeOffset>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: true),
                    AdedById = table.Column<string>(nullable: true),
                    EditedById = table.Column<string>(nullable: true),
                    BaseMonthSalary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_AdedById",
                        column: x => x.AdedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_EditedById",
                        column: x => x.EditedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimeRequiredInMinutes = table.Column<int>(nullable: false),
                    RoleReqired = table.Column<bool>(nullable: false),
                    PriceInPln = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: true),
                    ExpiringDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePermission_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePermission_EmployeeRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EmployeeRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleRoomPermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ServiceRoleId = table.Column<Guid>(nullable: true),
                    ServiceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRoomPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleRoomPermission_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleRoomPermission_EmployeeRole_ServiceRoleId",
                        column: x => x.ServiceRoleId,
                        principalTable: "EmployeeRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleServicePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ServiceRoleId = table.Column<Guid>(nullable: true),
                    ServiceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleServicePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleServicePermission_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleServicePermission_EmployeeRole_ServiceRoleId",
                        column: x => x.ServiceRoleId,
                        principalTable: "EmployeeRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermission_EmployeeId",
                table: "EmployeePermission",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermission_RoleId",
                table: "EmployeePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdedById",
                table: "Employees",
                column: "AdedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EditedById",
                table: "Employees",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermission_ServiceId",
                table: "RoleRoomPermission",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoomPermission_ServiceRoleId",
                table: "RoleRoomPermission",
                column: "ServiceRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermission_ServiceId",
                table: "RoleServicePermission",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleServicePermission_ServiceRoleId",
                table: "RoleServicePermission",
                column: "ServiceRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePermission");

            migrationBuilder.DropTable(
                name: "RoleRoomPermission");

            migrationBuilder.DropTable(
                name: "RoleServicePermission");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropColumn(
                name: "HeightInCM",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
