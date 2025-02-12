using BL.Models;


namespace BL.IService
{
	public interface IExaminationService
	{
		Task<IEnumerable<ExaminationDto>> GetAllAsync();
		Task<IEnumerable<ExaminationDto>> GetByPatientIdAsync(int patientId);
		Task<ExaminationDto> GetByIdAsync(int id);
		Task<bool> AddAsync(ExaminationDto? examinationDto);
		Task<bool> UpdateAsync(ExaminationDto? examinationDto);
		Task<bool> DeleteAsync(int id);
	}
}
