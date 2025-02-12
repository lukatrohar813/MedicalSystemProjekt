namespace DAL.IRepository
{
	public interface IUnitOfWork : IDisposable, IAsyncDisposable
	{
		IPatientRepository Patients { get; }
		IMedicalHistoryRepository MedicalHistories { get; }
		IExaminationRepository Examinations { get; }
		IExaminationImageRepository ExaminationImages { get; }
		IPrescriptionRepository Prescriptions { get; }

		Task SaveChangesAsync();
	}


}
