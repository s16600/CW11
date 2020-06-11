using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CW11a.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "Doctor", "DueDate", "Patient" },
                values: new object[] { 1, new DateTime(2020, 6, 11, 12, 47, 43, 281, DateTimeKind.Local).AddTicks(3360), null, new DateTime(2021, 6, 11, 12, 47, 43, 287, DateTimeKind.Local).AddTicks(3661), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1);
        }
    }
}
