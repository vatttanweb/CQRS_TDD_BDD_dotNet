using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSwithBDD.Migrations
{
    public partial class addSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Active", "BankAccountNumber", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("20000000-0000-0000-0000-000000000000"), true, "111111111", new DateTime(2022, 4, 9, 14, 20, 42, 461, DateTimeKind.Local).AddTicks(502), "Dizaji.akbar@yahoo.com", "fname", "lname", "+98(938)433-1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000000"));
        }
    }
}
