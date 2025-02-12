using DAL.Model;

namespace DAL.IRepository
{
	public interface IMedicalHistoryRepository
	{

		public Task UpdateAsync(MedicalHistory medicalHistory);
		public Task DeleteAsync(int id);
		Task<IEnumerable<MedicalHistory>> GetAllAsync();
		public Task<MedicalHistory> GetByIdAsync(int id);
		public Task<IEnumerable<MedicalHistory>> GetByPatientIdAsync(int patientId);
		public Task AddAsync(MedicalHistory medicalHistory);

	}
}
