using DAL.IRepository;
using DAL.Model;

namespace DAL.Repository
{
	public class UnitOfWork(MedicalSystemContext context) : IUnitOfWork
	{
		private IPatientRepository? _patientRepository;
		private IMedicalHistoryRepository? _medicalHistoryRepository;
		private IExaminationRepository? _examinationRepository;
		private IExaminationImageRepository? _examinationImageRepository;
		private IPrescriptionRepository? _prescriptionRepository;
		private IIllnessRepository? _illnessRepository;
		private IMedicineRepository? _medicineRepository;

		public IPatientRepository Patients => _patientRepository ??= new PatientRepository(context);
		public IMedicalHistoryRepository MedicalHistories => _medicalHistoryRepository ??= new MedicalHistoryRepository(context);
		public IExaminationRepository Examinations => _examinationRepository ??= new ExaminationRepository(context);
		public IExaminationImageRepository ExaminationImages => _examinationImageRepository ??= new ExaminationImageRepository(context);
		public IPrescriptionRepository Prescriptions => _prescriptionRepository ??= new PrescriptionRepository(context);
		public IIllnessRepository Illnesses => _illnessRepository ??= new IllnessRepository(context);
		public IMedicineRepository Medicines => _medicineRepository ??= new MedicineRepository(context);

		public async Task SaveChangesAsync()
		{
			await context.SaveChangesAsync();
		}

		public void Dispose()
		{
			context.Dispose();
		}

		public async ValueTask DisposeAsync()
		{
			await context.DisposeAsync();
		}
	}
}