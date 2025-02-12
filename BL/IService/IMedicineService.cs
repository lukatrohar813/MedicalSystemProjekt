using BL.Models;

namespace BL.IService
{
	public interface IMedicineService
	{
		Task<IEnumerable<MedicineDto>> GetAllAsync();
		Task<MedicineDto?> GetByIdAsync(int id);
		Task<bool> AddAsync(MedicineDto? medicineDto);
		Task<bool> UpdateAsync(MedicineDto? medicineDto);
		Task<bool> DeleteAsync(int id);
	}
}