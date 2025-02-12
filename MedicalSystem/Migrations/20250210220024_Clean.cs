using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalSystem.Migrations
{
    /// <inheritdoc />
    public partial class Clean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MedicalHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedicalHistories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedicalHistories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MedicalHistories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MedicalHistories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "Gender", "LastName", "OIB", "PatientNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Male", "Doe", "12345678901", "P001" },
                    { 2, new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Female", "Smith", "98765432101", "P002" },
                    { 3, new DateTime(1978, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Male", "Johnson", "45678912345", "P003" },
                    { 4, new DateTime(1982, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Female", "Davis", "78912345678", "P004" },
                    { 5, new DateTime(1995, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Male", "Brown", "32165498765", "P005" }
                });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "ExaminationDateTime", "ExaminationType", "Notes", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "GP", "Routine checkup for general health.", 1 },
                    { 2, new DateTime(2023, 6, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), "KRV", "Blood test to check cholesterol levels.", 2 },
                    { 3, new DateTime(2023, 6, 3, 9, 45, 0, 0, DateTimeKind.Unspecified), "X-RAY", "X-Ray of chest for suspected infection.", 3 },
                    { 4, new DateTime(2023, 6, 4, 15, 20, 0, 0, DateTimeKind.Unspecified), "CT", "CT Scan to assess abdominal pain.", 4 },
                    { 5, new DateTime(2023, 6, 5, 8, 10, 0, 0, DateTimeKind.Unspecified), "MR", "MRI Scan of the brain for neurological concerns.", 5 }
                });

            migrationBuilder.InsertData(
                table: "MedicalHistories",
                columns: new[] { "Id", "DiseaseName", "EndDate", "PatientId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Hypertension", new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2015, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Diabetes", null, 2, new DateTime(2018, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Asthma", new DateTime(2016, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2010, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Migraine", null, 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "High Cholesterol", null, 5, new DateTime(2020, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "Dosage", "Instructions", "MedicineName", "PatientId", "PrescriptionDate" },
                values: new object[,]
                {
                    { 1, "10mg", "Take once daily in the morning", "Lisinopril", 1, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "500mg", "Take with meals twice daily", "Metformin", 2, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "90 mcg", "Use as needed for asthma attacks", "Albuterol Inhaler", 3, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "50mg", "Take at onset of migraine", "Sumatriptan", 4, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "20mg", "Take once daily at night", "Atorvastatin", 5, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
