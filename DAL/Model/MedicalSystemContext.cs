using Microsoft.EntityFrameworkCore;

namespace DAL.Model;

public class MedicalSystemContext : DbContext
{
	public MedicalSystemContext(DbContextOptions<MedicalSystemContext> options) : base(options)
	{
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
	}

	public DbSet<Patient> Patients { get; set; }
	public DbSet<MedicalHistory> MedicalHistories { get; set; }
	public DbSet<Examination> Examinations { get; set; }
	public DbSet<ExaminationImage> ExaminationImages { get; set; }
	public DbSet<Prescription> Prescriptions { get; set; }
	public DbSet<Illness> Illnesses { get; set; }
	public DbSet<Medicine> Medicines { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Patient>()
			.HasKey(p => p.Id);

		modelBuilder.Entity<MedicalHistory>()
			.HasKey(mh => mh.Id);
		modelBuilder.Entity<MedicalHistory>()
			.HasOne(mh => mh.Patient)
			.WithMany(p => p.MedicalHistory)
			.HasForeignKey(mh => mh.PatientId);
		modelBuilder.Entity<MedicalHistory>()
			.HasOne(mh => mh.Illness)
			.WithMany(i => i.MedicalHistories)
			.HasForeignKey(mh => mh.IllnessId);

		modelBuilder.Entity<Examination>()
			.HasKey(e => e.Id);
		modelBuilder.Entity<Examination>()
			.HasOne(e => e.Patient)
			.WithMany(p => p.Examinations)
			.HasForeignKey(e => e.PatientId);

		modelBuilder.Entity<ExaminationImage>()
			.HasKey(ei => ei.Id);
		modelBuilder.Entity<ExaminationImage>()
			.HasOne(ei => ei.Examination)
			.WithMany(e => e.ExaminationImages)
			.HasForeignKey(ei => ei.ExaminationId);

		modelBuilder.Entity<Prescription>()
			.HasKey(p => p.Id);
		modelBuilder.Entity<Prescription>()
			.HasOne(p => p.Patient)
			.WithMany(pt => pt.Prescriptions)
			.HasForeignKey(p => p.PatientId);
		modelBuilder.Entity<Prescription>()
			.HasOne(p => p.Medicine)
			.WithMany(m => m.Prescriptions)
			.HasForeignKey(p => p.MedicineId);

		modelBuilder.Entity<Illness>()
			.HasKey(i => i.Id);

		modelBuilder.Entity<Medicine>()
			.HasKey(m => m.Id);
	}
}