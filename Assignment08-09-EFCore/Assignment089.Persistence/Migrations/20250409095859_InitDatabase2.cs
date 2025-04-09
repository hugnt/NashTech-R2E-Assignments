using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment089.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_Id",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Employee_EmployeeId",
                table: "Salary");

            migrationBuilder.DropIndex(
                name: "IX_Salary_EmployeeId",
                table: "Salary");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Salary");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SalaryId",
                table: "Employee",
                column: "SalaryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Salary_SalaryId",
                table: "Employee",
                column: "SalaryId",
                principalTable: "Salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Salary_SalaryId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SalaryId",
                table: "Employee");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Salary",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Salary_EmployeeId",
                table: "Salary",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_Id",
                table: "Employee",
                column: "Id",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Employee_EmployeeId",
                table: "Salary",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
