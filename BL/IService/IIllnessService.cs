using BL.Models;

namespace BL.IService
{
	public interface IIllnessService
	{
		Task<IEnumerable<IllnessDto>> GetAllAsync();
		Task<IllnessDto?> GetByIdAsync(int id);
		Task<bool> AddAsync(IllnessDto? illnessDto);
		Task<bool> UpdateAsync(IllnessDto? illnessDto);
		Task<bool> DeleteAsync(int id);
	}
}