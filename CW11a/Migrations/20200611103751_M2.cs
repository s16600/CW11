using Microsoft.EntityFrameworkCore.Migrations;

namespace CW11a.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patient_Patient",
                table: "Prescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "IdPateient",
                table: "Patient");

            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "Patient",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "IdPatient");

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "jkowalski@wp.pl", "Jan", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "pnowak@wp.pl", "Piotr", "Nowak" });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patient_Patient",
                table: "Prescription",
                column: "Patient",
                principalTable: "Patient",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patient_Patient",
                table: "Prescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "Patient");

            migrationBuilder.AddColumn<int>(
                name: "IdPateient",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "IdPateient");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patient_Patient",
                table: "Prescription",
                column: "Patient",
                principalTable: "Patient",
                principalColumn: "IdPateient",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
