using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CW11a.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doctor_Doctor",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patient_Patient",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Doctor",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Patient",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "Patient",
                table: "Prescription");

            migrationBuilder.AddColumn<int>(
                name: "DoctorIdDoctor",
                table: "Prescription",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDoctor",
                table: "Prescription",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "Prescription",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientIdPatient",
                table: "Prescription",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { new DateTime(2020, 6, 11, 13, 7, 31, 191, DateTimeKind.Local).AddTicks(3241), new DateTime(2021, 6, 11, 13, 7, 31, 194, DateTimeKind.Local).AddTicks(3559), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DoctorIdDoctor",
                table: "Prescription",
                column: "DoctorIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientIdPatient",
                table: "Prescription",
                column: "PatientIdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctor_DoctorIdDoctor",
                table: "Prescription",
                column: "DoctorIdDoctor",
                principalTable: "Doctor",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patient_PatientIdPatient",
                table: "Prescription",
                column: "PatientIdPatient",
                principalTable: "Patient",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doctor_DoctorIdDoctor",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patient_PatientIdPatient",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_DoctorIdDoctor",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_PatientIdPatient",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "DoctorIdDoctor",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "IdDoctor",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "PatientIdPatient",
                table: "Prescription");

            migrationBuilder.AddColumn<int>(
                name: "Doctor",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Patient",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2020, 6, 11, 12, 55, 40, 106, DateTimeKind.Local).AddTicks(4472), new DateTime(2021, 6, 11, 12, 55, 40, 109, DateTimeKind.Local).AddTicks(5327) });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Doctor",
                table: "Prescription",
                column: "Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Patient",
                table: "Prescription",
                column: "Patient");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctor_Doctor",
                table: "Prescription",
                column: "Doctor",
                principalTable: "Doctor",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patient_Patient",
                table: "Prescription",
                column: "Patient",
                principalTable: "Patient",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
