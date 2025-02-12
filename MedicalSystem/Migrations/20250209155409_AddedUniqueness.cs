using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalSystem.Migrations
{
	/// <inheritdoc />
	public partial class AddedUniqueness : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateIndex(
				name: "IX_Patients_OIB",
				table: "Patients",
				column: "OIB",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Patients_PatientNumber",
				table: "Patients",
				column: "PatientNumber",
				unique: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				name: "IX_Patients_OIB",
				table: "Patients");

			migrationBuilder.DropIndex(
				name: "IX_Patients_PatientNumber",
				table: "Patients");
		}
	}
}
