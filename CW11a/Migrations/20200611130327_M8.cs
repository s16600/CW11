using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CW11a.Migrations
{
    public partial class M8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[] { 2, "jwinnicki@wp.pl", "Jan", "Winnicki" });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2020, 6, 11, 15, 3, 26, 999, DateTimeKind.Local).AddTicks(3075), new DateTime(2021, 6, 11, 15, 3, 27, 2, DateTimeKind.Local).AddTicks(3927) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2020, 6, 11, 13, 7, 31, 191, DateTimeKind.Local).AddTicks(3241), new DateTime(2021, 6, 11, 13, 7, 31, 194, DateTimeKind.Local).AddTicks(3559) });
        }
    }
}
