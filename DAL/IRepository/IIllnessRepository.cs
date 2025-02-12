using DAL.Model;

namespace DAL.IRepository
{
	public interface IIllnessRepository
	{
		Task<Illness> GetByIdAsync(int id);
		Task<IEnumerable<Illness>> GetAllAsync();
		Task AddAsync(Illness illness);
		Task UpdateAsync(Illness illness);
		Task DeleteAsync(int id);
	}
}