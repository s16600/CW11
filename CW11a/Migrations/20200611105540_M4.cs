using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CW11a.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[] { 1, "Pomocniczo w leczeniu grypy", "Aspiryna", "Niesteroidowy lek przeciwzapalny" });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2020, 6, 11, 12, 55, 40, 106, DateTimeKind.Local).AddTicks(4472), new DateTime(2021, 6, 11, 12, 55, 40, 109, DateTimeKind.Local).AddTicks(5327) });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose", "MedicamentIdMedicament" },
                values: new object[] { 1, 1, "Bez refundacji", 50, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2020, 6, 11, 12, 47, 43, 281, DateTimeKind.Local).AddTicks(3360), new DateTime(2021, 6, 11, 12, 47, 43, 287, DateTimeKind.Local).AddTicks(3661) });
        }
    }
}
