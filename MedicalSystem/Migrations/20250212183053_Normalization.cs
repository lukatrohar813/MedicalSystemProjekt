using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalSystem.Migrations
{
    /// <inheritdoc />
    public partial class Normalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicineName",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DiseaseName",
                table: "MedicalHistories");

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "Prescriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IllnessId",
                table: "MedicalHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicineId",
                table: "Prescriptions",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_IllnessId",
                table: "MedicalHistories",
                column: "IllnessId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Illnesses_IllnessId",
                table: "MedicalHistories",
                column: "IllnessId",
                principalTable: "Illnesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Medicines_MedicineId",
                table: "Prescriptions",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Illnesses_IllnessId",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Medicines_MedicineId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicineId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_IllnessId",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "IllnessId",
                table: "MedicalHistories");

            migrationBuilder.AddColumn<string>(
                name: "MedicineName",
                table: "Prescriptions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiseaseName",
                table: "MedicalHistories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
