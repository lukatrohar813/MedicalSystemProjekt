using DAL.Model;

namespace DAL.IRepository
{
	public interface IExaminationImageRepository
	{
		Task<ExaminationImage> GetByIdAsync(int id);
		Task<IEnumerable<ExaminationImage>> GetByExaminationIdAsync(int examinationId);
		Task<IEnumerable<ExaminationImage>> GetAllAsync();
		Task AddAsync(ExaminationImage examinationImage);
		Task UpdateAsync(ExaminationImage examinationImage);
		Task DeleteAsync(int id);
	}
}
