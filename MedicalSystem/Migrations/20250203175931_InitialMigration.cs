using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalSystem.Migrations
{
	/// <inheritdoc />
	public partial class InitialMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Patients",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					FirstName = table.Column<string>(type: "text", nullable: false),
					LastName = table.Column<string>(type: "text", nullable: false),
					OIB = table.Column<string>(type: "text", nullable: false),
					DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					Gender = table.Column<string>(type: "text", nullable: false),
					PatientNumber = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Patients", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Examinations",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					PatientId = table.Column<int>(type: "integer", nullable: false),
					ExaminationDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					ExaminationType = table.Column<string>(type: "text", nullable: false),
					Notes = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Examinations", x => x.Id);
					table.ForeignKey(
						name: "FK_Examinations_Patients_PatientId",
						column: x => x.PatientId,
						principalTable: "Patients",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "MedicalHistories",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					PatientId = table.Column<int>(type: "integer", nullable: false),
					DiseaseName = table.Column<string>(type: "text", nullable: false),
					StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MedicalHistories", x => x.Id);
					table.ForeignKey(
						name: "FK_MedicalHistories_Patients_PatientId",
						column: x => x.PatientId,
						principalTable: "Patients",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Prescriptions",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					PatientId = table.Column<int>(type: "integer", nullable: false),
					MedicineName = table.Column<string>(type: "text", nullable: false),
					Dosage = table.Column<string>(type: "text", nullable: false),
					PrescriptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					Instructions = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Prescriptions", x => x.Id);
					table.ForeignKey(
						name: "FK_Prescriptions_Patients_PatientId",
						column: x => x.PatientId,
						principalTable: "Patients",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ExaminationImages",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					ExaminationId = table.Column<int>(type: "integer", nullable: false),
					ImagePath = table.Column<string>(type: "text", nullable: false),
					UploadDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ExaminationImages", x => x.Id);
					table.ForeignKey(
						name: "FK_ExaminationImages_Examinations_ExaminationId",
						column: x => x.ExaminationId,
						principalTable: "Examinations",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_ExaminationImages_ExaminationId",
				table: "ExaminationImages",
				column: "ExaminationId");

			migrationBuilder.CreateIndex(
				name: "IX_Examinations_PatientId",
				table: "Examinations",
				column: "PatientId");

			migrationBuilder.CreateIndex(
				name: "IX_MedicalHistories_PatientId",
				table: "MedicalHistories",
				column: "PatientId");

			migrationBuilder.CreateIndex(
				name: "IX_Prescriptions_PatientId",
				table: "Prescriptions",
				column: "PatientId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ExaminationImages");

			migrationBuilder.DropTable(
				name: "MedicalHistories");

			migrationBuilder.DropTable(
				name: "Prescriptions");

			migrationBuilder.DropTable(
				name: "Examinations");

			migrationBuilder.DropTable(
				name: "Patients");
		}
	}
}
