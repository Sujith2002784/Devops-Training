using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeDetails.Migrations
{
    /// <inheritdoc />
    public partial class Employeeinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "DeptName" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "IT" },
                    { 3, "Finance" },
                    { 4, "Marketing" },
                    { 5, "Sales" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CreateDate", "DepartmentId", "EmpAddress", "EmpName", "IsActive", "JoiningDate", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 12, 14, 34, 689, DateTimeKind.Local).AddTicks(8424), 1, "123 Main St", "John Doe", true, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234567890", 50000.00m },
                    { 2, new DateTime(2024, 11, 14, 12, 14, 34, 692, DateTimeKind.Local).AddTicks(625), 2, "456 Elm St", "Jane Smith", true, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", 60000.00m },
                    { 3, new DateTime(2024, 11, 14, 12, 14, 34, 692, DateTimeKind.Local).AddTicks(646), 3, "789 Oak St", "Alice Johnson", false, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "1122334455", 55000.00m },
                    { 4, new DateTime(2024, 11, 14, 12, 14, 34, 692, DateTimeKind.Local).AddTicks(650), 4, "321 Maple St", "Bob Brown", true, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2233445566", 45000.00m },
                    { 5, new DateTime(2024, 11, 14, 12, 14, 34, 692, DateTimeKind.Local).AddTicks(652), 5, "654 Pine St", "Carol White", true, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "3344556677", 70000.00m },
                    { 6, new DateTime(2024, 11, 14, 12, 14, 34, 692, DateTimeKind.Local).AddTicks(655), 1, "987 Cedar St", "David Black", true, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "4455667788", 52000.00m },
                    { 7, new DateTime(2024, 11, 14, 12, 14, 34, 692, DateTimeKind.Local).AddTicks(658), 2, "159 Birch St", "Eve Green", false, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "5566778899", 48000.00m },
                    { 8, new DateTime(2024, 11, 14, 12, 14, 34, 692, DateTimeKind.Local).AddTicks(660), 3, "753 Oak St", "Frank Blue", true, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "6677889900", 62000.00m },
                    { 9, new DateTime(2024, 11, 14, 12, 14, 34, 692, DateTimeKind.Local).AddTicks(663), 4, "951 Elm St", "Grace Red", true, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "7788990011", 53000.00m },
                    { 10, new DateTime(2024, 11, 14, 12, 14, 34, 692, DateTimeKind.Local).AddTicks(665), 5, "357 Maple St", "Hank Yellow", false, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "8899001122", 59000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
