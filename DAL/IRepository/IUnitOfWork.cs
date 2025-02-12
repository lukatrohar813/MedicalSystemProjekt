namespace DAL.IRepository
{
	public interface IUnitOfWork : IDisposable, IAsyncDisposable
	{
		IPatientRepository Patients { get; }
		IMedicalHistoryRepository MedicalHistories { get; }
		IExaminationRepository Examinations { get; }
		IExaminationImageRepository ExaminationImages { get; }
		IPrescriptionRepository Prescriptions { get; }
		IIllnessRepository Illnesses { get; }
		IMedicineRepository Medicines { get; }

		Task SaveChangesAsync();
	}
}