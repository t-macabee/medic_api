using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medic.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Orders = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "ImageUrl", "LastLogin", "Name", "Orders", "PasswordHash", "PasswordSalt", "RoleId", "Status", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://randomuser.me/api/portraits/men/23.jpg", new DateTime(2024, 8, 2, 22, 10, 36, 352, DateTimeKind.Local).AddTicks(8009), "John Doe", 0, "i6ibP2QudV21EDgT1NWRNqJQQvcmfq567byCuWwNoeY=", "E7I8KXJaKRgTH8hyZLycYA==", 1, "Active", "admin" },
                    { 2, new DateTime(1997, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://randomuser.me/api/portraits/women/39.jpg", new DateTime(2024, 8, 2, 22, 10, 36, 352, DateTimeKind.Local).AddTicks(8058), "Jane Doe", 1, "iyGot99T18/WvbfWViW0FVNfXi/4cZSRYRmnVSOzP5s=", "oztJt9MmGfUs6vo9n1DX8g==", 2, "Active", "janedoe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
