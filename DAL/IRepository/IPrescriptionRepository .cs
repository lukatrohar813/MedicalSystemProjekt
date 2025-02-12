using DAL.Model;

namespace DAL.IRepository
{
	public interface IPrescriptionRepository
	{
		Task<Prescription> GetByIdAsync(int id);
		Task<IEnumerable<Prescription>> GetByPatientIdAsync(int patientId);
		Task<IEnumerable<Prescription>> GetAllAsync();
		Task AddAsync(Prescription prescription);
		Task UpdateAsync(Prescription prescription);
		Task DeleteAsync(int id);
	}
}
