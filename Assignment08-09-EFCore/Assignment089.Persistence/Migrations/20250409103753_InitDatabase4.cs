using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment089.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "Employee");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1b2c3d4e-5f6a-4e8b-9c0d-7a8b9e0f1c2d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f8b2a1e-5c4d-4e9f-a2b3-7c8d9e0f1a2b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d7e8f9a-0b1c-4d2e-a3b4-5c6d7e8f9a0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a4c6e2d-8f3b-4d1a-b5c7-2e9f0a1b3c4d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("1b2c3d4e-5f6a-4e8b-9c0d-7a8b9e0f1c2d"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("3f8b2a1e-5c4d-4e9f-a2b3-7c8d9e0f1a2b"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("6d7e8f9a-0b1c-4d2e-a3b4-5c6d7e8f9a0b"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("9a4c6e2d-8f3b-4d1a-b5c7-2e9f0a1b3c4d"));

            migrationBuilder.AddColumn<Guid>(
                name: "SalaryId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
