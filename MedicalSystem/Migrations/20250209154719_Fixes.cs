using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalSystem.Migrations
{
	/// <inheritdoc />
	public partial class Fixes : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PatientNumber2",
				table: "Patients");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "PatientNumber2",
				table: "Patients",
				type: "text",
				nullable: false,
				defaultValue: "");
		}
	}
}
