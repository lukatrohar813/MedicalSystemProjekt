using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalSystem.Migrations
{
	/// <inheritdoc />
	public partial class AddPatientNumberToPatient : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "PrescriptionDate",
				table: "Prescriptions",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone");

			migrationBuilder.AlterColumn<DateTime>(
				name: "DateOfBirth",
				table: "Patients",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone");

			migrationBuilder.AddColumn<string>(
				name: "PatientNumber2",
				table: "Patients",
				type: "text",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AlterColumn<DateTime>(
				name: "StartDate",
				table: "MedicalHistories",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone");

			migrationBuilder.AlterColumn<DateTime>(
				name: "EndDate",
				table: "MedicalHistories",
				type: "timestamp without time zone",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "ExaminationDateTime",
				table: "Examinations",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone");

			migrationBuilder.AlterColumn<DateTime>(
				name: "UploadDateTime",
				table: "ExaminationImages",
				type: "timestamp without time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PatientNumber2",
				table: "Patients");

			migrationBuilder.AlterColumn<DateTime>(
				name: "PrescriptionDate",
				table: "Prescriptions",
				type: "timestamp with time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");

			migrationBuilder.AlterColumn<DateTime>(
				name: "DateOfBirth",
				table: "Patients",
				type: "timestamp with time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");

			migrationBuilder.AlterColumn<DateTime>(
				name: "StartDate",
				table: "MedicalHistories",
				type: "timestamp with time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");

			migrationBuilder.AlterColumn<DateTime>(
				name: "EndDate",
				table: "MedicalHistories",
				type: "timestamp with time zone",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "ExaminationDateTime",
				table: "Examinations",
				type: "timestamp with time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");

			migrationBuilder.AlterColumn<DateTime>(
				name: "UploadDateTime",
				table: "ExaminationImages",
				type: "timestamp with time zone",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "timestamp without time zone");
		}
	}
}
