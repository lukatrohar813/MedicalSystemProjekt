using DAL.Model;

namespace DAL.IRepository
{
	public interface IMedicineRepository
	{
		Task<Medicine> GetByIdAsync(int id);
		Task<IEnumerable<Medicine>> GetAllAsync();
		Task AddAsync(Medicine medicine);
		Task UpdateAsync(Medicine medicine);
		Task DeleteAsync(int id);
	}
}