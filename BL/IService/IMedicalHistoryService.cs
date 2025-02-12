using BL.Models;

namespace BL.IService
{
	public interface IMedicalHistoryService
	{
		Task<IEnumerable<MedicalHistoryDto>> GetAllAsync();
		Task<IEnumerable<MedicalHistoryDto>> GetByPatientIdAsync(int patientId);
		Task<MedicalHistoryDto> GetByIdAsync(int id);
		Task<bool> AddAsync(MedicalHistoryDto? medicalHistoryDto);
		Task<bool> UpdateAsync(MedicalHistoryDto? medicalHistoryDto);
		Task<bool> DeleteAsync(int id);
	}
}
