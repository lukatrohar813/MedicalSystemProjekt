using DAL.Model;

namespace DAL.IRepository
{
	public interface IExaminationRepository
	{
		Task<Examination> GetByIdAsync(int id);
		Task<IEnumerable<Examination>> GetByPatientIdAsync(int patientId);
		Task<IEnumerable<Examination>> GetAllAsync();
		Task AddAsync(Examination examination);
		Task UpdateAsync(Examination examination);
		Task DeleteAsync(int id);
	}
}
