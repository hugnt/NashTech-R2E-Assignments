using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment089.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("1b2c3d4e-5f6a-4e8b-9c0d-7a8b9e0f1c2d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 18, 2, 13, 203, DateTimeKind.Local).AddTicks(9609), new DateTime(2025, 4, 9, 18, 2, 13, 203, DateTimeKind.Local).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("3f8b2a1e-5c4d-4e9f-a2b3-7c8d9e0f1a2b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 18, 2, 13, 203, DateTimeKind.Local).AddTicks(9578), new DateTime(2025, 4, 9, 18, 2, 13, 203, DateTimeKind.Local).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("6d7e8f9a-0b1c-4d2e-a3b4-5c6d7e8f9a0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 18, 2, 13, 203, DateTimeKind.Local).AddTicks(9613), new DateTime(2025, 4, 9, 18, 2, 13, 203, DateTimeKind.Local).AddTicks(9614) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("9a4c6e2d-8f3b-4d1a-b5c7-2e9f0a1b3c4d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 18, 2, 13, 203, DateTimeKind.Local).AddTicks(9604), new DateTime(2025, 4, 9, 18, 2, 13, 203, DateTimeKind.Local).AddTicks(9605) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("1b2c3d4e-5f6a-4e8b-9c0d-7a8b9e0f1c2d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("3f8b2a1e-5c4d-4e9f-a2b3-7c8d9e0f1a2b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("6d7e8f9a-0b1c-4d2e-a3b4-5c6d7e8f9a0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("9a4c6e2d-8f3b-4d1a-b5c7-2e9f0a1b3c4d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
